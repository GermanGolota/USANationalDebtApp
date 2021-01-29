using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Data
{
    public class LinearPredictionAlgorithm : IPredictionAlgorithm
    {
        private List<double> xValues;
        private List<double> yValues;

        public double PredictValue(List<double> xValues, List<double> yValues, double inputValue)
        {
            this.xValues = xValues;
            this.yValues = yValues;
            return this.CalculateLinearPrediction(inputValue);
        }
        private double CalculateLinearPrediction(double inputValue)
        {
            double X1 = xValues[0];
            double Y1 = yValues[0];
            double Xmean = getAvgX(xValues);
            double Ymean = getAvgY(yValues);
            double lineSlope = getLineSlope(Xmean, Ymean, X1, Y1);
            double YIntercept = getYIntercept(Xmean, Ymean, lineSlope);
            double prediction = (lineSlope * inputValue) + YIntercept;
            return prediction;
        }
        private double getAvgX(List<double> Xdata)
        {
            double sum = 0.0f;
            for (int i = 0; i < Xdata.Count; i++)
            {
                sum += Xdata[i];
            }
            return sum / Xdata.Count;
        }
        private double getAvgY(List<double> Ydata)
        {
            double sum = 0;
            for (int i = 0; i < Ydata.Count; i++)
            {
                sum += Ydata[i];
            }
            return sum / Ydata.Count;
        }
        private double getLineSlope(double Xmean, double Ymean, double X1, double Y1)
        {
            double num1 = X1 - Xmean;
            double num2 = Y1 - Ymean;
            double denom = (X1 - Xmean) * (X1 - Xmean);
            return (num1 * num2) / denom;
        }

        private double getYIntercept(double Xmean, double Ymean, double lineSlope)
        {
            return Ymean - (lineSlope * Xmean);
        }
    }
}
