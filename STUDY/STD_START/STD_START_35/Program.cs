using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_35
{
    /*
     * 객체지향의 4대 특성 : 추상화 캡슐화 상속 다형성
     다형성 : 여러가지 형태를 띈다 / 메서드 오버라이드 , 메서드 오버로드
        오버라이드 : (virtual/override)부모에서 정의한 동작에 대해 자식클래스의 인스턴스에 따라 다양하게 재정의되고,
                     형변환이 되어도 특징이 유지된다
     
     */

    class Mammal
    {
        virtual public void Move()  //virtual 예약어
        {
            Console.WriteLine("Mammal : 이동한다\n");
        }
    }

    class Lion : Mammal
    {
        override public void Move() //override 예약어
        {
            Console.WriteLine("Lion : 네 발로 움직인다\n");
        }

        //new public void Move()
        //{
        //    //같은 이름의 메서드를 일부러 겹쳐서 정의했다는 의도를 표현할 수 있도록 new예약어를 제공한다
        //    //단순히 자식클래스에서 동일한 이름의 메서드가 필요하다면 new 를 쓴다.
        //}

    }

    class Whale : Mammal
    {
        override public void Move() //override 예약어
        {
            Console.WriteLine("Whale : 수영한다\n");
        }
    }

    class Human : Mammal
    {
        override public void Move() //override 예약어
        {
            Console.WriteLine("Human : 걷는다\n");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Mammal();
            mammal.Move(); //이동한다

            Lion lion = new Lion();
            lion.Move();    //네발로 움직인다

            Whale whale = new Whale();
            whale.Move();   //수영한다

            Human human = new Human();
            human.Move();   //걷는다

            //-------------------------------자식이 부모 타입으로 암시적 형변환이 된 경우
            Console.WriteLine("virtual\n");
            Mammal one = lion;
            one.Move();     //이동한다 가 나옴.
                            //부모타입으로 형변환되긴 했지만 원래의 인스턴스 자체는 lion타입이므로 의도했던 동작이 아니다
                            //따라서 virtual이라는 예약어를 부모클래스 단위에서 명시하면 된다
                            //=> 네 발로 움직인다

            Mammal two = human;
            two.Move();
        }
    }
}
