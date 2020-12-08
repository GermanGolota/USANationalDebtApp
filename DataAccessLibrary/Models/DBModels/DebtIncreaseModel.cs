using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models.DbModels
{
    public class DebtIncreaseModel
    {
        public DebtIncreaseModel(DateTime day, double debt, double increase )
        {
            Day = day;
            Debt = debt;
            Increase = increase;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public double Debt { get; set; }
        [Required]
        public double Increase { get; set; }
    }
}
