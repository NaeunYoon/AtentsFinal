using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace STD_START_27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ToString : 클래스의 전체 이름을 반환한다
            Program program = new Program();
            Console.WriteLine(program.ToString());

            int n = 500;
            double d = 3.141592;

            string text = "hello ";

            Console.WriteLine(text + n.ToString()); //값을 문자열로 반환한다
            Console.WriteLine(text + n); 
            Console.WriteLine(text + d.ToString());

            text = d.ToString();

            Console.WriteLine(text);

        }
    }
}
