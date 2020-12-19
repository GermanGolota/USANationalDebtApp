using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface IClientRepo
    {
        Task<InternalIncreaseModel> GetInternalDebtInfo();

        Task<ExternalIncreaseModel> GetExternalDebtInfo();
    }
}
