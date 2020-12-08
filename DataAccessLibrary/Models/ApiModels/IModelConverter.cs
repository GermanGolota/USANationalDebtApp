namespace DataAccessLibrary.Models
{
    public interface IModelConverter
    {
        DebtModel ConvertModelFromAPI(DebtAPIModel apimodel);
    }
}