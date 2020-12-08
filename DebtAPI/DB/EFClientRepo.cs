using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAPI.DB
{
    public class EFClientRepo : IClientAccess
    {
        private readonly DebtContext _context;

        public EFClientRepo(DebtContext context)
        {
            this._context = context;
        }
        public async Task<DebtIncreaseModel> GetDebtInfo()
        {
            int max = _context.DebtInfos.Max(i => i.Id);
            DebtIncreaseModel model = _context.DebtInfos.First(x => x.Id == max);
            return model;
        }
    }
}
