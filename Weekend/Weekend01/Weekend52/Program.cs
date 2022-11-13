using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Weekend52
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Func 타입은 리턴값이 있는 경우
            Func<int> func1 = () => 10;

            Console.WriteLine(func1());

            Func<int, int> func2 = (int a) =>
            {
                return a;
            };
            //뒤에것이 리턴타입 
            Func<int, int, float> func3 = (int a, int b) =>
            {
                return (float)(a / b);
            };

            // Action 타입은 리턴값이 없는 경우
            Action act1 = () => Console.WriteLine("Action");

            Action<int, int> add = (int a, int b) =>
            {
                Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            };

            add(20, 30);


            Action<float, float, float> printFloat = (float a, float b, float c) =>
            {
                Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
            };

            printFloat(2.3f, 3.4f, 5.5f);

        }
    }
}
