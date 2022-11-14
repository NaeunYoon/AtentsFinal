using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_29
{

    class Book
    {
        decimal _isbn;
        public Book(decimal isbn)
        {
            _isbn = isbn;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(987654321);
            Book book2 = new Book(987654321);
            //동일한 값을 소유한 참조 형식에 대해서 equals는 false를 반환한다
            Console.WriteLine(book1.Equals(book2));


            int n1 = 5;
            int n2 = 5;
            Console.WriteLine(n1.Equals(n2));

            n2 = 6;
            Console.WriteLine(n1.Equals(n2));

            string txt1 = new string (new char[] { 't', 'e', 'x', 't' });
            string txt2 = new string (new char[] {'t', 'e', 'x', 't' });
            Console.WriteLine(txt1.Equals(txt2));

            //GetHashCode : 특정 인스턴스를 고유하게 식별할 수 있는 4바이트 int 값을 반환한다 음...

            short a1 = 256;
            short a2 = 32750;
            short a3 = 256;

            Console.WriteLine(a1.GetHashCode());
            Console.WriteLine(a2.GetHashCode());
            Console.WriteLine(a3.GetHashCode());

            Book book01 = new Book(123);
            Book book02 = new Book(123);

            Console.WriteLine(book01.GetHashCode());
            Console.WriteLine(book02.GetHashCode());

            int b1 = 256;
            int b2 = 1234567;
            Console.WriteLine(b1.GetHashCode());
            Console.WriteLine(b2.GetHashCode());



        }
    }
}
