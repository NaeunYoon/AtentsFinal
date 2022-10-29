using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Weekend34
{/*
  기존에 클래스들이 이렇게 있음 ( 회사가 가지고 있는 라이브러리)
    만들고 있는 클래스들을 내가 사용한다고 예를 든다
    유용한데 내가 생각하기엔 나눗셈이 없어서 불편하다고 생각한다
    기존에 지원하고 있는 기능에다가 div 기능이 없다면 상속을 할 수 있다
    기존에 만들어진 클래스를 이용해서 기능의 확장적인 면을 줄 수 있다
  
  */
    //class Math2
    //{
    //    int add(int a, int b)
    //    {
    //        return a + b;
    //    }

    //    int mul(int a, int b)
    //    {
    //        return a * b;
    //    }

    //    int sub(int a, int b)
    //    {
    //        return a - b;
    //    }
    //}


    class Math3 : math2.Math2   //이렇게 상속을 시킬 수 있다는 말
    {
        public float div(int a, int b)
        {
            return a / (float)b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 30;

            math2.Math2 math2 = new math2.Math2();

            int ret = math2.add(a, b);
            Console.WriteLine($"{a}+{b}={ret}");

            Math3 math3 = new Math3();  //math3는 상속받았기 때문에 나눗셈을 할 수 있음
                                        //기존에 만든 클래스에서 기능을 확장한다
            float ret1 = math3.div(a, b);
            Console.WriteLine($"{a}/{b}={ret1}");
        }
    }
}
