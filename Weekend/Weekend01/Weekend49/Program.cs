using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend49
{
    delegate int Func(int a, int b);
    internal class Program
    {
        static int add(int a, int b)
        {
            return a + b;
        }

        static int sub(int a, int b)
        {
            return a + b;
        }

        static int mul(int a, int b)
        {
            return a + b;
        }

        static int calculator(Func func, int a, int b)
        {
            return func(a, b);
        }

        static void Main(string[] args)
        {
            int a = 20;
            int b = 30;

            Func Add = add;

            //Add = mul;
            //Add = sub;

            Console.WriteLine("{0} + {1} = {2}", a, b, Add(a, b));

            Console.WriteLine("{0} - {1} = {2}", a, b, calculator(sub, a, b));
            Console.WriteLine("{0} x {1} = {2}", a, b, calculator(mul, a, b));

        }
    }
}
