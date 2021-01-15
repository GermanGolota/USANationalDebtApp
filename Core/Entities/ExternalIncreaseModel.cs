using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class ExternalIncreaseModel : IncreaseModelBase
    {
        public ExternalIncreaseModel(DateTime day, double debt, double increase)
        {
            Time = day;
            Debt = debt;
            Increase = increase;
        }
    }
}
