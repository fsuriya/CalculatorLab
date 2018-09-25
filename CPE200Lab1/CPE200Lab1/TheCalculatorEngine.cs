using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class TheCalculatorEngine
    {
        protected bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        protected bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }
        public string calculate(string oper, string firstOperand)
        {
            int maxOutputSize = 8;
            switch (oper)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        if (Convert.ToDouble(firstOperand) >= 0)
                        {
                            result = Math.Sqrt(Convert.ToDouble(firstOperand));
                        }
                        else
                        {
                            return "E";
                        }
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if (firstOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        result = (1.0 / Convert.ToDouble(firstOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }
        public string calculate(string oper, string firstOperand, string secondOperand)
        {
            int maxOutputSize = 8;
            switch (oper)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
                    break;
            }
            return "E";
        }
    }
}
