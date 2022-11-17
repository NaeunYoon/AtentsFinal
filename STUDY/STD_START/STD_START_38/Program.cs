using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_38
{
    class Book
    {
        decimal isbn13;
        string title;
        string contents;

        public Book(decimal isbn13, string title, string contents)  //생성자
        {
            this.isbn13 = isbn13;
            this.title = title;
            this.contents = contents;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Book book = obj as Book;
            if (book == null)
            {
                return false;
            }
            return this.isbn13 == book.isbn13;
        }

        public override int GetHashCode()
        {
            return this.isbn13.GetHashCode();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(987654321, "리버스 엔지니어링 바이블", "윤나은");
            Book book2 = new Book(987654321, "리버스 엔지니어링 바이블", "윤나은");
            Book book3 = new Book(987654320, "해리포터", "윤나은\n");

            Console.WriteLine("book1==book2 : " + book1.Equals(book2));
            Console.WriteLine("book1==book3 : " + book1.Equals(book3));

            Console.WriteLine(book1.GetHashCode());
            Console.WriteLine(book2.GetHashCode());
            Console.WriteLine(book3.GetHashCode()); //해쉬코드 다름

            //해당 key가 될 요소 (isbn) 을 적절하게 찾는다면, equals와 gethashcode는 자연스럽게 만들어질 수 있다
        }
    }
}
