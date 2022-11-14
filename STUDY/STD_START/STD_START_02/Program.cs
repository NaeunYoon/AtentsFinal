using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_02
{
    class Mathmatics
    {
        public int GetAreaOfSquare(int x)
        {
            return x * x;
        }

        public int GetValue()   //매개변수는 없고 값만 반환
        {
            return 10;
        }

        public void OutPut(string prefix, int value)
        {
            Console.WriteLine(prefix + value);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Mathmatics m = new Mathmatics();
            int result = m.GetAreaOfSquare(m.GetValue());

            m.OutPut("결과 : ",result);   //출력결과 : 100
        }
    }
}
