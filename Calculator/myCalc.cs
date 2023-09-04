using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class myCalc
    {
        public myCalc() { }
        public double funcCalc(char sym, double num1, double num2)
        {
            switch (sym)
            {
                case '+': return SUM(num1, num2);
                case '-': return SUB(num1, num2);
                case '*': return MULTI(num1, num2);
                case '/': return DEV(num1, num2);
                default: throw new ArgumentException();
            }
        }
        private double SUM(double num1, double num2)
        {
            return num1 + num2;
        }
        private double SUB(double num1, double num2)
        {
            return num1 - num2;
        }
        private double DEV(double num1, double num2)
        {
            return num1 / num2;
        }
        private double MULTI(double num1, double num2)
        {
            return num1 * num2;
        }
    }
}
