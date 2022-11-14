using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_28
{
    public class Computer
    {
        bool isPowerOn;
        public void Boot() { }
        public void ShutDown() { }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //GetType : class로 타입을 정의하면, 타입의 정보를 가지고 있는 인스턴스를 보유한다
                       //클래스의 인스턴스로부터 타입을 구한다

            Computer com = new Computer();
            Type type = com.GetType();

            Console.WriteLine(type.FullName);
            Console.WriteLine(type.IsClass);
            Console.WriteLine(type.IsArray);


            int n = 5;
            string txt = "text";

            Type intType = n.GetType();
            Console.WriteLine(intType.FullName);
            Console.WriteLine(txt.GetType().FullName);


            //typeof : 클래스의 이름(? 에서 곧바로 타입을 구한다

            Type type1 = typeof(double);
            Console.WriteLine(type1.FullName);

            Console.WriteLine(typeof(System.Int16).FullName);

            //Equals : 값을 비교한 결과를 불린형으로 반환한다
                       //값 형식에 대해서는 해당 인스턴스가 소유하고 있는 값을 대상으로 비교
                       //참조 형식에 대해서는 할당된 메모리 위치를 카리키는 식별자의 값이 같은지 비교
            int a = 5;
            Console.WriteLine(a.Equals(5));

        }
    }
}
