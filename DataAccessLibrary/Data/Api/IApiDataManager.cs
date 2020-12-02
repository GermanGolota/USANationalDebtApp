using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary
{
    interface IApiDataManager
    {
        List<DebtModel> GetDebtModels();
    }
}
