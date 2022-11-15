using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_37
{
    public class Point
    {
        int x, y;
        public Point (int x, int y) //생성자
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()   //..?
        {
            return "x :" + x + ",y :" + y;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(5, 10);
            Console.WriteLine(point.ToString());
        }
    }
}
