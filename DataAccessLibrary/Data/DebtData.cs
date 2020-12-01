using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class DebtData
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
        public async Task<DebtIncreaseModel> GetDebtInfo()
        {
            string sql = @"SELECT * FROM debtinfo ORDER BY id DESC LIMIT 1;";
            DebtIncreaseModel model = (await _db.LoadData<DebtIncreaseModel, object>(sql,null))[0];
            return model;
        }
    }
}
