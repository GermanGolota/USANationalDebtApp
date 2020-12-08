using DataAccessLibrary.Models.DbModels;

namespace DataAccessLibrary.Models.ApiModels
{
    public interface IModelConverter
    {
        DebtModel ConvertModelFromAPI(DebtAPIModel apimodel);
    }
}