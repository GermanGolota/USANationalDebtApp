using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataAccessLibrary.Models.ApiModels;
using Core.Entities;

namespace DataAccessLibrary.Data.API
{
    public class DebtAPIDataManager : IApiDataManager
    {
        private readonly IAPIClient _client;
        private readonly IModelConverter _converter;

        public DebtAPIDataManager(IAPIClient client, IModelConverter converter)
        {
            this._client = client;
            this._converter = converter;
        }
        public async Task<List<KeyValuePair<InternalDebtModel,ExternalDebtModel>>> GetDebtModels()
        {
            string url = "https://www.transparency.treasury.gov/services/api/fiscal_service/v1/accounting/od/debt_to_penny?sort=-data_date&format=json";
            using (HttpResponseMessage response = await _client.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string modelsString = await response.Content.ReadAsStringAsync();
                    DebtAPIArray models = JsonConvert.DeserializeObject<DebtAPIArray>(modelsString);
                    var output = new List<KeyValuePair<InternalDebtModel, ExternalDebtModel>>();
                    foreach (DebtAPIModel model in models.data)
                    {
                        output.Add(_converter.ConvertModelFromAPI(model));
                    }
                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
