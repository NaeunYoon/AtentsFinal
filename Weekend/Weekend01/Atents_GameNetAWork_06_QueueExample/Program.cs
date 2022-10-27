using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetAWork_06_QueueExample
{
    internal class Program
    {
        /*
         배열은 메모리 크기를 바꿀 수 없고 (처음에 크기를 고정적으로 할당)
         리스트는 필요할 (원할)때마다 크기를 할당할 수 있다
         데이터 삽입과 삭제가 용이한 것이 리스트라서 리스트를 선호하는 것이다
         
         
         */


        static void Main(string[] args)
        {
            //FIFO : FIRST IN FIRST OUT (첫번째 데이터가 가장 먼저 삭제된다)

            Console.WriteLine("QUEUE");

            Queue<int> queue = new Queue<int>();
            //큐에 데이터를 추거
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            //큐에 데이터를 삭제하면서 하나 가져온다
            //제일 먼저 데이터를 추가한 값이 나온다
            //5 4 3 2 1  => 1 먼저 나옴 일방향임
            int result = queue.Dequeue();
            //int result1 = queue.Dequeue();
            Console.WriteLine(result);  //1이 출력됨 => 1이 제일 먼저 삽입되서 1이 출력
            Console.WriteLine(queue.Dequeue()); //2출력됨
            Console.WriteLine(queue.Dequeue()); //3 출력됨
            Console.WriteLine(result);  //1출력됨

            Console.WriteLine("PEEK");

            //Peek : 시작부분에서 개체(데이터)를 제거하지 않고 반환
            result = queue.Peek();
            Console.WriteLine(result);

            Console.WriteLine("QUEQUE.COUNT");
            int count = queue.Count;
            Console.WriteLine(count);   //2개남음 4,5

            Console.WriteLine("CLEAR");
            queue.Clear();
            //큐에서 모든 데이터를 삭제

            Console.WriteLine("QUEQUE to Array");
            int[] array = queue.ToArray();

            PeekExample();

        }
        static void PeekExample()
        {
            Console.WriteLine("peekExample");

            Queue<int> queue = new Queue<int>();
                
            for(int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            int count = queue.Count;
            Console.WriteLine(count);

        }

    }
}
