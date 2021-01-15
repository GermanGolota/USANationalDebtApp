using Core;
using Core.Entities;
using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public class EFClientRepo : IClientRepo
    {
        private readonly DebtContext _context;

        public EFClientRepo(DebtContext context)
        {
            this._context = context;
        }

        public async Task<ExternalIncreaseModel> GetExternalDebtInfo()
        {
            ExternalIncreaseModel model = await _context.ExternalDebtsInfo.LastOrDefaultAsync();
            return model;
        }

        public async Task<InternalIncreaseModel> GetInternalDebtInfo()
        {
            InternalIncreaseModel model = await _context.InternalDebtsInfo.LastOrDefaultAsync();
            return model;
        }
    }
}
