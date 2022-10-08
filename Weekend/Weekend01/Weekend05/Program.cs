using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //증감연산자는 변수에 저장된 정수값을 증가시키거나 감소시킬 떄 사용 ( 정수값만 가능 )
            int a = 10;
            int b = 0;

            ++a;    //a = a+1
            Console.WriteLine(a);

            a++;    //a = a+1
            Console.WriteLine(a);

            b = ++a; //a = a+1, c=a;
            Console.WriteLine(b);

            b= a++; //c=a, a =a+1;
            Console.WriteLine(b);


        }
    }
}
