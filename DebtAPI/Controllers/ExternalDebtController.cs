using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalDebtController: ControllerBase
    {
        private readonly IClientRepo _db;

        public ExternalDebtController(IClientRepo db)
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<ActionResult<DebtModelRead>> GetDebtModel()
        {
            ExternalIncreaseModel dbmodel = await _db.GetExternalDebtInfo();
            //TODO:add automapper
            DebtModelRead model = new DebtModelRead { Day = dbmodel.Day, Debt = dbmodel.Debt, Increase = dbmodel.Increase };
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
