using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_03
{
    class Write //메서드를 실행하는 중간에 return문을 사용해 실행순서를 제어한다
    {
        public void WriteIF(bool output, string txt)
        {
            if(output == false)
            {
                return;
            }
            Console.WriteLine(txt);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Write w = new Write();
            w.WriteIF(true, "나은");
        }
    }
}
