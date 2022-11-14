using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_06
{
    class Person
    {
        string _name;

        public Person(string name)  //2. 생성자는 전달받은 값을 멤버변수인 _name에 보관해두고
                                    //이후에 클래스의 다릉 멤버 메서드에서 사용한다
        {
            _name = name;
        }

        public void WriteName()
        {
            Console.WriteLine("Name :"+_name);
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person();
            //개발자가 명시적으로 생성자를 정의한 경우 컴파일러는 기본 생성자를 추가하지 않는다.

            Person person = new Person("나은");   //1. new 를 통해 나은이라는 값을 생성자의 인자로 전달받는다
            person.WriteName();

        }
    }
}
