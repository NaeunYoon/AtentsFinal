using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_53
{
    /*
     인터페이스 : 구현 없이 메서드 선언만 포함
                  메서드 선언을 0개 이상 포함할 수 있다.
                  인터페이스 이름에는 I 접두사를 붙인다
                  추상메서드만 0개 이상 담고 있는 추상클래스
     
    추상클래스로 구현할 수 있는 것을 왜 굳이 interface 라는 새로운 예약어를 만들어 표현할까?
    => 클래스는 다중상속이 불가능하다 라는 특징으로 설명할 수 있다.
    => 추상클래스는 다중상속을 할 수 있지만, 인터페이스는 클래스가 아니기 때문에 다중상속이 허용된다
     */

    abstract class Weekend  //추상클래스
    {
        public abstract void Saturday();
        public abstract void Sunday(int year);
    }

    interface IWeekend  //인터페이스
    {
        void Saturday();
        void Sunday(int year);
    }
    //------------------------------------------------------------------

    class Product
    {

    }
    interface ILaptop   //메서드 시그니처만을 포함하고 있는 인터페이스
    {
        void TurnOn();
    }

    interface INetBook  //비어있는 인터페이스 정의 가능
    {

    }

    class LapTop : Product, ILaptop, INetBook   //클래스 상속과 함꼐 인터페이스로부터 다중상속 가능
    {
        public void TurnOn() { }    //추상메서드와는 달리 override 예약어가 필요 없음
                                    //인터페이스의 메서드를 자식 클래스에서 구현 할 때에는 반드시 public 
    }


    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
