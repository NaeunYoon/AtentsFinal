using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_08
{
    class Book
    {
        public Book()   //생성자 생성
        {

        }

        ~Book() //종료자 호출
        {
            //자원을 해제한다
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //종료자 : 해당 객체가 제거되는 시점에 실행되는 종료자
        }
    }
}
