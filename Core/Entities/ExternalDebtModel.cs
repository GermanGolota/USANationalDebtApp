using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class ExternalDebtModel:DebtModelBase
    {
        private ExternalDebtModel()
        {

        }
        public ExternalDebtModel(DateTime day, double debt)
        {
            Time = day;
            Debt = debt;
        }
    }
}
