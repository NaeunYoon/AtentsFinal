using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend51
{
    delegate void CalChain(int a, int b);

    internal class Program
    {
        static void add(int a, int b)
        {
            Console.WriteLine($"add {a}+{b} = {a+b}",a+b);
        }
        static void sub(int a, int b)
        {
            Console.WriteLine($"sub {a}-{b} = {a - b}", a - b);
        }
        static void div(int a, int b)
        {
            Console.WriteLine($"div {a}/{b} = {a / b}", a / b);
        }
        static void mul(int a, int b)
        {
            Console.WriteLine($"mul {a}*{b} = {a * b}", a * b);
        }


        static void Main(string[] args)
        {
            // Delegate Chain
            CalChain cal =
                (CalChain)Delegate.Combine(
                    new CalChain(add),
                    new CalChain(sub),
                    new CalChain(mul));

            cal(100, 200);

            Console.WriteLine();
            cal += div;

            cal(20, 30);

            Console.WriteLine();
            cal -= div;

            cal(20, 30);

        }
    }
}
