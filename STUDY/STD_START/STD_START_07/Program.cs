using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_07
{
    class Book
    {
        public string Title;
        public decimal ISBN13;
        public string Author;

        public Book(string title)   //생성자1
        {
            Title = title;
        }

        public Book(string title, decimal isbn13)   //생성자2
        {
            Title = title;
            ISBN13 = isbn13;
        }
        public Book(string title, decimal isbn13, string author)    //생성자3
        {
            Title = title;
            ISBN13 = isbn13;
            Author = author;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //개발자는 각 생성자를 상황에 따라 골라 쓸 수 있다
            Book gulliver = new Book("걸리버 여행기");
            Book huckleberry = new Book("허클베리 핀의 모험", 989484847);
            Book alice = new Book("이상한 나라의 엘리스", 8440302, "Lewis Carroll");
        }
    }
}
