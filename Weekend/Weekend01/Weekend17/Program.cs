using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend17
{
    // 캡슐화 -> 클래스형 데이타 타입
    // class 클래스명 {
    // 데이타 
    //}
    class Son
    {
        public string jumin;    // 멤버 필드
        public string address;
        public int age;
    }

    struct Student
    {
        public string name;
        public int age;
        public int grade;
    }


    class Program
    {
        // 값타입 : 기본데이타타입, 구조체, 열거형
        // 참조타입 : 클래스형 데이타 타입

        static void ChangeValue(Son value)  // 메소드
        {
            value.age = 20;
            value.address = "서울";
            value.jumin = "23423423423";
        }

        static void ChangeValue(int value)
        {
            value = 1000;
        }

        static void ChangeValue(Student value)
        {
            value.age = 100;
            value.grade = 100;
            value.name = "원숭이";
        }

        static void ChangeValue(string value)
        {
            value = "monster is World!!";
        }

        static void Main(string[] args)
        {
            int a;
            a = 20;

            Son son = new Son();
            son.jumin = "1234";
            son.address = "런던";
            son.age = 17;


            Student st;
            st.age = 10;
            st.grade = 3;
            st.name = "몬스터";

            string str = "monster";


            Console.WriteLine($"before son.jumin = {son.jumin}, son.address = {son.address}, son.age = {son.age}");
            ChangeValue(son);
            Console.WriteLine($"after son.jumin = {son.jumin}, son.address = {son.address}, son.age = {son.age}");


            Console.WriteLine($"before a = {a}");
            ChangeValue(a);
            Console.WriteLine($"after a = {a}");


            Console.WriteLine($"before st.age = {st.age}, st.grade = {st.grade}, st.name = {st.name}");
            ChangeValue(st);
            Console.WriteLine($"after st.age = {st.age}, st.grade = {st.grade}, st.name = {st.name}");

            Console.WriteLine($"before str = {str}");
            ChangeValue(str);
            Console.WriteLine($"after str = {str}");


        }
    }
}