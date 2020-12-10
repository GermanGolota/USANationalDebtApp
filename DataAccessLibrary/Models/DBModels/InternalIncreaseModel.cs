using DataAccessLibrary.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models.DbModels
{
    public class InternalIncreaseModel:IncreaseModelBase
    {
        public InternalIncreaseModel(DateTime day, double debt, double increase )
        {
            Day = day;
            Debt = debt;
            Increase = increase;
        }
    }
}
