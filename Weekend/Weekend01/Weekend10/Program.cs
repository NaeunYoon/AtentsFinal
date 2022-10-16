using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            //c#은 c와 다르게 무조건 조건식 true나 false가 들어가야 한다 (단일조건문)
            if (a > 0)  //단일조건문 
            {
                Console.WriteLine("A가 0보다 크다");
            }
            //---------------------------------------------------------------------------------
            if (a > 0)//이중조건문 : 
            {
                Console.WriteLine("A가 0보다 크다");
            }
            else
            {
                Console.WriteLine("A가 0보다 작거나 같다");
            }
            //--------------------------------------------------------

            Console.WriteLine("용돈의 금액을 입력하세요");
            //100건을 호출한다고 했을 때, 가장 많은 확률이 있는 부분을 상단에다 넣는것이 유리하다
            //따라서 값의 범위를 지정해서 조건을 설정해줘야한다
            string moneystr = Console.ReadLine();
            int money = Convert.ToInt32(moneystr);

            //if (money > 100000) //다중조건문
            //{
            //    Console.WriteLine("외식");
            //}
            //else if (money > 50000)
            //{
            //    Console.WriteLine("노래방");
            //}
            //else if(money > 20000)
            //{
            //    Console.WriteLine("PC방");
            //}
            //else
            //{
            //    Console.WriteLine("낮잠");
            //}
            //-------------------------수정
            if (money > 20000 && money<50000) 
            {
                Console.WriteLine("외식");
            }
            else if (money > 50000 && money <100000)
            {
                Console.WriteLine("노래방");
            }
            else if (money > 100000)
            {
                Console.WriteLine("PC방");
            }
            else
            {
                Console.WriteLine("낮잠");
            }




        }
    }
}
