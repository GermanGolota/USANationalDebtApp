using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.DB
{
    public class EFClientRepo : IClientAccess
    {
        private readonly DebtContext _context;

        public EFClientRepo(DebtContext context)
        {
            this._context = context;
        }
        public async Task<InternalIncreaseModel> GetDebtInfo()
        {
            int max = _context.InternalDebtsInfo.Max(i => i.Id);
            InternalIncreaseModel model = _context.InternalDebtsInfo.First(x => x.Id == max);
            return model;
        }
    }
}
