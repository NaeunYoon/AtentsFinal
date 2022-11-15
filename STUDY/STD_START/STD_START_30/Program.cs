using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_30
{
    internal class Program
    {
        //system.Array
        private static void OutputArrayInfo(Array arr)
        {
            Console.WriteLine("배열의 차원 수 "+ arr.Rank);
            Console.WriteLine("배열의 요소 수 "+ arr.Length);
        }

        private static void OutputArrayElement(string title, Array arr)
        {
            Console.WriteLine("[" + title +"]");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr.GetValue(i)+",");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Array : Rank (차원 수) , Length (요소 수), Sort (정렬), GetValue (배열 요소 값), Copy (복사)
            int[] intArray = new int[] { 0, 1, 2, 3, 4, 5 };

            bool[,] boolArray = new bool[,] { {true, false }, { true, false }};
            OutputArrayInfo(boolArray);

            int[] intArray2 = new int[] { 5, 4, 3, 2, 1, 0 };
            OutputArrayInfo(intArray2);

            OutputArrayElement("원본 intArray",intArray2);
            Array.Sort(intArray2);
            OutputArrayElement("array.sort 후 intarray ",intArray2);

            int[] copyArray = new int[intArray2.Length];
            Array.Copy(intArray2,copyArray, intArray2.Length);

            OutputArrayElement("copy array",copyArray);
        }
    }
}
