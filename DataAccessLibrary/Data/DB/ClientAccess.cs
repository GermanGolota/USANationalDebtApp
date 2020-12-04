using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    class ClientAccess : IClientAccess
    {
        private readonly ISQLDataAccess _db;

        public ClientAccess(ISQLDataAccess db)
        {
            this._db = db;
        }
        public async Task<DebtIncreaseModel> GetDebtInfo()
        {
            string sql = @"SELECT Day, debt, Increase FROM debtinfo ORDER BY ID DESC LIMIT 1;";
            DebtIncreaseModel model;
            try
            {
                model = (await _db.LoadDataNoParam<DebtIncreaseModel>(sql))[0];
                return model;
            }
            catch
            {
                throw new Exception("Can't get data from db");
            }
        }
    }
}
