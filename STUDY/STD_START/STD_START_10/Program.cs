using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_10
{
    /*
     인스턴스와 관계 없는 행동을 정의해야 할 떄,
    개별 인스턴스 수준이 아닌 해당 인스턴스의 타입 전체에 걸쳐 
    전역적으로 적용되는 필드 메서드 생성자가 필요할 수 있는데
    이러한 멤버를 인스턴스 멤버와 구분해 정적 멤버라고 한다.
     
     */

    class Person
    {
        public int CountOfInstance;
        public string _name;

        public Person(string name)  //클래스의 객체가 생성될 때 마다 횟수를 증가시키는 필드 정의
        {
            CountOfInstance++;  //생성자에서 필드값 증가
            _name = name;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("윤나은");
            Console.WriteLine(person1.CountOfInstance); //결과 1

            Person person2 = new Person("윤나은");
            Console.WriteLine(person2.CountOfInstance); //결과 1
        }
        //인스턴스 필드는 new로 할당받은 객체마다 고유하게 메모리를 확보하기 때문에,
        //클래스 전역으로 값이 유지되지 않는다
    }
}
