using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Weekend09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //비트연산자 연산의 단위가 비트, 
            int a = 1;
            int b = 2;

            int ret = a & b; //비트 and 연산, 특정 자리의 비트값을 0으로 만들 떄 mask off
            //a  : 00000001
            //b  : 00000010
            //a&b: 00000000

            ret = a | b; //비트 or 연산 , 특정 자리의 비트값을 1로 만들 때 사용 mask on
            //a  : 00000001
            //b  : 00000010
            //a|b: 00000011     한쪽이 참이면 참

            ret = a ^ b; //배타적 xor 연산
            //a  : 00000001
            //b  : 00000011
            //a^b: 00000010     두 자리의 비트값이 다르면 참 같으면 거짓


            uint light = 0xFFFFFFFF;
            uint mask = 1;

            Console.WriteLine("끄실 방의 번호를 입력하세요");
            string str = Console.ReadLine();
            int value = Convert.ToInt32(str);
            mask = mask << value;
            mask = ~mask;
            light = light &mask;
            Console.WriteLine("value ="+value);

            Console.WriteLine("light = " + Convert.ToString(light,2));      //라이트 값을 2진수로 출력
        }
    }
}
