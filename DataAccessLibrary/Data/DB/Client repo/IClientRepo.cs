using Core.Entities;
using DataAccessLibrary.Models;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface IClientRepo
    {
        Task<InternalIncreaseModel> GetInternalDebtInfo();

        Task<ExternalIncreaseModel> GetExternalDebtInfo();
    }
}
