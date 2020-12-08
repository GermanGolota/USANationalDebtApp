using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface IClientAccess
    {
        Task<DebtIncreaseModel> GetDebtInfo();
    }
}
