using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Data.DB
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
