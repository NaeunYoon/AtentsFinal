using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend20
{
    namespace _202210151228_Capsulation
    {

        class Student   // 대상객체 -> 추상화 -> 캡슐화 -> 클래스형 데이타 타입 -> 객체
        {
            private string _name;    // 멤버 필드
            private int _age;
            private int _classNum;
            private int _grade;
            public int JumSu { set; get; }

            public string Name  // property
            {
                set
                {
                    _name = value;
                }

                get
                {
                    return _name;
                }
            }

            public int Age
            {
                set
                {
                    if (value < 20)
                    {
                        _age = 20;
                    }
                    else if (value > 100)
                    {
                        _age = 100;
                    }
                    else
                    {
                        _age = value;
                    }

                }

                get
                {
                    return _age;
                }
            }

            public int ClassNum
            {
                set
                {
                    _classNum = value;
                }

                get
                {
                    return _classNum;
                }
            }

            public int Grade
            {
                set
                {
                    _grade = value;
                }

                get
                {
                    return _grade;
                }
            }

            public Student()
            {
                Console.WriteLine("Student 기본 생성자");
            }

            public Student(string name, int age, int grade, int classNum)
            {
                Console.WriteLine("Student 인자를 받는 생성자");
                _name = name;
                _age = age;
                _grade = grade;
                _classNum = classNum;
            }

            public void info()  // 멤버 메소드
            {
                Console.WriteLine($"Name = {_name}");
                Console.WriteLine($"Age = {_age}");
                Console.WriteLine($"ClassName = {_classNum}");
                Console.WriteLine($"Grade = {_grade}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Student st = new Student(); // 클래스형 데이타 타입으로 만든 변수를 객체라고 합니다.

                // 캡슐화의 기본 정책은 정보 은닉
                // 클래스안에 멤버의 노출을 제어하는 것을 접근제어자.
                // private, protected, public 
                // private 외부 허용 x, 자식 x
                // protected 외부 x, 자식 o
                // public 외부 o
                // default는 private
                st.Name = "monster";
                st.Age = 17;
                st.ClassNum = 11;
                st.Grade = 3;


                Console.WriteLine($"st.Name = {st.Name}");
                Console.WriteLine($"st.Age = {st.Age}");
                Console.WriteLine($"st.ClassName = {st.ClassNum}");
                Console.WriteLine($"st.Grade = {st.Grade}");

                Console.WriteLine("\n\n");
                Student st2 = new Student("몬스터", 17, 3, 11);
                st2.info();



            }
        }

    }
}
