using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
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
