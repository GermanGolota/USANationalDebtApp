using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class DebtModelBase
    {
        [Key]
        public DateTime Time { get; set; }
        [Required]
        public double Debt { get; set; }
    }
}