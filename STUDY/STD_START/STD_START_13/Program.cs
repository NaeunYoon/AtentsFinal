using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_13
{/*
  정적 메서드
    일반 메서드에 static 예약어를 붙여서 정의한다
    정적 메서드 역시 new로 객체를 생성하는 것과 무관하게 사용할 수 있으므로
    클래스이름. 정적메서드 형태로 호출한다
  
  */

    class Person
    {
        static private int CountOfInstance;
        public string _name;

        public Person(string name)
        {
            CountOfInstance++;
            _name = name;
        }

        static public void OutputCount()    //public 정적 메서드
        {
            //정적 메서드 안에서는 인스턴스 멤버에 접근할 수 없다는 특징이 있다
            Console.WriteLine(CountOfInstance); //정적 메서드에서 정적 필드에 접근
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person.OutputCount();

            Person person1 = new Person("윤나은");

            Person.OutputCount();

            Person person2 = new Person("윤나은");

            Person.OutputCount();

            //Console.WriteLine(Person.CountOfInstance);
        }
    }
}
