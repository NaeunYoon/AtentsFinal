using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_32
{
    class Book
    {
        string title;
        decimal isbn13;
        string author;

        static int count;   //정적필드***

        public Book(string title) : this(title,0)  //생성자1
        {
        }

        public Book(string title, decimal isbn13) : this(title,isbn13,string.Empty)  //생성자2
        {
        }
        public Book(string title, decimal isbn13, string author)    //생성자3 (초기화 코드를 하나의 생성자에서 처리)
        {
            this.title = title;
            this.isbn13 = isbn13;
            this.author = author;
        }
        public Book() : this(string.Empty, 0, string.Empty) //생성자 4
        {
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //인스턴스 멤버와 정적 멤버의 차이는 this 예약어를 사용할 수 있느냐 없느냐로 나눌 수 있다.
            //this는 new로 할당된 객체를 가리키는 내부 식별자 이므로, 클래스 수준에서 정의되는 정적 멤버는 this를 사용할 수 없다
        }
    }
}
