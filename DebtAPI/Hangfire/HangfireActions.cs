using Core.Entities;
using DataAccessLibrary.Data.API;
using DataAccessLibrary.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAPI.Hangfire
{
    public class HangfireActions
    {
        private readonly ISystemRepo _db;
        private readonly IApiDataManager _api;

        public HangfireActions(ISystemRepo DB, IApiDataManager API)
        {
            _db = DB;
            _api = API;
        }
        public async Task GetDataFromAPIAndPutItIntoDB()
        {
            List<KeyValuePair<InternalDebtModel, ExternalDebtModel>> models = await _api.GetDebtModels();
            foreach (var model in models)
            {
                await _db.AddDebtToDB(model.Key);
                await _db.AddDebtToDB(model.Value);
            }
        }
        public async Task RecalculateGrowth()
        {
            await _db.CalculateAndInsertNewInfo();
        }
    }
}
