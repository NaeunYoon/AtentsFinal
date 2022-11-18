using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_45
{
    internal class Program
    {
        delegate void CalDelelgate(int x, int y);

        static void Add(int x, int y) { Console.WriteLine("x + y = "+(x + y)); }
        static void Sub(int x, int y) { Console.WriteLine("x - y = "+(x - y)); }
        static void Mul(int x, int y) { Console.WriteLine("x * y = "+(x * y)); }
        static void Div(int x, int y) { Console.WriteLine("x - y = "+(x / y)); }

        static void Main(string[] args)
        {
            CalDelelgate Cal = Add;
            Cal += Sub;
            Cal += Mul;
            Cal += Div;

            Cal(10, 5);
            Console.WriteLine("");
            Cal -= Mul; //목록에서 muitiply 메서드를 제거
            Cal(10, 5); //add, sub, div 메서드만 호출

        }
    }
}
