using Core.Entities;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.API
{
    public interface IApiDataManager
    {
        Task<List<KeyValuePair<InternalDebtModel,ExternalDebtModel>>> GetDebtModels();
    }
}
