using DataAccessLibrary;
using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
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
    public class DebtController : ControllerBase
    {
        private readonly IClientAccess _db;

        public DebtController(IClientAccess db)
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<ActionResult<DebtModelRead>> GetDebtModel()
        {
            DebtIncreaseModel dbmodel = await _db.GetDebtInfo();
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
