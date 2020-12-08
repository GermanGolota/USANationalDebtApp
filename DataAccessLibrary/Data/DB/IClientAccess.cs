using DataAccessLibrary.Models;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface IClientAccess
    {
        Task<DebtIncreaseModel> GetDebtInfo();
    }
}
