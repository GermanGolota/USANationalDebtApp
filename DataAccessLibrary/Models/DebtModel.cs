using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class DebtModel
    {
        public DebtModel(DateTime day, double debt)
        {
            Day = day;
            Debt = debt;
        }
        public DateTime Day { get; set; }
        public double Debt { get; set; }
    }
}
