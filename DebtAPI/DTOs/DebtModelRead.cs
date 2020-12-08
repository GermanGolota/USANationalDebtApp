using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class DebtModelRead
    {
        public DateTime Day { get; set; }
        public double Debt { get; set; }
        public double Increase { get; set; }
    }
}
