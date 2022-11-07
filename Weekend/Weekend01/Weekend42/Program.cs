using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend42
{   
    class Parent
    {
        public void Print() //일반메소드
        {
            Console.WriteLine("Parent :: Print");
        }

        public virtual void VirtualPrint1()  //가상메소드
        {
            Console.WriteLine("Parent :: VirtualPrint1");
        }

        public virtual void VirtualPrint2()  //가상메소드
        {
            Console.WriteLine("Parent :: VirtualPrint2");
        }
    }

    class Child1 : Parent
    {
        public new void Print()
        {
            Console.WriteLine("Child1 :: Print");
        }

        public override void VirtualPrint1()  //가상메소드
        {
            Console.WriteLine("Child1 :: VirtualPrint");
        }
    }

    class Child2 : Parent
    {
        public new void Print()
        {
            Console.WriteLine("Child2 :: Print");
        }

        public override void VirtualPrint2()  //가상메소드 ( 부모의 가상함수를 자식이 재정의한다 : 오버라이드)
        {
            Console.WriteLine("Child2 :: VirtualPrint");
        }
    }


    internal class Program
    {
        static void CallPrint(Parent parent)
        {
            parent.Print(); //일반 메서드 호출

            //parent.Parent.Print(); => 이렇게 바뀜 (정적바인딩
        }

        static void CallVirtualPrint1(Parent parent)
        {       
            parent.VirtualPrint1();     //가상메서드 호출 그릇에 담긴 타입에 준해서 작동한다
                                        //parent가 들어오면 parent 호출, child 들어오면 child 호출
                                        //어디걸 호출해야할지 몰르니까 바인딩을 유보하다가
                                        //실행중에 바인딩을 유보한다 ( 동적바인딩)
        }

        static void CallVirtualPrint2(Parent parent)
        {
            parent.VirtualPrint2();     //가상메서드 호출
        }

        static void Main(string[] args)
        {
            Parent parent = new Parent();   //parent 객체 만듬
            Child1 child1 = new Child1();   //child1 객체 만듬
            Child2 child2 = new Child2();   //child2 객체 만듬

            // 일반 메소드 호출
            CallPrint(parent);  //그릇 자체가 parent 타입이기 때문에 뭘 담아도 parent가 호출된다
            CallPrint(child1);
            CallPrint(child2);

            Console.WriteLine("\n");
            // 가상 메소드 호출
            CallVirtualPrint1(parent);
            CallVirtualPrint1(child1);
            CallVirtualPrint1(child2);

            Console.WriteLine("\n");
            // 가상 메소드 호출
            CallVirtualPrint2(parent);
            CallVirtualPrint2(child1);
            CallVirtualPrint2(child2);
        }


    }

}
