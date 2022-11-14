using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_05
{
    class Person
    {
        string name;

        //매개변수가 없는 생성자
        //반환타입이 없고 클래스 이름과 동일한 public person 메서드를 정의해두면
        //코드에서 new person을 실행하는 시점에 해당 메서드의 코드가 실행된다
        public Person()
        {
            name = "윤나은";
            Console.WriteLine("생성자 호출");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("person 객체 생성되기 전");
            Person person = new Person();
            Console.WriteLine("person 객체 생성된 후");
        }
    }
}
