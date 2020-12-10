using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLibrary.Models.DBModels
{
    public class InternalDebtModel : DebtModelBase
    {
        public InternalDebtModel(DateTime day, double debt)
        {
            Day = day;
            Debt = debt;
        }
    }
}
