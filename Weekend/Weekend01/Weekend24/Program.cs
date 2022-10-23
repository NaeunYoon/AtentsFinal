using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend24
{
    class Math2
    {
        public int add(int a, int b)
        {
            return a + b;
        }

        public int sub(int a , int b)
        {
            return a - b;
        }
    }

    /*static*/ class Utility        //정적 클래스는 객체를 만들 수 없다
    {
        public static int add(int a, int b) //정적 멤버 메소드는 객체에 속해있지 않고 클래스에 속해있다
        {
            return a + b;
        }

        public static int sub(int a, int b)
        {
            return a - b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 30;

            Math2 math2 = new Math2();
            Console.WriteLine("{0} + {1} = {2}",a,b, math2.add(a,b));

            //정적 멤버 필드는 객체에 속해있지 않고 클래스에 속해있다
            //클래스를 통해서 접근하시면 됩니다
            Utility util = new Utility();
            Utility.sub(a,b);
            Console.WriteLine("{0} - {1} = {2}", a, b, Utility.sub(a, b));
        }
    }
}