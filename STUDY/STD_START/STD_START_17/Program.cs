using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_17
{

    class Person
    {

        public string _name;

        public Person(string name)  //생성자
        {
            _name = name;
            Console.WriteLine("ctor 실행");
        }

        static Person() //정적 생성자
        {
            Console.WriteLine("cctor 실행");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("");
            Console.WriteLine("-------------");
            Person person2 = new Person("");

            //정적 멤버를 처음 호출할 경우거나 인스턴스 생성자를 통해 객체가 만들어지는 시점이 되면
            //우선적으로 실행된다 (최초로 접근하는 시점에 단 한번만 실행)

        }
    }
}
