using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_21
{
    class Circle
    {
        double pi = 3.14;

        public double GetPi()
        {
            return pi;
        }

        public void SetPi(double value)
        {
            pi = value;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            circle.SetPi(3.14159);
            double piValue = circle.GetPi();
            Console.WriteLine(piValue);
        }
    }
}
