using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruitName = "";
            Console.WriteLine("먹고싶은 과일명을 입력하세요");
            
            fruitName = Convert.ToString(Console.ReadLine());

            switch (fruitName)  // 선택문
            {
                case "apple":
                case "사과":
                    Console.WriteLine("사과를 입력했습니다");
                   break;

                case "banana":
                case "바나나":
                    Console.WriteLine("바나나를 입력했습니다");
                    break;

                case "strawberry":
                case "딸기":
                    Console.WriteLine("딸기를 입력했습니다");
                    break;
                default: Console.WriteLine($"{fruitName}을 입력하지 않았습니다");
                    break;
            }
        }
    }
}
