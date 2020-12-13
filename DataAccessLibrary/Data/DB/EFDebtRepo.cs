using DataAccessLibrary;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.ApiModels;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public class EFDebtRepo : IDebtData
    {
        private readonly DebtContext _context;
        private readonly IModelConverter _converter;

        public EFDebtRepo(DebtContext context, IModelConverter converter)
        {
            this._context = context;
            this._converter = converter;
        }
        public async Task AddDebtToDB(InternalDebtModel model)
        {
            List<InternalDebtModel> models = _context.InternalDebtsAPI.ToList();
            List<InternalDebtModel> dbmodel = models.Where(x => x.Day == model.Day).ToList();
            if(dbmodel.Count==0)
            {
                _context.InternalDebtsAPI.Add(model);
                _context.SaveChanges();
            }
        }

        public async Task AddDebtToDB(ExternalDebtModel model)
        {
            List<ExternalDebtModel> models = _context.ExternalDebtsAPI.ToList();
            List<ExternalDebtModel> dbmodel = models.Where(x => x.Day == model.Day).ToList();
            if (dbmodel.Count == 0)
            {
                _context.ExternalDebtsAPI.Add(model);
                _context.SaveChanges();
            }
        }

        public async Task CalculateAndInsertNewInfo()
        {
            List<InternalDebtModel> internalDebts = _context.InternalDebtsAPI.ToList();
            InternalIncreaseModel internalModel =_converter.ConvertInternalFromBaseModel(CalculateIncreaseModel(internalDebts));
            _context.InternalDebtsInfo.Add(internalModel);

            List<ExternalDebtModel> externalDebts = _context.ExternalDebtsAPI.ToList();
            ExternalIncreaseModel externalModel = _converter.ConvertExternalFromBaseModel((CalculateIncreaseModel(externalDebts)));
            _context.ExternalDebtsInfo.Add(externalModel);

            _context.SaveChanges();
        }

        private IncreaseModelBase CalculateIncreaseModel(IEnumerable<DebtModelBase> models)
        {
            models = models.OrderBy((debt) => debt.Day).ToList();
            List<DebtModelBase> modelsList = models.ToList();

            double predictedValue = PredictValue(modelsList);

            DebtModelBase higher = models.Last();
            DebtModelBase lower = models.First();

            double increment = CalculateOneSecondIncrement(higher, lower);

            IncreaseModelBase model = new IncreaseModelBase
            {
                Day = DateTime.Now,
                Debt = predictedValue,
                Increase = increment
            };
            return model;
        }
        private double CalculateOneSecondIncrement(DebtModelBase higher, DebtModelBase lower)
        {
            double diff = higher.Debt - lower.Debt;
            TimeSpan time = higher.Day - lower.Day;
            double increment = diff / time.TotalSeconds;
            return increment;
        }
        private double PredictValue(List<DebtModelBase> models)
        {
            List<DateTime> dates = new List<DateTime>();
            List<double> values = new List<double>();
            for (int i = 0; i < models.Count; i++)
            {
                dates.Add(models[i].Day);
                values.Add(models[i].Debt);
            }

            List<double> datesAsDouble = new List<double>();
            for (int i = 0; i < dates.Count; i++)
            {
                datesAsDouble.Add((dates[i] - new DateTime()).TotalSeconds);
            }

            var algo = new LinearPredictionAlgorithm(datesAsDouble, values);
            double predictedValue = algo.predictValue((DateTime.Now - new DateTime()).TotalSeconds);
            return predictedValue;
        }

    }
}
