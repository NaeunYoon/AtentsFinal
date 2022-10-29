using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend33
{/*
    상속은 하나의 도구이다.
    클래스를 만들다가 비슷한것들이 있으면 상속시키는 방법이 있고
    클래스 하나로 작업을 하다보니 클래스가 커져서 비효율적이라면 특수한 부분을 내려서 자식으로 상속시킨다
    상속을 시키면 재사용성이 높아진다 : 일반적인건 부모에서 갖다씀
    그러다보니까 유지보수성이 좋아지고
    나중에 배울 다형성에 기반 구조를 제공한다
    또한 기능의 확장 부분이 있움 

    a클래스에서 b c d 등의 자식을 만들 수 있는데
    부모의 타입으로 자식을 받을 수 있음
    부모타입으로 자식타입을 받는 것을 업캐스팅 이라고 한다

    반대로 부모의 타입을 자식 타입으로 받는 것을 다운캐스팅 이라고 한다
    기본적으로 다운캐스팅은 안된다 ( 자식타입으로 부모를 못받는다)
    허용되는 때가 있긴 한데 기본적으로는 안됨



  */
    class Parent
    {
        private int _value;

        public Parent(int value)            //생성자
        {
            _value = value;
        }

        public void Print()
        {
            Console.WriteLine("A :: Print() {0}",_value);
        }
    }

    class Child1 : Parent
    {
        private int _value;

        public Child1(int value1, int value2) : base(value1) //생성자
        {
            _value = value2;
        }

        public new void Print()
        {
            Console.WriteLine("Child :: Print() {0}",_value);
        }

    }

    class Child2 : Parent
    {
        private int _value;

        public Child2(int value1, int value2) : base(value1) //생성자
        {
            _value = value2;
        }

        public new void Print()
        {
            Console.WriteLine("Child :: Print() {0}", _value);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Child1(10, 200);    //이거 자식타입인데 자식타입을 부모의 타입으로 받은게 업캐스팅 이라고 하ㅐㄴ다
            parent.Print();

            parent = new Child2(20, 300);   //이것도 업캐스팅임
                                            //이렇게 부모타입을 가지고 자식으로 받을 수 있음

            parent.Print(); //이러면 child2가 들어감 ㅇㅇ

            Child2 child2 = (Child2)parent; //이런 경우에는 다운캐스팅이 허용이 됨
            child2.Print();


            Parent parent3 = new Parent(1000);

            Child1 child3 = new Child1(30, 500);

            //child1 = parent3;       //이건 다운캐스팅인데 부모 타입을 자식으로 받는 것

        }
    }
}
