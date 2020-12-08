using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.API
{
    public interface IApiDataManager
    {
        Task<List<DebtModel>> GetDebtModels();
    }
}
