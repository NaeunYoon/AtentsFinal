using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Weekend18
{
   class Student   //단순화시킨 데이터를 묶음 (클래스형 데이터 타입)
        //대상객체 -> 추상화 -> 캡슐화 -> 크랠스형 데이터타입 -> 객체
    {
        private string _name;   //멤버필드는 보통 _를 해준다
        private int _age;
        private int _className =1;
        private int _grade;
        //프로퍼티는 무조건 공개임
        public string Name  //프로퍼티와 구별하기 위해서 (바로 접근이 안되니까 프로퍼티로 접그)
        {
            get
            {
                return _name;   
            }
            set
            {
                _name = value;
            }
        }

        public int Age
        {
            get
            {
                return  _age;
            }
            set
            {
                _age = value;
            }
        }

        public int ClassName
        {
            get { return _className; }  //출력은 허용
            private set { _className = value; } //프로퍼티 만들어놓고 외부에서 접근하는건 싫다면
                                                //앞에 private를 붙여준다 (접근제어자로 제거)
                                                //수정은 비허용
        }


    }
    //클래스에 퍼블릭 선언하고 멤버변수 프라이베잇이라도 접근 안됨
    //각 멤버변수의 접근제어자를 바꿔주어야한다
    //클래스는 일단 공개임

    
    internal class Program
    {
        static void Main(string[] args)
        {
            //클래스형 데이터 타입으로 만든 변수를 객체라고 합니다
            Student st = new Student();
            //무조건 스튜던트 동적메모리에 만드니까 뉴로 할당해준다
            //st는 주소값을 가지고 있음 그래서 참조형변수를 그냥 객체라고 부른다 
            //1000이라는 주소값을 가지고 실제 메모리 공간에 접근하니까
            //엄연히 따지면 힙메모리에 있는게 객체임


            //캡슐화의 기본정책은 정보 은닉이다
            //class라는 걸로 묶었고 안에있는건 멤버필드이다
            //이 클래스에 둘러싸인걸 접근하지 못하도록 private로 했다
            //객체지향은객체와 객체끼리의 상호작용으로 프로그램이 작동해
            //a랑b가 상호작용하려면 둘 중에 하나가 뭐라도 노출을 해줘야 할 것 아니야
            //이렇게 보여지는 부분을 stub이라고 한다. 나뭇가지를 빼놨다고 생각하면 된다
            //철저히 감추겠다는 의미인데 그렇게 감추면 a가 b랑 소통을 못하니까 조금을 노출해주는데
            //그래서 어떤건 보여주고 어떤건 감추겠다. 안에있는 정보를 제어할 필요성이 있다
            //클래스 멤버들을 보여주거나 감춰준다
            //클래스 안에 멤버의 노출을 제어하는 것을 접근제어자라고 한다
            //private는 철저하게 감추겠다는 거다 (외부 자식도 허용 안함)
            //public 노출하겠다는거다 (외부 허용 자식 허용)
            //protected 는 외부에게는 감추고 자식한테는 공개하겠다는 것
            //상속 : 어떤 클래스를 상속받아서 다른 클래스를 만드는것 그게 자식 : 부모
            //이 멤버필드는 바로 접근하는걸 허용하지 말라고 한다 보통 멤버는 private로 만든다 (권고사항)
            //그럼 어떻게 접근해?? c#에서는 멤버 필드에 접근할 수 있도록 프로퍼티를 이용한다
            //멤버 필드에 접근하는 함수를 프로퍼티라고 한다.
            //프로퍼티도 기본은 함수인데


            st.Name = "monster";
            /*st.ClassName = 1; */      //set접근자가 private라서 바꿀 순 없음
            Console.WriteLine(st.ClassName);


        }
    }
}
