using System;   // = #include<stdio.h>
using SAMSUNG.Develop1;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using LG; //네임스페이스를 안적으려면 유징해야함
//using SAMSUNG; //네임스페이스를 안적으려면 유징해야함

namespace LG
{
    class Math2
    {
        public void info()
        {
            Console.WriteLine("LG :: Math :: Info()");
        }
    }
}

namespace SAMSUNG
{
    class Math2
    {
        public void info()
        {
            Console.WriteLine("SAMSUNG :: Math :: Info()");
        }
    }
}


namespace Weekend01     
    //네임스페이스 지정 : 프로젝트 내에 동일한 클래스 명, 함수가 있을 수 없음, (c++은 동일한 함수 가능)                 
    //이름충돌 문제를 해결하기 위해 만듬. 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LG.Math a;
            //SAMSUNG.Math b;

            Math2 a = new Math2();
            SAMSUNG.Math2 b = new SAMSUNG.Math2();
            SAMSUNG.Develop1.Test c = new SAMSUNG.Develop1.Test();

            a.info();
            b.info();
            c.info();

            byte d;
            d = 10;
            Console.WriteLine(d);
        }
    }
}
