using DataAccessLibrary.Models;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    interface IClientAccess
    {
        Task<DebtIncreaseModel> GetDebtInfo();
    }
}