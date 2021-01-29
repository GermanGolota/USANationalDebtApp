using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Data
{
    public interface IPredictionAlgorithm
    {
        public double PredictValue(List<double> xValues, List<double> yValues, double inputValue);
    }
}
