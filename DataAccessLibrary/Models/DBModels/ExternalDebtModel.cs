using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models.DbModels
{
    public class ExternalDebtModel
    {
        public ExternalDebtModel(DateTime day, double debt)
        {
            Day = day;
            Debt = debt;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public double Debt { get; set; }
    }
}
