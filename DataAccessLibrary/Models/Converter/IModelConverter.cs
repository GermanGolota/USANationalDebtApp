using DataAccessLibrary.Models.ApiModels;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public interface IModelConverter
    {
        KeyValuePair<InternalDebtModel, ExternalDebtModel> ConvertModelFromAPI(DebtAPIModel apimodel);

        ExternalIncreaseModel ConvertExternalFromBaseModel(IncreaseModelBase model);

        InternalIncreaseModel ConvertInternalFromBaseModel(IncreaseModelBase model);
    }
}