using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_20
{
    class Circle
    {
        double pi = 3.14;   //이런 경우, 변수 pi를 파일 내의 모든 함수에서 접근할 수 있다

        double GetAreaOfCircle(double radius)
        {
            return radius * radius * pi;
        }

        public void Print(double value)
        {
            Console.WriteLine(GetAreaOfCircle(value));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Circle o = new Circle();
            //o.pi = 6.28;    //접근불가
            //o.GetAreaOfCircle(10);  //접근불가
            o.Print(10);       //public 멤버이므로 호출 가능
        }
    }
}
