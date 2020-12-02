using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.Api
{
    //Class, that is used to test db system, that depends on the api, without actually implementing api
    public class MockApiDataManager : IApiDataManager
    {
        public async Task<List<DebtModel>> GetDebtModels()
        {
            List<DebtModel> models = new List<DebtModel> {
                new DebtModel { Day = new DateTime(year:2020, month:4, day:12), Debt=200},
                new DebtModel { Day = new DateTime(year:2020, month:4, day:13), Debt=205} ,
                new DebtModel { Day = new DateTime(year:2020, month:4, day:14), Debt=212} ,
                new DebtModel { Day = new DateTime(year:2020, month:4, day:15), Debt=214},
                new DebtModel { Day = new DateTime(year:2020, month:4, day:18), Debt=220}
            };
            return models;
        }
    }
}
