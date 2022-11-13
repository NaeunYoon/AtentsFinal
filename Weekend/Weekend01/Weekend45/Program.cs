using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Weekend45
{
    class Pig
    {
        public int _weight;

        public Pig(int weight)
        {
            _weight = weight;
        }
    }

    internal class Program
    {
        static void CopyArray<T>(T[]destArray, T[] srcArray) //T형의 일반화된 카피어레이라는 함수를 만듬
        {
            for(int i =0; i < srcArray.Length; i++)
            {
                destArray[i] = srcArray[i];
            }
        }
        //T의 일반화된 함수를 만듬 t는 데이터타입임 t에다 float라고 하면 float형 배열이 되는거고 int 넣으면 int 형 배열이 되는거임

        static void Main(string[] args)
        {
            float[] fArray = new float[10];
            float[] fArray2 = new float[10];

            for (int i = 0; i < fArray.Length; i++)
            {
                fArray[i] = i * 1.2f;
            }

            CopyArray<float>(fArray2, fArray);

            for (int i = 0; i < fArray2.Length; i++)
            {
                Console.WriteLine($"fArray2[{i}] = {fArray2[i]}");
            }


            int[] array = new int[10];
            int[] array2 = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            CopyArray<int>(array2, array);

            foreach (var value in array2)
            {
                Console.WriteLine($"value = {value}");
            }
            Pig[] pigArray = new Pig[10];
            Pig[] pigArray2 = new Pig[10];

            for (int i = 0; i < pigArray.Length; i++)
            {
                pigArray[i] = new Pig(i);
            }

            CopyArray<Pig>(pigArray2, pigArray);

            foreach (var obj in pigArray2)
            {
                Console.WriteLine($"obj.weight = {obj._weight}");
            }

        }
    }
}
