using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Weekend15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int MatchValue = 0;

            Random random = new Random();   //난수발생용 객체 생성
            int randValue = random.Next();  //난수발생
            MatchValue = randValue%100;
            int count = 0;

        Start:;
            while (true)
            {
                Console.WriteLine("값을 입력하세요");
                int inputValue = Convert.ToInt32(Console.ReadLine());
                count++;
                if(inputValue > MatchValue)
                {
                    Console.WriteLine($"입력된{inputValue}의 값이 크다");
                    
                }else if( inputValue < MatchValue)
                {
                    Console.WriteLine($"입력된{inputValue}의 값이 작다");
                }
                else
                {
                    Console.WriteLine($"{count}횟수만에 맞췄습니다. 값은 {MatchValue}");

                    Console.WriteLine("계속하시겠습니까? 탈출 : exit 진행 : continue");

                    //string answer = Convert.ToString(Console.ReadLine());

                    //switch (answer)
                    //{
                    //    case "continue":
                    //         "Continue":
                    //            goto Start;
                           
                    //    case "exit":
                    //         "Exit":
                    //            goto Exit;

                    //    default:
                    //        goto Exit;
                    //}

                }
            
            }
        Exit:;
        }
    }
}
