using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //정수값의 변화에 따라 분기시킬 때 사용
            //C#에서는 문자열도 가능하다
            //C랑C++에서는 정수만 가능

            int button = 0;
            Console.WriteLine("버튼 번호를 입력하세요");
             button = int.Parse(Console.ReadLine());

            switch (button)
            {
                case 0: Console.WriteLine("TurnOn");
                    break;
                case 1: Console.WriteLine("Volume Up");
                    break;
                case 2:
                    {
                        //변수선언할 땐 중괄호 안에서 진행한다
                        int a = 20;
                    } 
                    Console.WriteLine("Volume Down");
                    break;
                default:Console.WriteLine("TurnDown");  //default는 생략 가능
                    break;
            }

            //가독성이 떨어지는 if-else-if
            if(button == 1)
            {

            }else if(button == 2)
            {

            }else if(button == 0)
            {

            }
            else
            {

            }
            


        }
    }
}
