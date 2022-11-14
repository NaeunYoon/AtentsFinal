using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_23
{
    class Circle
    {
        double pi = 3.14;

        public double PI
        {
            get { return pi; }
            set { pi = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            circle.PI = 3.14159;        //쓰기
            double piVlaue = circle.PI; //읽기

            Console.WriteLine(piVlaue);

        }
    }
}
