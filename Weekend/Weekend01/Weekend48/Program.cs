using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend48
{
    class Item
    {
        public int count;

        public Item(int _count)
        {
            _count = count;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n리스트\n");
            List<int> list = new List<int>();

            for(int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            foreach(var obj in list)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("\n스택\n");

            Stack<int> intStack = new Stack<int>();

            for(int i =10; i >= 0; i--)
            {
                intStack.Push(i);
            }
            while (intStack.Count > 0)
            {
                Console.WriteLine(intStack.Pop());
            }

            Console.WriteLine("\n큐\n");

            Queue<int> intQueue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                intQueue.Enqueue(i);
            }

            while (intQueue.Count > 0)
            {
                //intQueue.Dequeue();
                Console.WriteLine(intQueue.Dequeue());
            }

            Console.WriteLine("\n딕셔너리\n");
            //아이템쓸때 사용
            Dictionary<string, int> dic = new Dictionary<string, int>();

            dic["monster"] = 1;
            dic["100"] = 1;

            dic["banana"] = 100;
            dic["mandarine"] = 200;
            dic["mango"] = 300;


            Console.WriteLine("dic[monster] = {0}", dic["monster"]);

            dic["mango"] -= 1;
            Console.WriteLine("mango count = {0}", dic["mango"]);

            Dictionary<string, Item> items = new Dictionary<string, Item>();



        }
    }
}
