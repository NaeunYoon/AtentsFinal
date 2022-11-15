using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_34
{/*
  BASE : 부모클래스를 명시적으로 가리키는 데 사용된다 
  */
    #region computer
    public class Computer
    {
        bool powerOn;
        public void Boot() { }
        public void ShutDown() { }
        public void Reset() { }
    }

    public class NoteBook : Computer
    {
        bool fingerScan;
        public bool HasFingerScanDevice() { return fingerScan; }
        public void CloseLid()
        {
            base.ShutDown();    //base 예약어를 명시
        }
    }
    #endregion
    #region book
    class Book
    {
        decimal isbn13;
        public Book(decimal isbn)   //생성자
        {
            this.isbn13 = isbn;
        }
        public Book()
        {
            
        }
    }

    class EBook : Book
    {
        public EBook() : base(0) //생성자
        {
            //자식클래스를 생성한다는 것은 부모 클래스의 생성자도 함께 호출한다는 의미.
            // 자식클래스는 부모클래스의 private 멤버에 접근할 수 없으므로 초기화가 불가능하다..
            //자식 클래스가 생성되는 시점에 부모 클래스의 생성자를 호출해야 하는데 기본생성자가 부모클래스에 없기 때문
        }
        public EBook(decimal isbn) : base(isbn) //또는 이렇게 값을 연계해도 됨
        {
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
