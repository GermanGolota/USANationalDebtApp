using Core;
using Core.Entities;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public class EFDebtRepo : ISystemRepo
    {
        private readonly DebtContext _context;
        private readonly IModelConverter _converter;
        private readonly IPredictionAlgorithm _algo;

        public EFDebtRepo(DebtContext context, IModelConverter converter, IPredictionAlgorithm algo)
        {
            this._context = context;
            this._converter = converter;
            this._algo = algo;
        }
        public async Task AddDebtToDB(InternalDebtModel model)
        {
            List<InternalDebtModel> dbmodel = _context.InternalDebtsAPI.Where(x => x.Time == model.Time).ToList();
            if(dbmodel.Count==0)
            {
                _context.InternalDebtsAPI.Add(model);
                _context.SaveChanges();
            }
            else
            {
                //log
            }
        }

        public async Task AddDebtToDB(ExternalDebtModel model)
        {
            List<ExternalDebtModel> dbmodel = _context.ExternalDebtsAPI.Where(x => x.Time == model.Time).ToList();
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
            models = models.OrderBy((debt) => debt.Time).ToList();
            List<DebtModelBase> modelsList = models.ToList();

            double predictedValue = PredictValue(modelsList);

            DebtModelBase higher = models.Last();
            DebtModelBase lower = models.First();

            double increment = CalculateOneSecondIncrement(higher, lower);

            IncreaseModelBase model = new IncreaseModelBase
            {
                Time = DateTime.Now,
                Debt = predictedValue,
                Increase = increment
            };
            return model;
        }
        private double CalculateOneSecondIncrement(DebtModelBase higher, DebtModelBase lower)
        {
            double diff = higher.Debt - lower.Debt;
            TimeSpan time = higher.Time - lower.Time;
            double increment = diff / time.TotalSeconds;
            return increment;
        }
        private double PredictValue(List<DebtModelBase> models)
        {
            List<DateTime> dates = new List<DateTime>();
            List<double> values = new List<double>();
            for (int i = 0; i < models.Count; i++)
            {
                dates.Add(models[i].Time);
                values.Add(models[i].Debt);
            }

            List<double> datesAsDouble = new List<double>();
            for (int i = 0; i < dates.Count; i++)
            {
                datesAsDouble.Add((dates[i] - new DateTime()).TotalSeconds);
            }

            double timeNowInSecond = (DateTime.Now - new DateTime()).TotalSeconds;
            double predictedValue = _algo.PredictValue(datesAsDouble, values, timeNowInSecond);
            return predictedValue;
        }

    }
}
