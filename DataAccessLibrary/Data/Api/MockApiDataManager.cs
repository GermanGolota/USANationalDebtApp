using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.API
{
    //Class, that is used to test db system, that depends on the api, without actually implementing api
    public class MockApiDataManager : IApiDataManager
    {
        public async Task<List<KeyValuePair<InternalDebtModel, ExternalDebtModel>>> GetDebtModels()
        {
            List<InternalDebtModel> internalModels = new List<InternalDebtModel> {
                //2020-12-02
                new InternalDebtModel(new DateTime(year:2020, month:12, day:02), 21341926023922),
                new InternalDebtModel(new DateTime(year:2020, month:12, day:02), 21341926023922),
                new InternalDebtModel(new DateTime(year: 2020, month: 11, day: 30), 21342192975117),
                new InternalDebtModel(new DateTime(year:2020, month:11, day:27), 21349471573310),
                new InternalDebtModel(new DateTime(year:2020, month:11, day:25), 21197640169859),
                new InternalDebtModel(new DateTime(year: 2020, month: 11, day: 24), 21218611743445)
            };
            List<ExternalDebtModel> ExternalModels = new List<ExternalDebtModel> {
                //2020-12-02
                new ExternalDebtModel(new DateTime(year:2020, month:12, day:02), 6070387141183.46),
                new ExternalDebtModel(new DateTime(year:2020, month:12, day:02), 6070387141183.46),
                new ExternalDebtModel(new DateTime(year: 2020, month: 11, day: 30), 6096816614939.36),
                new ExternalDebtModel(new DateTime(year:2020, month:11, day:27), 6057003752955.67),
                new ExternalDebtModel(new DateTime(year:2020, month:11, day:25), 6056550011420.35),
                new ExternalDebtModel(new DateTime(year: 2020, month: 11, day: 24), 6071729311011.39)
            };
            List<KeyValuePair<InternalDebtModel, ExternalDebtModel>> models = new List<KeyValuePair<InternalDebtModel, ExternalDebtModel>>();

            for (int i = 0; i < internalModels.Count; i++)
            {
                models.Add(new KeyValuePair<InternalDebtModel, ExternalDebtModel>(internalModels[i], ExternalModels[i]));
            }

            return models;
        }
    }
}
