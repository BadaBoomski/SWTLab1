using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double Accumulator { get; private set; } //Class-property
        public Calculator() => Accumulator = 0; //make sure that accumulator is 0 when initiating a new Calc instance.

        public double Add(double a) {
            return Accumulator = a + Accumulator;
        }

        public double Add(double a, double b) {
            return Accumulator = a + b;
        }

        public double Subtract(double a, double b) {
            return Accumulator = a - b;
        }

        public double Subtract(double a) {
            return Accumulator = a - Accumulator;
        }

        public double Multiply(double a, double b) {
            return Accumulator = a * b;
        }

        public double Multiply(double a) {
            return Accumulator = a * Accumulator;
        }

        public double Power(double x, double exp) {
            return Accumulator = Math.Pow(x, exp);
        }

        public double Power(double exp) {
            return Accumulator = Math.Pow(Accumulator, exp);
        }

        public double Divide(double dividend, double divisor) {
            return Accumulator = dividend / divisor;
        }

        public double Divide(double divisor) {
            return Accumulator = Accumulator / divisor;
        }
    }
}
