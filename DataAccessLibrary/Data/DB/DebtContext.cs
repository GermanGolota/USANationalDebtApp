using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
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
        public DbSet<InternalDebtModel> InternalDebtsAPI{ get; set; }
        public DbSet<ExternalDebtModel> ExternalDebtsAPI { get; set; }
        public DbSet<InternalIncreaseModel> InternalDebtsInfo { get; set; }
        public DbSet<ExternalIncreaseModel> ExternalDebtsInfo { get; set; }

    }
}
