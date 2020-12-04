using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class DebtIncreaseModel:DebtModel
    {
        public DebtIncreaseModel(DateTime day, double debt, double increase ):base(day,debt)
        {
            Increase = increase;
        }
        public double Increase { get; set; }
    }
}
