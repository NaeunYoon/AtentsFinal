using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_11
{/*
  1. 필드 정의에 static 예약어가 붙는다
  2. 클래스 밖에서 이 필드를 사용할 때 클래스이름. 정적필드 형태로 접근한다
  3. 정적 필드의 값은 new 로 할당된 인스턴스와 상관 없이 존재한다
  
  */
    class Person
    {
        static public int CountOfInstance;  //static 예약어로 정적 필드를 만든다
        public string _name;    //인스턴스 필드

        public Person(string name)
        {
            CountOfInstance++;
            _name = name;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Person.CountOfInstance);

            Person person1 = new Person("윤나은");
            Console.WriteLine(Person.CountOfInstance);
            Person person2 = new Person("윤나은");

            Console.WriteLine(Person.CountOfInstance);

            
        }
    }
}
