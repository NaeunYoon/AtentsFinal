using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_12
{/*
    이렇게 인스턴스가 단 하나만 존재하는 타입을 싱글톤 클래스라고 하며,
    단일 시스템 자원을 책임지는 타입이 필요할 때, 싱글톤 클래스를 만들어 다른 클래스에
    기능을 노출하는 용도로 사용한다
  
  */
    class Person
    {
        static public Person President = new Person("윤나은"); //public 정적필드

        string _name;

        private Person(string name) //private 인스턴스 생성자
        {
            _name = name;
        }

        public void DisplayName()   //public 인스턴스 메서드
        {
            Console.WriteLine(_name);
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person.President.DisplayName(); //대통령
            //Console.WriteLine(Person.President.DisplayName);

            //Person person1 = new Person("윤나은");
            //보호수준떄문에 접근할 수 없다 ( 생성자가 private 이므로 오류 발생)
        }
    }
}
