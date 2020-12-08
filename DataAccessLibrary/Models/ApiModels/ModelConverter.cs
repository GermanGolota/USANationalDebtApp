using DataAccessLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models.ApiModels
{
    public class ModelConverter : IModelConverter
    {
        public DebtModel ConvertModelFromAPI(DebtAPIModel apimodel)
        {
            DateTime date = new DateTime(year: apimodel.reporting_calendar_year, month: apimodel.reporting_calendar_month,
                day: apimodel.reporting_calendar_day);
            DebtModel model = new DebtModel(date, apimodel.debt_held_public_amt);
            return model;
        }
    }
}
