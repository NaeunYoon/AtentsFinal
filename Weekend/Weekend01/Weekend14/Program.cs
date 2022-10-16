using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend14
{
    internal class Program
    {
        static void Main(string[] args)
        {
           for(int i =0; i < 10; i++)//초기식 한 번 실행 /  조건식 비교 / 증감식
            {
                //참일 경우 실행되는 부분
                Console.WriteLine("i= "+i);
            }
            //거짓일경우 실행되는 부분

            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.WriteLine($"i = {i}, j = {j}");
                }
            }

            for(int i = 0, j=10, k =10; i < 10 && j>0 && k >0 ; i++, j++, k++)
            {
                Console.WriteLine($"{i}{j}{k}");
            }

            float value = 234234.213423f;
            value = -1;
            while (value > 0)   //반복횟수를 모르는 경우에 쓰기 좋음
            {
                Console.WriteLine("value"+ value);
            }


            do  //조건을 나중에 따짐
            {
                value -= 123.45f;
                Console.WriteLine("value"+value);
            }while (value > 0);


            //foreach

            int[] array = { 0, 1, 2, 3, 4, 5, };    //배열 (값이 순차적으로 들어간다)
            int count=0;
            foreach(var i in array)
            {
                Console.WriteLine("array["+count+"]="+i);
            }

           for(int i=0; i<array.Length; i++)
            {
                Console.WriteLine("array[" + i + "]=" + array[i]);
            }


        }
    }
}
