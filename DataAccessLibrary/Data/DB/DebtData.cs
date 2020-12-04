using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DebtData : IDebtData
    {
        private readonly ISQLDataAccess _db;

        public DebtData(ISQLDataAccess db)
        {
            this._db = db;
        }
        public async Task AddDebtToDB(DebtModel model)
        {
            string sql = @"INSERT usadebt(Day, Debt) Values(@Day, @Debt);";
            await _db.SaveData<DebtModel>(sql, model);
        }
        public async Task<List<DebtModel>> GetDebtsFromDB()
        {
            string sql = @"SELECT day, debt FROM usadebt limit 100;";
            List<DebtModel> models = await _db.LoadDataNoParam<DebtModel>(sql);
            return models;
        }
        //gets value with increase
        
        public async Task CalculateAndInsertNewInfo()
        {
            List<DebtModel> debts = await this.GetDebtsFromDB();
            debts = debts.OrderBy((debt) => debt.Day).ToList();
            DebtModel higher = debts.Last();
            DebtModel lower = debts.First();
            double diff = higher.Debt - lower.Debt;
            TimeSpan time = higher.Day - lower.Day;
            double increment = diff / time.TotalSeconds;
            TimeSpan span = DateTime.Now - higher.Day;
            double currentDebt = higher.Debt + span.TotalSeconds * increment;
            DebtIncreaseModel model = new DebtIncreaseModel(DateTime.Now, currentDebt, increment);


            string sql = @"INSERT debtinfo(Day, Debt, Increase) Values(@Day, @Debt, @Increase);";
            await _db.SaveData<DebtIncreaseModel>(sql, model);
        }
    }
}
