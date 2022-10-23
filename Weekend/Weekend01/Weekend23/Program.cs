using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend23
{
    class Student
    {
        private string _name;
        private int _grade;
        private int _classNum;
        public static int count;
        //STSTIC : 정정멤버필드 / 다른 멤버들하고는 다르게 작동한다
        // 정적멤버필드는 객체에 속해있지 않고 따로 만들어진다
        //각각의 객체들이 하나의 count를 공유해서 사용한다
        //정적멤버필드를 초기화하는 생성자 


        public Student(string name, int grade, int classNum)    //클래스명과 이름이 같은 함수 : 생성자
            //객체는 생성자가 호출되면서 만들어진다
        {
            _name = name;
            _grade = grade;
            _classNum = classNum;

            count++;
        }

        static Student()
        {
            count = 100;        //정적멤버필드 초기화
        }

        ~Student()   
        {
            //소멸자 : 객체가 사라질 때 호출
            //c#에서는 소멸자가 언제 호출될 지 알 수가 없음
            //c#에서는 동적 객체를 관리하는 기능이 포함되어 있습니다

        }

        public void info()
        {
            Console.WriteLine("이름 {0}, 학년 {1}, 반번호 {2}, 학생수 {3}\n",_name,_grade,_classNum,count);
            string str = string.Format("이름 {0}, 학년 {1}, 반번호 {2}, 학생수 {3}\n",_name,_grade,_classNum,count);
        }

    }

    internal class Program
    {
        static void PrintStudent(Student pst)
        {
            pst.info();
        }

        static void Main(string[] args)
        {
            Student st0 = new Student("몬스터0", 1, 1);
            st0.info();
            Student st1 = new Student("몬스터1", 2, 2);
            st1.info();
            Student st2 = new Student("몬스터2", 3, 3);
            st2.info();

            PrintStudent(st0);


            //st0.count; //정적멤버는 객체를 통해서 접근할 수 없다
            Console.WriteLine(Student.count);   //이렇게 클래스를 통해서만 접근가능 
        }
    }
}
