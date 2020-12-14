using DataAccessLibrary.Models.ApiModels;
using DataAccessLibrary.Models.DbModels;
using DataAccessLibrary.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class ModelConverter : IModelConverter
    {
        public KeyValuePair<InternalDebtModel, ExternalDebtModel> ConvertModelFromAPI(DebtAPIModel apimodel)
        {
            DateTime date = new DateTime(year: apimodel.reporting_calendar_year, month: apimodel.reporting_calendar_month,
                day: apimodel.reporting_calendar_day);

            InternalDebtModel model = new InternalDebtModel(date, apimodel.debt_held_public_amt);
            ExternalDebtModel extModel = new ExternalDebtModel(date, apimodel.intragov_hold_amt);

            return new KeyValuePair<InternalDebtModel, ExternalDebtModel>(model, extModel);
        }
        public ExternalIncreaseModel ConvertExternalFromBaseModel(IncreaseModelBase model)
        {
            ExternalIncreaseModel externalModel = new ExternalIncreaseModel(model.Day, model.Debt, model.Increase);
            return externalModel;
        }
        public InternalIncreaseModel ConvertInternalFromBaseModel(IncreaseModelBase model)
        {
            InternalIncreaseModel internalModel = new InternalIncreaseModel(model.Day, model.Debt, model.Increase);
            return internalModel;
        }
    }
}
