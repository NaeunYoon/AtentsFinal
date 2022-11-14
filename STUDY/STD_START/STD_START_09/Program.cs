using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_09
{/*
  인스턴스 : 어떤 타입을 실체화한 객체, new 연산자를 거쳐서 메모리에 할당된 객체   
  인스턴스 멤버 : 그 객체와 관련된 멤버 ( 필드, 메서드, 생성자)
  
  */

    class Person
    {
        public string _name;

        public Person(string name)  //생성자
        {
            _name = name;
        }

        public void OutputYourName()    
        {
            Console.WriteLine(_name);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("윤나은");  //new를 통해 인스턴스 생성자에 접근
            person.OutputYourName();    //new로 생성된 객체의 인스턴스 메서드를 호출
            Console.WriteLine(person._name);    //new로 생성된 객체의 인스턴스 필드에 접근
        }
    }
}
