using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class ExternalDebtModel:DebtModelBase
    {
        public ExternalDebtModel(DateTime day, double debt)
        {
            Time = day;
            Debt = debt;
        }
    }
}
