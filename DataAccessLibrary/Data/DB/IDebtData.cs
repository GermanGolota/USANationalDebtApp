
using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDebtData
    {
        Task AddDebtToDB(DebtModel model);
        Task CalculateAndInsertNewInfo();
        Task<List<DebtModel>> GetDebtsFromDB();
    }
}