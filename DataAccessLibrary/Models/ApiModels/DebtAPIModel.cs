using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models.ApiModels
{
    public class DebtAPIModel
    {
        public double debt_held_public_amt { get; set; }
        public double intragov_hold_amt { get; set; }
        public int reporting_calendar_year { get; set; }
        public int reporting_calendar_month { get; set; }
        public int reporting_calendar_day { get; set; }

    }
}
