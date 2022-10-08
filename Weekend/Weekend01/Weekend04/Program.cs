using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new System.Random();    //난수발생용 객체 생성

            int randomValue = random.Next();    //난수 발생

            Console.WriteLine("randomValue a = "+ randomValue);

            // % 나머지 연산자 : 임의의 값을 의미있는 범위의 숫자로 만들 떄
            // 0 : runaway 
            // 1 : attack
            // 2 : defense


            int a = 11 % 2;
            Console.WriteLine(a);

            int actionValue = randomValue % 3;

            switch (actionValue)
            {
                case 0: Console.WriteLine("Run Away");
                    break;
                case 1: Console.WriteLine("Attack");
                    break ;
                case 2: Console.WriteLine("Defense");
                    break;
            }


        }
    }
}
