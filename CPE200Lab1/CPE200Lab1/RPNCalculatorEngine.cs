using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> myStack;
        public string Process(string str)
        {
            myStack = new Stack<string>();
            string[] parts = str.Split(' ');
            string first, second;

            foreach (string oper in parts)
            {
                if (isOperator(oper))
                {
                    try
                    {
                        first = myStack.Pop();
                        second = myStack.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    myStack.Push(calculate(oper, second, first));
                }
                else if (isNumber(oper))
                {
                    myStack.Push(oper);
                }
                else if (oper == "1/x")
                {
                    try
                    {
                        first = myStack.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    myStack.Push(calculate(oper, first));
                }
                else if (oper == "%")
                {
                    try
                    {
                        first = myStack.Pop();
                        second = myStack.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    myStack.Push(calculate(oper, first, second));
                }
                else if (oper == "√")
                {
                    try
                    {
                        first = myStack.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        return "E";
                    }
                    myStack.Push(calculate(oper, first));
                }
            }

            if (myStack.Count > 1)
            {
                return "E";
            }

            return myStack.Pop();
        }
    }
}