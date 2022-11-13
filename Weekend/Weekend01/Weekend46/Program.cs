using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 어떤 데이터 타입이던지 저장할 수 있는 배열을 가지고 있음
입력받은 사이즈 만큼의 배열을 만든다
연산자 오버로딩 : 내가 만든 데이터 타입에 연산자를 사용할 수 있음
사용자가 만든 데이터 타입에 연산기호를 사용할 수 있도록 해줍니다
static으로 지정해야함 . 다이나믹 어레이에 객체를 집어넣으주면 
c에서 연산자 오버로딩을 하려면 static으로 해야함
 */
namespace Weekend46
{
    class DynamicArray<T>
    {
        private T[] _array; //참조형 멤버필드

        private int _size;  //사이즈를 기록함

        public DynamicArray(int size)
        {
            _size = size;   //입력받은 사이즈 값을 멤버필드에 기록
            _array = new T[_size];  //사이즈만큼의 배열을 만들어서 멤버필드에 연결
        }

        // 연산자오버로딩
        // 사용자가 만든 데이타 타입에 연산기호를 사용할 수 있도록 해줍니다.
        public static DynamicArray<T> operator+(DynamicArray<T> value1, DynamicArray<T> value2)
        {
            DynamicArray<T> temp = new DynamicArray<T>(value1._size + value2._size);

            for (int i = 0; i < value2._size; i++)
            {
                temp.SetValue(i, value1.GetValue(i));
            }

            for (int i = value1._size; i < value2._size + value1._size; i++)
            {
                temp.SetValue(i, value2.GetValue(i - value2._size));
            }

            return temp;
        }

        public void SetValue(int index, T value)
        {
            _array[index] = value;
        }

        public T GetValue(int index)
        {
            return _array[index];
        }

        public int GetSize()
        {
            return _size;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>(10);    //int형 저장공간 10개 만들어진다

            array.SetValue(0, 1);   //0번쨰 인덱스에 1을 넣음

            Console.WriteLine(array.GetValue(0));   //0에 있는 값을 리턴해서 출력


            DynamicArray<float> array2 = new DynamicArray<float>(10);   //float 저장공간 10개

            array2.SetValue(0, 1);  //array2 만들어주고 참조값이 array2에 저장이 된다. 동적메모리 공간이 만들어지고...

            Console.WriteLine(array2.GetValue(0));  //0번쨰에 1.0출력한다


            for (int i = 0; i < array.GetSize(); i++)
            {
                array.SetValue(i, i);
            }

            DynamicArray<int> arrayint = new DynamicArray<int>(10);

            for (int i = 0; i < arrayint.GetSize(); i++)
            {
                arrayint.SetValue(i, i + 20);
            }

            DynamicArray<int> arrayTemp = array + arrayint;

            for (int i = 0; i < arrayTemp.GetSize(); i++)
            {
                Console.WriteLine("arrayTemp[{0}] = {1}", i, arrayTemp.GetValue(i));

            }
        }
    }
}
