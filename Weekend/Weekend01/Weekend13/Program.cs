using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = 0;

        Start:; //레이블 : 프로그램의 실행 위치를 나타낸다 c#에서는 세미콜론을 찍어줘야한다 (c,c++은 필요없음)
            //중첩되어있는 반복문을 탈출할 때 주로 사용하지만 안쓰는게 가장 좋음
            //조건도 없이 레이블로 보냄

            Console.WriteLine("값을 입력하세요");
            value = Convert.ToInt32(Console.ReadLine());

            if(value <= 0)
            {
                goto Exit;      //하향식 분기(exit으로 이동)
            }
            Console.WriteLine($"{value}값이 10보다 크거나 같아서 다시");
            
            goto Start; //상향식분기 (start로 이동)

            Console.WriteLine("절대 실행 안됨");

        Exit:;
            Console.WriteLine($"{value}값이 10보다 작아서 탈출");
        }
    }
}
//Console.WriteLine : 줄바꿈
//Console.Write : 줄바꿈안함

