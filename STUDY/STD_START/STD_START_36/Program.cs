using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_36
{
    /*
     base를 이용한 메서드 재사용

     
     */

    class Computer
    {
        virtual public void Boot()
        {
            Console.WriteLine("메인보드 켜기");
        }
    }

    class Notebook : Computer
    {
        public override void Boot()
        {
            //Console.WriteLine("메인보드 켜기");
            base.Boot();    //중복제거
            Console.WriteLine("액정 화면 켜기");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("computer\n");
            Computer computer = new Computer();
            computer.Boot();
            Console.WriteLine("\nnotebook");
            Notebook notebook = new Notebook();
            notebook.Boot();
        }
    }
}
