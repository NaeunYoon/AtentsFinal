using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_16
{
    /*
     정적 생성자 : 기본 생성자에 static 예약어를 붙인 경우로, 클래스에 단 한개만 존재
                   주로 정적 멤버를 초기화하는 기능을 하기 때문에 형식 이니셜라이저 라고 한다
                   정적 생성자는 단 한 개만 정의할 수 있고 매개변수를 포함할 수 없다
                   클래스의 어떤 멤버든 최초로 접근하는 시점에 단 한번만 실행된다
                   처음 호출할 경우이거나 인스턴스 생성자를 통해 객체가 만들어지는 시점이 되면 우선적으로 실행된다    
     */

    class Person
    {
        static public Person President;

        public string _name;

        private Person(string name)
        {
            _name = name;
        }

        static Person()
        {
            President = new Person("윤나은"); //정적 필드 초기화
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("");
            Console.WriteLine(Person.President._name);
            Console.WriteLine(Person.President);
        }
    }
}
