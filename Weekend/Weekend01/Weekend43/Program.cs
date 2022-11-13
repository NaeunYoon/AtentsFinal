using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend43
{

    class DynamicArray<T>
    {
        private T[] _array;
        private int _size;

        private DynamicArray(int size)
        {
            _size = size;
            _array = new T[_size];
        }

        public void SetValue()
        {

        }

        public void TGetValue()
        {

        }

        public int GetSize()
        {
            return _size;
        }

        class Parent { }

        class Child : Parent
        {

        }

    }

    class Parent { }

    class Child : Parent
    {
        public void DoSomething()
        {
            Console.WriteLine("Child::DoSomething");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Parent parent = new Parent();
            Parent parent2 = new Child();

            Child child;

            child = parent as Child;

            if (child != null)
            {
                Console.WriteLine("실행 x");
                child.DoSomething();
            }

            child = parent2 as Child;

            if (child != null)
            {
                Console.WriteLine("실행 o");
                child.DoSomething();
            }


            if (parent is Child)
            {
                child = (Child)parent;
                child.DoSomething();
            }

            if (parent2 is Child)
            {
                child = (Child)parent2;
                child.DoSomething();
            }

        }
    }
}
/*
 as : 패어런츠를 타일드 타입으로 변환하는데 그게 안되면 널임
첫번쨰 이프는 호출이 안된다


두번쨰는 패어런츠 2는 차일드 타입이라서 패어런츠 2가 차일드 타입으로 형변환이 되기 때문에
변환된 차일드 객체가 전달이 되서 함수가 실행된다.

is : 차일드 타입이냐고 물어보고 차일드 타입이면 함술ㄹ 실행함
물어봤을 때 해당 타입이면 함수를 실행한다
 */