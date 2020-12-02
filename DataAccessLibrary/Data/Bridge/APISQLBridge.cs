using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class APISQLBridge : IAPISQLBridge
    {
        private readonly IApiDataManager _api;
        private readonly IDebtData _debt;

        public APISQLBridge(IApiDataManager api, IDebtData debt)
        {
            this._api = api;
            this._debt = debt;
        }
        public async Task AddDataFromAPIToDb()
        {
            List<DebtModel> models =await _api.GetDebtModels();
            foreach (DebtModel model in models)
            {
                await _debt.AddDebtToDB(model);
            }
        }
    }
}
