using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_04
{
    class Mathmathic
    {
        public void PrinfIfEven(int value)
        {
            if (value % 2 == 0)
            {
                Console.WriteLine(value);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args) //짝수를 판정하는 프로그램
        {
            //중복코드 제거

            int x = 5;
            if (x % 2 == 0)
            {
                Console.WriteLine(x);
            }

            x = 10;
            if (x % 2 == 0)
            {
                Console.WriteLine(x);   //출력결과 10
            }


            //해당 코드가 두 번 이상 중복된다면 무조건 메서드로 분리한다

            Mathmathic m = new Mathmathic();
            int y = 5;
            m.PrinfIfEven(y);

            y = 10;
            m.PrinfIfEven(y);

        }
    }
}
