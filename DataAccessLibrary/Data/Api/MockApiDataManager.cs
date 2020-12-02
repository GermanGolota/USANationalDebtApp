using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Data.Api
{
    //Class, that is used to test db system, that depends on the api, without actually implementing api
    class MockApiDataManager : IApiDataManager
    {
        public List<DebtModel> GetDebtModels()
        {
            return new List<DebtModel> {
                new DebtModel { Day = new DateTime(year:2020, month:4, day:12), Debt=200},
                new DebtModel { Day = new DateTime(year:2020, month:4, day:13), Debt=205} ,
                new DebtModel { Day = new DateTime(year:2020, month:4, day:14), Debt=212} ,
                new DebtModel { Day = new DateTime(year:2020, month:4, day:15), Debt=214},
                new DebtModel { Day = new DateTime(year:2020, month:4, day:18), Debt=220}
            };
        }
    }
}
