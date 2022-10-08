using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Weekend03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 30;
            int c = a + b;      //정수 + 정수 = 정수
                                //정수 - 정수 = 정수
                                //정수 * 정수 = 정수
                                //정수 / 정수 = 정수

            a = 1;
            b = 2;
            c = a / b;

            Console.WriteLine(c);

            float fc = a / b;
            Console.WriteLine(fc);

            fc = a / (float)b;
            Console.WriteLine(fc);


        }
    }
}
