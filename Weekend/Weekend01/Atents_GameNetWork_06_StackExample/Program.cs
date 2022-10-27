using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_06_StackExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LIFO : LAST IN FIRST OUT (첫번째 데이터가 가장 마지막에 삭제된다, 마지막 데이터가 처음 삭제된다 )


            Stack<int> stack = new Stack<int>();
            //스택에 데이터를 추가
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            /*
            5 
            4
            3
            2
            1
            이렇게 저장되기 때문에 pop하면 가장 위에 있는 5가 나온다
             */


            //스택에서 데이터를 삭제
            int result = stack.Pop();
            Console.WriteLine(result);

            //스택에서 삭제할 데이터를 반환
            result = stack.Peek();
            Console.WriteLine(result);

            int count = stack.Count();  
            Console.WriteLine(count);
            Console.WriteLine(stack.Count);
            int[] array = stack.ToArray();
            
        }
    }
}
