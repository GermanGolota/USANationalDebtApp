using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models.DBModels
{
    public class DebtModelBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public double Debt { get; set; }
    }
}