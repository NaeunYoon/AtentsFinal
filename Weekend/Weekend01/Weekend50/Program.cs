using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend50
{
    delegate int CalFunc(int a, int b);
    delegate void PrFunc(string str);

    class Program
    {
        static int calculator(CalFunc func, int a, int b)
        {
            return func(a, b);
        }
        static void Main(string[] args)
        {
            int a = 20;
            int b = 30;

            // 람다식 (무명함수)
            CalFunc add = (int c, int d) =>
            {
                return a + b;
            };

            Console.WriteLine("{0} + {1} = {2}\n", a, b, add(a, b));

            int ret = calculator((int c, int d) =>
            {
                return a - b;
            }, a, b);

            Console.WriteLine("{0} - {1} = {2}\n", a, b, ret);

            ret = calculator((int c, int d) => a * b, a, b);

            Console.WriteLine("{0} x {1} = {2}\n", a, b, ret);

            PrFunc print = (string str) =>
            {
                Console.WriteLine(str);
            };

            print("monster");
        }
    }

}
