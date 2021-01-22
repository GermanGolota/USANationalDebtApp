using Core.Entities;
using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public interface ISystemRepo
    {
        Task AddDebtToDB(InternalDebtModel model);
        Task AddDebtToDB(ExternalDebtModel model);
        Task CalculateAndInsertNewInfo();
    }
}