using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_33
{
    class Book
    {
        string title;   //인스턴스 필드
        static int count;   //정적 필드***
        public Book(string title)   //인스턴스 생성자
        {
            this.title = title; //this로 인스턴스 필드 식별 가능
            this.Open();    //this로 인스턴스 메서드 식별 가능
            Increment();    //정적 메서드 사용 가능
        }

        public void Open() //인스턴스 메서드
        {
            Console.WriteLine(this.title + "읽기");
            Console.WriteLine(count);
        }

        public void Close()    //인스턴스 메서드
        {
            Console.WriteLine(this.title + "책을 덮는다");
        }
        static void Increment() //정적 메서드
        {
            count++;    //정적 필드 사용 가능,
                        //정적 메서드에는 this가 없으므로 인스턴스 멤버 사용 불가능
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("해리포터");
            book.Open();
            book.Close();
            

        }
    }
}
