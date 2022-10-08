using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //관계연산자 : 두 값의 크기를 비교할 때 사용. 결과값의 데이터 타입은 논리값 bool

            int a = 20;
            int b = 30;

            bool ret = a < b;
            ret = a > b;
            ret = a <= b;
            ret = a >= b;
            ret = a != b;

            Console.WriteLine($"{ret} = {a} != {b}");

            int x = 5;
            ret = x > 0 && x < 10;
            Console.WriteLine($"{ret}");

            if (ret)
            {
                Console.WriteLine("x가 0과 10 사이에 있다");
            }
            else
            {
                Console.WriteLine("x가 0과 10 사이에 없다");
            }

        }
    }
}
