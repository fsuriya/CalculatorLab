using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine :CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> Stacknumber = new Stack<string>();
            string[] parts = str.Split(' ');
            string first, second;

            foreach (string number in parts)
            {
                if (isOperator(number))
                {
                    try
                    {
                        first = Stacknumber.Pop();
                        second = Stacknumber.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    Stacknumber.Push(calculate(number, second, first));
                }
                else if (isNumber(number))
                {
                    Stacknumber.Push(number);
                }
                else if (number == "1/x")
                {
                    try
                    {
                        first = Stacknumber.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    Stacknumber.Push(unaryCalculate(number, first));
                }
                else if (number == "%")
                {
                    try
                    {
                        first = Stacknumber.Pop();
                        second = Stacknumber.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    Stacknumber.Push(calculate(number, first, second));
                }
                else if (number == "√")
                {
                    try
                    {
                        first = Stacknumber.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    Stacknumber.Push(unaryCalculate(number, first));
                }
            }

            if (Stacknumber.Count > 1)
            {
                return "E";
            }

            return Stacknumber.Pop();
        }
    }
}