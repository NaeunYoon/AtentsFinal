using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_39
{
    /*
     메서드의 정의 : 이름 반환타입 매개변수의 수 개별 매개변수 타입 => 서명
                     메서드가 같다 = 메서드의 시그니처가 동일하다
     오버로드 : 

     */

    class Mathmathics
    {
        public int AbsInt(int value)
        {
            return (value >=0) ? value : -value;    //흠.... 이게 뭘까..
        }

        public double AbsDouble(double value)
        {
            return (value >= 0) ? value : -value;
        }

        public decimal AbsDecimal(decimal value)
        {
            return (value >= 0) ? value : -value;
        }
        //----------------------------------오버로드----------------
        //
        public int Abs(int value)
        {
            return (value >= 0) ? value : -value;
        }
        public double Abs(double value)
        {
            return (value >= 0) ? value : -value;
        }
        public decimal Abs(decimal value)
        {
            return (value >= 0) ? value : -value;   //프라이머리 물음표 듣고싶다
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Mathmathics math = new Mathmathics();
            Console.WriteLine(math.Abs(-5));    //int
            Console.WriteLine(math.Abs(-10.052));   //double
            Console.WriteLine(math.Abs(20.01m));    //decimal

        }
    }
}
