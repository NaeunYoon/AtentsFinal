using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_Class
{
    class Book
    {
        //필드 : 정의된 속성 ( 객체에 속한 변수, 멤버변수라고 한다 )
        //객체의 필드는 외부에서 접근할 수 없기 때문에 예약어 public을 붙여준다
        public string Title;
        public decimal ISBN13;
        public string Contents;
        public string Author;
        public int PageCount;

        public void Open()
        {
            Console.WriteLine("Book is opened");
        }

        public void Close()
        {
            Console.WriteLine("Book is closed");
        }

    }

    class Mathmatics    //제곱함수 만들기
    {
        public int f(int x) //매개변수
        {
            return x * x;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Book gulliver = new Book();
            //클래스로 정의된 타입은 string 처럼 참조형으로 분류되므로
            //Book 타입을 사용하려면 new 연산자로 메모리를 할당

            //필드에 값을 대입
            // 객체.필드명 = 필드의 타입과 일치하는 표현식

            gulliver.Author = "Jonathan Swift";
            gulliver.ISBN13 = 9788983920775m;
            gulliver.Title = "걸리버 여행기";
            gulliver.Contents = "...";
            gulliver.PageCount = 384;

            //필드로부터 값을 가져옴
            //필드의 타입과 일치하는 변수 = 객체.필드명

            string author = gulliver.Author;
            decimal isbn13 = gulliver.ISBN13;  
            string title = gulliver.Title;
            string contents = gulliver.Contents;
            int pageCount = gulliver.PageCount;

            
            Mathmatics m = new Mathmatics();
            int result = m.f(5);    //인자
            Console.WriteLine(result);

        }
    }
}
