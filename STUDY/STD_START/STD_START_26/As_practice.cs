using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_26
{

   public class ATENTS
    {

    }

    public class NAEUN : ATENTS
    {

    }

    internal class As_practice
    {
        static void Main()
        {
            //IS에 관련된 예제

            int num = 10;
            if( num is string)
            {
                Console.WriteLine("num은 string임");
            }

            //밥을 일찍 먹었길 정말 다행이에요.
            //그러지 않았다면 전 내일까지 굶고 있었을 테니까요

            //AS

            ATENTS atents = new ATENTS();
            NAEUN naeun = atents as NAEUN;
            if(naeun != null)
            {
                Console.WriteLine("쌉가능 ㅎㅇㅌ");   //실행되지 않는다 왜냐면
            }



        }
    }
}
