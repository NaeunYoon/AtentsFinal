using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = 3.14;   //이런 경우, 변수 pi를 파일 내의 모든 함수에서 접근할 수 있다

            double GetAreaOfCircle(double radius)
            {
                return radius*radius*pi;
            }

            void Print(double value)
            {
                Console.WriteLine(GetAreaOfCircle(value));
            }

            Print(10);  //다른 파일에서 print 함수만 쓰도록 강제할 수 없다
        }
    }
}
