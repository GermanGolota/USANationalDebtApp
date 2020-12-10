using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface IClientAccess
    {
        Task<InternalIncreaseModel> GetInternalDebtInfo();

        Task<ExternalIncreaseModel> GetExternalDebtInfo();
    }
}
