using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_40
{/*
  연산자 오버로드
  
  */

    public class Kilogram
    {
        double mass;
        public Kilogram(double value)   //생성자
        {
            this.mass = value;
        }

        public Kilogram Add(Kilogram target)
        {
            return new Kilogram(this.mass + target.mass);   //..?
        }

        public override string ToString()   //자동으로 붙음
        {
            return mass + "kg";
        }
        public static Kilogram operator + (Kilogram op1, Kilogram op2)//...1. 메서드 유형이 정적으로 바뀌었고
                                                                      //2. operator 예약어와 함꼐 + 연산자 기호가 메서드 이름을 대신한다
                                                                      //??operator + : 함수명
        {
            return new Kilogram(op1.mass + op2.mass);   //kg 클래스의 객체를 반환

            //생성자 : 객체가 처음 생성될 때 호출되어 멤버 변수를 초기화하고, 필요에 따라 자원을 할당하기도 한다
            //op1의 mass값과 op2의 mass값을 더한 값을 생성자로 갖는 킬로그램 객체를 반환한다
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = 5;
            int n2 = 10;
            int sum = n1 + n2;
            Console.WriteLine(sum);

            string txt1 = "123";
            string txt2 = "456";
            Console.WriteLine(txt1+txt2);

            //------------------------------

            Kilogram kg1 = new Kilogram(5);
            Kilogram kg2 = new Kilogram(10);

            Kilogram kg3 = kg1.Add(kg2);    //..? 어우.. 15kg
            Console.WriteLine(kg3);

            Kilogram kg4 = kg1 + kg2;
            Console.WriteLine(kg4);


        }
    }
}
