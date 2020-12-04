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
                //2020-12-02
                new DebtModel { Day = new DateTime(year:2020, month:12, day:02), Debt=21341926023922},
                new DebtModel { Day = new DateTime(year:2020, month:11, day:30), Debt=21342192975117},
                new DebtModel { Day = new DateTime(year:2020, month:11, day:27), Debt=21349471573310},
                new DebtModel { Day = new DateTime(year:2020, month:11, day:25), Debt=21197640169859},
                new DebtModel { Day = new DateTime(year:2020, month:11, day:24), Debt=21218611743445}
            };
            return models;
        }
    }
}
