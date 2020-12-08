using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtAPI
{
    public class DebtContext:DbContext
    {
        public DebtContext(DbContextOptions<DebtContext> options):base(options)
        {

        }
        public DbSet<DebtModel> DebtAPIInfos { get; set; }

        public DbSet<DebtIncreaseModel> DebtInfos { get; set; }
    }
}
