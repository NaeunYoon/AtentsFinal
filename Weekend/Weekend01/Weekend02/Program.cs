using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool a = true;                      //논리 bool
            Console.WriteLine("a = "+a);
            a = false;
            Console.WriteLine($"a = {a}");

            byte b = 255;                       //정수 byte
            Console.WriteLine("b = "+b);

            sbyte c = -127;                     //정수 sbyte
            Console.WriteLine("c = "+c);

            decimal d = 1.2323443454M;          //실수 decimal
            Console.WriteLine("d = "+d);        //M을 붙이지 않으면 double로 인식함

            double e = 1.2;                     //실수 double
            Console.WriteLine("e = "+e);

            float f = 1.234f;                   //실수 float
            Console.WriteLine("f = "+f);        //f을 붙이기

            int g = -10;                         //정수 int
            Console.WriteLine("g = "+g);

            uint h = 10;                        //정수uint
            Console.WriteLine("h = "+h);

            short i = 100;                      //정수 short
            Console.WriteLine("i = "+i);

            ushort j = 200;                     //정수 ushort
            Console.WriteLine("j = "+j);

            char k = '가';                       //문자 char
            Console.WriteLine("k = "+k);

            string l = "윤나은";                 //문자열 string
            Console.WriteLine("l = "+l);

            long m = 123456789;                 //정수 long
            Console.WriteLine("m = "+m);



        }
    }
}
