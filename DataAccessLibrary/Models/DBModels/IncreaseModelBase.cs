using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models.DBModels
{
    public class IncreaseModelBase
    {
        [Key]
        public DateTime Time { get; set; }
        [Required]
        public double Debt { get; set; }
        [Required]
        public double Increase { get; set; }
    }
}