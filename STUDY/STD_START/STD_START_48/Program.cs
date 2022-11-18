using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_48
{
    class SortObject    
    {
        int[] number;//배열을 정렬할 수 있는 기능을 가진 타입 정의

        public SortObject(int[] number)    //배열을 생성자의 인자로 받아서 보관
        {
            this.number = number;
        }

        public void Sort()  //전형적인 선택 정렬 알고리즘을 구현한 메서드
                            //number 배열의 요소를 크기순으로 정렬
        {
            int temp;

            for (int i = 0; i < number.Length; i++)
            {
                int lowPos = i;

                for (int j = i+1; j < number.Length; j++)
                {
                    if (number[j] > number[lowPos]) //내림차순으로 정렬하려면 < 연산자를 >로 변경
                    {
                        lowPos = j;
                    }
                }
                temp = number[lowPos];
                number[lowPos] = number[i];
                number[i] = temp;
            }

        }

        public void Display()   //number 요소를 화면에 출력
        {
            for (int i = 0; i < number.Length; i++)
            {
                Console.Write(number[i]+",");              
            }
            Console.WriteLine("");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 5, 2, 3, 1, 0, 4 };

            SortObject so = new SortObject(intArray);
            so.Sort();
            so.Display();

        }
    }
}
