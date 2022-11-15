using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_26
{
    public class Computer
    {
        bool powerOn;
        public void Boot() { }
        public void ShutDown() { Console.WriteLine("shutdown 호출"); }
        public void Reset() { }
    }
    public class NoteBook : Computer
    {
        bool fingerScan;
        public bool HasFingerScanDevice() { return fingerScan; }
        public void CloseLid() { ShutDown(); }  //부모의 메서드 호출
    }

    internal class Class1
    {
        //static void Main(string[] args)
        //{
        //    //AS 연산자
        //    // 캐스팅 연산자를 사용해 명시적 형변환을 하는 경우 컴파일 단계가 아닌 프로그램을 실행할 때 오류가 발생함
        //    //오류를 발생시키지 않고 형변환이 가능한지 확인할 수 있는 방법이 필요해서 AS 연산자를 사용함

        //    Computer computer = new Computer();
        //    /*NoteBook notebook = (NoteBook)computer;*/ //오류발생

        //    NoteBook notebook = computer as NoteBook;

        //    if(notebook != null)
        //    {
        //        notebook.CloseLid();    //코드대로라면 if문 내부의 코드가 실행될 가능성은 없다 (가능하지 않아서 null 반환)
        //    }
        //    //형변환이 가능하면 지정된 타입의 인스턴스 값을 반환하고, 가능하지 않으면 null 반환
        //    //as 는 참조형 변수에 대해서만 적용할 수 있고, 참조형 타입으로의 체크만 가능하다


        //    //반면에 is는 참조형식 뿐만 아니라 값 형식에도 사용할 수 있음


        //    int n = 5;
        //    if(n is string)
        //    {
        //        Console.WriteLine("변수 n은 string");  //n은 string이 아니기 때문에 null
        //    }

        //}

    }
}
