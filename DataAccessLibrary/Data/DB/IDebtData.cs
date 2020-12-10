
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface IDebtData
    {
        Task AddDebtToDB(InternalDebtModel model);
        Task CalculateAndInsertNewInfo();
        Task<List<InternalDebtModel>> GetDebtsFromDB();
    }
}