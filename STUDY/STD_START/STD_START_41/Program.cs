using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_41
{
    /*
     클래스간의 형변환
     
     */

    public class Currency
    {
        decimal money;
        public decimal Money    //프로퍼티
        {
            get { return money; }
        }

        public Currency(decimal money)  //생성자
        {
            this.money = money;
        }
    }

    public class Won : Currency
    {
        public Won(decimal money) : base(money)
        {

        }

        public override string ToString()
        {
            return Money + "Won";
        }
    }

    public class Dollar : Currency
    {
        public Dollar(decimal money) : base(money)
        {

        }

        public override string ToString()
        {
            return Money + "Dollar";
        }

        static public explicit operator Won(Dollar dollar)
        {
            return new Won(dollar.Money * 1000m);   //개발자가 의도한 형변환만 가능하도록 제한한다
                                                    //: 반드시 형변환 연산자를 사용해야만 won 타입으로 변경할 수 있다
        }
    }

    public class Yen : Currency
    {
        public Yen(decimal money) : base(money)
        {

        }
        public override string ToString()
        {
            return Money + "Yen";
        }

        static public implicit operator Won(Yen yen)    //*****************************************************************
        {
            return new Won(yen.Money * 13m);    //1엔당 13원으로 가정,
                                                //implicit operator를 overrode 했으므로 암시적 형변환을 할 수 있고,
                                                //암시적인 형변환이 가능하므로 명시적으로 캐스팅 연상자를 쓰는것도 허용된다 
        }
    }

    


    internal class Program
    {
        static void Main(string[] args)
        {
            Won won = new Won(1000);
            Dollar dollar = new Dollar(1);
            Yen yen = new Yen(13);

            //won = yen;    yen과 won의 타입이 다르기 떄문에 컴파일 시에 오류 발생
            //나는 yen을 won에 대입하고 싶기 때문에 implicit연산자를 사용할거임

            //---------------------------------static public implicit operator Won(Yen yen) 사용

            Yen yen1 = new Yen(100);
            Won won1 = yen1;     //암시적(implicit) 형변환
            Won won2 = (Won)yen1;    //명시적(explicit) 형변환
            Console.WriteLine(won1);    //출력결과 1300won
            Console.WriteLine(won2);    //출력결과 1300won

            //---------------------------------static public explicit operator Won(Dollar dollar) 사용

            Dollar dollar1 = new Dollar(1);
            /*Won won3 = dollar1;*/     //암시적(implicit) 형변환 (컴파일 오류 발생)
            Won won4 = (Won)dollar1;    //명시적(explicit) 형변환
            /*Console.WriteLine(won3);*/    //출력결과 : 1000won
            Console.WriteLine(won4);    //출력결과 : 1000won

            // + kilogram 예제에서 gram 타입을 추가하고 그램 단위와 킬로그램 단위를 서로 변환할 수 있는 코드를 추가하기.


        }
    }
}
