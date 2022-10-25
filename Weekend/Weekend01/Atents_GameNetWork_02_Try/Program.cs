using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_02_Try
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[4];
            try
            {
                Console.WriteLine("문자열을 입력하세요");
                string userInput = Console.ReadLine();
                if (userInput.Contains("!"))
                {
                    throw new Exception("사용자 입력에 ! 가 있습니다");    //예외 발생해서 아래 구문은 실행할 이유가 없음
                }
                    array[0] = 100;
                    array[4] = 200;

                    Console.WriteLine(array[4]);
                    Console.WriteLine("try");
                
            }
            //모든 예외에 대한 처리를 하고 싶다면?
            catch(Exception ex)
            {
                //모든 예외에 대한 처리
                Console.WriteLine("exception 실행");
                Console.WriteLine(ex.Message);
            }
            //catch(IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("배열 범위를 벗어남");
            //    Console.WriteLine(e.Message);   //예외 메시지 출력
            //    //return;   //문법적으로 리턴해도 문제는 없지만 이런식으로 쓰진 않는다
            //    //예외가 발생한 기록을 해놓는 용도로 쓰기 때문임
            //    Console.WriteLine("catch");
            //}
            finally //생략가능 ( 에러를 발생시키지 않아도 실행된다)
            {
                //exception
                Console.WriteLine("finally");
            }
            Console.WriteLine("프로그램 종료");
        }
    }
}
