
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface IDebtData
    {
        Task AddDebtToDB(InternalDebtModel model);
        Task AddDebtToDB(ExternalDebtModel model);
        Task CalculateAndInsertNewInfo();
    }
}