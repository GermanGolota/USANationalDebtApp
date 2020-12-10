using DataAccessLibrary;
using DataAccessLibrary.Models;
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

        public EFDebtRepo(DebtContext context)
        {
            this._context = context;
        }
        public async Task AddDebtToDB(InternalDebtModel model)
        {
            _context.InternalDebtsAPI.Add(model);
            _context.SaveChanges();
        }

        public async Task AddDebtToDB(ExternalDebtModel model)
        {
            _context.ExternalDebtsAPI.Add(model);
            _context.SaveChanges();
        }

        public async Task CalculateAndInsertNewInfo()
        {
            IEnumerable<InternalDebtModel> internalDebts = _context.InternalDebtsAPI;
            InternalIncreaseModel internalModel =CalculateIncreaseModel(internalDebts) as InternalIncreaseModel;
            _context.InternalDebtsInfo.Add(internalModel);

            IEnumerable<ExternalDebtModel> externalDebts = _context.ExternalDebtsAPI;
            ExternalIncreaseModel externalModel = CalculateIncreaseModel(externalDebts) as ExternalIncreaseModel;
            _context.ExternalDebtsInfo.Add(externalModel);

            _context.SaveChanges();
        }

        private IncreaseModelBase CalculateIncreaseModel(IEnumerable<DebtModelBase> models)
        {
            models = models.OrderBy((debt) => debt.Day).ToList();
            DebtModelBase higher = models.Last();
            DebtModelBase lower = models.First();
            double diff = higher.Debt - lower.Debt;
            TimeSpan time = higher.Day - lower.Day;
            double increment = diff / time.TotalSeconds;
            TimeSpan span = DateTime.Now - higher.Day;
            double currentDebt = higher.Debt + span.TotalSeconds * increment;
            IncreaseModelBase model = new IncreaseModelBase
            {
                Day = DateTime.Now,
                Debt = currentDebt,
                Increase = increment
            };
            return model;
        }
    }
}
