using DataAccessLibrary.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models.DbModels
{
    public class ExternalDebtModel:DebtModelBase
    {
        public ExternalDebtModel(DateTime day, double debt)
        {
            Day = day;
            Debt = debt;
        }
    }
}
