using DataAccessLibrary;
using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InternalDebtController : ControllerBase
    {
        private readonly IClientRepo _db;

        public InternalDebtController(IClientRepo db)
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<ActionResult<DebtModelRead>> GetDebtModel()
        {
            InternalIncreaseModel dbmodel = await _db.GetInternalDebtInfo();
            //TODO:add automapper
            DebtModelRead model = new DebtModelRead {Day =dbmodel.Day,Debt= dbmodel.Debt,Increase=dbmodel.Increase };
            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
