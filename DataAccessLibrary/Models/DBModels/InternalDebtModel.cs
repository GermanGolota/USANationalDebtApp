using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLibrary.Models.DBModels
{
    public class InternalDebtModel
    {
        public InternalDebtModel(DateTime day, double debt)
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
