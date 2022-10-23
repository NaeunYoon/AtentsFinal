using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend25
{
    class Math2
    {


    }

    internal class Program
    {
        static void add(int a, int b, ref int c)    //매개변수
                                                    //ref : 참조값을 전달 (변수의 주소값을 전달해서..변수의 공간에 접근할 수 있도록 처리)
        {
            c = a + b;
        }

        static void sub(int a, int b, out int c)    //매개변수
                                                    //ref : 참조값을 전달 (변수의 주소값을 전달해서..변수의 공간에 접근할 수 있도록 처리)
        {
            c = a + b;
        }


        static void swapValue(ref int a, ref int b)     //주소값이 전달됨 => 주소를 가지고 변수의 공간에 전달
                                                        //a 는 a변수, b는 b변수로 접근한거 ㅇㅇ..
        {
            int temp = a;   //a변수에 있는 값 20이 temp에 들어감
            a = b;  //b변수에 있는 값을 a에다가 넣음
            b = temp;   //temp에 있는 값을b에다가 넣음
        }


        static void Main(string[] args)
        {
            int a = 20; //기본 데이터 타입 : 값타입 (스택)
            int b = 30;
            int ret = 0;    //ref 키워드는 변수를 참조할 땐 전달하는 변수의 값을 초기화를 해줘야함
            int retOut;     //out 키워드로 변수 참조할때는 변수의 값을 초기화 하지 않아도 됩니다.

            add(a, b, ref ret); //인자값
            Console.WriteLine("ref = "+ ret);
            Console.WriteLine("a = {0}, b = {1}", a, b);

            sub(a, b, out retOut); //인자값
            Console.WriteLine("ref = "+ retOut);
            Console.WriteLine("a = {0}, b = {1}", a, b);

            Console.WriteLine("a = {0}, b = {1}", a, b);
            swapValue(ref a, ref b);
            Console.WriteLine("a = {0}, b = {1}", a, b);
        }
    }
}
