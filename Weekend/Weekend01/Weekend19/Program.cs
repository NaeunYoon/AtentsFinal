using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend19
{
    

    class Student   // 대상객체 -> 추상화 -> 캡슐화 -> 클래스형 데이타 타입 -> 객체
    {
        private string _name;    // 멤버 필드
        private int _age;           //프로퍼티를 통해서 접근하면 에러처리나 유효성 검사를 할 수 있다는 장점
        private int _classNum;
        private int _grade;

        public int Score { set; get; }  //내부변수안만들고 그냥 작동하면 알아서 내부변수를 만들어줌
                                        //이렇게도 쓰긴 함

        public string Name =>_name; //이렇게 들어가기도 함
                                    //값을 가져오는건 되는데ㅡ변경은 안됨

        public Student()
        {
            Console.WriteLine("기본생성자"); //아무 인자도 받지 않는 생성자를 기본생성자
        }

        public Student(string name, int age, int grade, int classNum)   //인자를 받는 생성자
        {
            Console.WriteLine("인자를 받는 생성자");
            _name = name;
            _age = age;
            _classNum = classNum;
            _age = age;
        }

        public void info()  //멤버메소드
        {
            Console.WriteLine(_name);
            Console.WriteLine(_age);
            Console.WriteLine(_grade);
            Console.WriteLine(_classNum);
        }


        //public string Name  // property
        //{
        //    set
        //    {
        //        _name = value;
        //    }

        //    get => _name;       //새롭게 추가됨 이렇게 쓰기도 함....

        //}
        public int Age
        {
            set                     //조건을 추가해서 셋 해줄 수 있음
            {
                if (value < 20)
                {
                _age = value;
                }else if(value > 100)
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

            private get
            {
                return _grade;
            }
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

            //st.Name = "monster";
            st.Age = 17;
            st.ClassNum = 11;
            st.Grade = 3;


            Console.WriteLine($"st.Name = {st.Name}");
            Console.WriteLine($"st.Age = {st.Age}");
            Console.WriteLine($"st.ClassName = {st.ClassNum}");
            //Console.WriteLine($"st.Grade = {st.Grade}");


            //우리가 객체를 만들 떄 무조건 호출되어지는 함수를 생성자라고 한다 
            //그래야 온전한 객체라고 본다
            //생성자는 클래스명과 동일한 이름의 함수이다
            //생성자를 만들지 않으면 컴파일러는 기본 생성자라는 것을 자동으로 만들어준다
            //생성자가 무조건 필요하니까 기본생성자를 자동으로 만드는데

            Student st2 = new Student("몬스터", 17, 3, 11);
            //인자가 네개가 들어가는 생성자
            st2.info();
            //인자를받는생성자를 호출해서 함수를 만들었다..



        }
    }

}
