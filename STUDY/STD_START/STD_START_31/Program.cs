using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_31
{
    class BOOK
    {
        decimal _isbn;
        public decimal ISBN //프로퍼티 
        {
            get { return this._isbn; }
        }

        public BOOK(decimal isbn)   //생성자
        {
            this._isbn = isbn;  //this를 생략하면 메서드의 매개변수인 isbn 변수가 사용된다.
        }

        public decimal GetISBN()    //함수
        {
            return this._isbn;
        }
        public void Sell()  //함수
        {
            Console.WriteLine("sell : " + this.GetISBN());
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //THIS! : 외부에서 자신을 식별할 수 있는 변수를 갖는다
            //클래스 내부의 코드에서 객체 자신을 가리킨다.
            //메서드 내에서 멤버변수에 접근할 때, 그것이 멤버변수임을 명확히 인식할 수 있게 this를 명시한다
        }
    }
}
