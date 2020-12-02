using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IApiDataManager
    {
        Task<List<DebtModel>> GetDebtModels();
    }
}
