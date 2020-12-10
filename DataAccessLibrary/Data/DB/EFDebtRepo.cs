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
            _context.DebtAPIInfos.Add(model);
            _context.SaveChanges();
        }

        public async Task CalculateAndInsertNewInfo()
        {
            List<InternalDebtModel> debts = _context.DebtAPIInfos.ToList();
            debts = debts.OrderBy((debt) => debt.Day).ToList();
            InternalDebtModel higher = debts.Last();
            InternalDebtModel lower = debts.First();
            double diff = higher.Debt - lower.Debt;
            TimeSpan time = higher.Day - lower.Day;
            double increment = diff / time.TotalSeconds;
            TimeSpan span = DateTime.Now - higher.Day;
            double currentDebt = higher.Debt + span.TotalSeconds * increment;
            DebtIncreaseModel model = new DebtIncreaseModel(DateTime.Now, currentDebt, increment);
            _context.DebtInfos.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<InternalDebtModel>> GetDebtsFromDB()
        {
            return _context.DebtAPIInfos.ToList();
        }
    }
}
