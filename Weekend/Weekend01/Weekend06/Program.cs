using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;  
            a = 20;     //할당연산자(c에서는 대입연산자 라고 함)
            a = (int)1.2;   //다른 데이터 타입 간에는 명시적으로 형변환을 해야 한다

            int b = 1;
            float c = 1.2f;
            double d = 3.4;
            string e = "monster";
            decimal f = 1.234M;

            object obj = e;     //모든 데이터 타입을 받는 자료형 object
            Console.WriteLine(obj);

            obj = c;
            Console.WriteLine(obj);

            obj = b;
            Console.WriteLine(obj);

            obj = f;
            Console.WriteLine(obj);

        }
    }
}
