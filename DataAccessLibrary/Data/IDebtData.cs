using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    interface IDebtData
    {
        Task AddDebtToDB(DebtModel model);
        Task CalculateAndInsertNewInfo();
        Task<List<DebtModel>> GetDebtsFromDB();
        Task<DebtIncreaseModel> TryGetDebtInfo();
    }
}