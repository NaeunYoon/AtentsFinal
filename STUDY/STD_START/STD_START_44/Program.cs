using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_44
{
    public class Mathmatics
    {
        delegate int CalcDelegate(int X, int y);

        static int Add(int x, int y) { return x + y; }
        static int Sub(int x, int y) { return x - y; }
        static int Mul(int x, int y) { return x * y; }
        static int Div(int x, int y) { return x / y; }

        CalcDelegate[] method;
        
        public Mathmatics()
        {
            //static 메서드를 가리키는 델리게이트 배열 초기화
            method = new CalcDelegate[] { Mathmatics.Add, 
                                          Mathmatics.Sub,
                                          Mathmatics.Mul,
                                          Mathmatics.Div};
        }

        //method 배열에 담긴 델리게이트를 opCode 인자에 따라 호출
        public void Calculate(char opCode, int operand1, int operand2)
        {
            switch (opCode)
            {
                case '+': Console.WriteLine("+ :"+ method[0](operand1,operand2));
                    break;
                case '-': Console.WriteLine("- :" + method[1](operand1, operand2));
                    break;
                case '*': Console.WriteLine("* :" + method[2](operand1, operand2));
                    break;
                case '/': Console.WriteLine("/ :" + method[3](operand1, operand2));
                    break;
            }
        }
    }

    internal class Program
    {
            delegate void WorkDelegate(char arg1, int arg2, int arg3);
            

        static void Main(string[] args)
        {
            //3개의 매개변수를 받고 void 를 반환하는 델리게이트 정의
            //매개변수의 타입이 중요할 뿐 매개변수의 이름은 임의로 정할 수 있음

            Mathmatics math = new Mathmatics();
            WorkDelegate work = math.Calculate;

            work('+', 10, 5);
            work('-', 10, 5);
            work('*', 10, 5);
            work('/', 10, 5);

           


            /*
             델리게이트가 타입이라는 점은 중요하다. 이 떄문에 변수가 사용되는 곳이라면 델리게이트 또한 함께 사용된다
            1. 메서드의 반환값으로 델리게이트를 사용할 수 있다
            2. 메서드의 인자로 델리게이트를 전달할 수 있다
            3. 클래스의 멤버로 델리게이트를 정의할 수 있다

            1. 메서드의 반환값으로 메서드를 사용할 수 있다
            2. 메서드의 인자로 메서드를 전달할 수 있다
            3. 클래스의 멤버로 메서드를 정의할 수 있다
             
             */


        }
    }
}
