using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_22
{
    class Circle
    {
        double pi = 3.14;

        public void SetPi(double value)
        {
            if(value<=3|| value > 3.15)
            {
                Console.WriteLine("문제발생");
            }
            else
            {
                Console.WriteLine("정상");
            }
            value =pi;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            circle.SetPi(10);
            circle.SetPi(3.14);
        }
    }
}
