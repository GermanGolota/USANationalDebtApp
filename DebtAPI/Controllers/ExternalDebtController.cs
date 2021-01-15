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
    [Route("api/[controller]")]
    public class ExternalDebtController : ControllerBase
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
            DebtModelRead model = new DebtModelRead { Day = dbmodel.Time, Debt = dbmodel.Debt, Increase = dbmodel.Increase };
            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{mode}")]
        public async Task<ActionResult<DebtModelRead>> GetDebtModel(string mode)
        {
            switch (mode)
            {
                case "now":
                    ExternalIncreaseModel dbmodel = await _db.GetExternalDebtInfo();
                    DebtModelRead model = new DebtModelRead { Day = dbmodel.Time, Debt = dbmodel.Debt, Increase = dbmodel.Increase };
                    if (model is not null)
                    {
                        TimeSpan timeElapsed = DateTime.Now - model.Day;
                        double increase = timeElapsed.TotalSeconds * model.Increase;
                        model.Debt += increase;
                        model.Day = DateTime.Now;
                        return Ok(model);
                    }
                    else
                    {
                        return NotFound();
                    }
                case "last":
                    return await GetDebtModel();
                default: return BadRequest();
            }
        }
    }
}
