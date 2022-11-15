using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_25
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

    public class Desktop : Computer
    {

    }

    public class NetBook : Computer
    {

    }


    #region 펜
    sealed class Pen
    {

    }

    //public class ElecticPen : Pen
    //{
    //      sealed 예약어로 상속을 막음
    //}
    #endregion

    public class DeviceManager
    {
        public void TurnOff(Computer device)    //부모클래스를 담음
        {
            device.ShutDown();
            Console.WriteLine("device.shutdown 호출 끝\n");
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            //암시적 형변환 ( 특수화 타입의 변수에서 일반화된 타입의 변수로 값이 대입되는 경우 )

            short a = 100;
            int b = a; 
            Console.WriteLine(b);   // 일반화된 타입 int, 특수화된 타입 short
                                    // 정수는 int 영역을 포함하고 int 는 short 영역을 포함한다 (정수 -> int -> short)

            //명시적 형변환 ( 일반화 타입의 변수에서 특수화된 타입의 변수로 값이 대입되는 경우 )

            int c = 100;
            short d = (short)c; 
            Console.WriteLine(d);


            //---------------------------------------------------------------------------------------------------------

            NoteBook noteBook = new NoteBook();
            Computer pc = noteBook; 
            // computer는 일반적인 개념으로 그 범위는 computer를 상속받은 notebook을 포함한다
            //암시적 형변환이 가능함
            pc.Boot();
            pc.Reset();

            //부모 클래스의 인스턴스를 자식클래스의 변수로 대입하는 것은 암시적 형변환이 불가능하다.
            Computer computer = new Computer();
            /*NoteBook note = (NoteBook)computer;*/ //명시적 형변환과 컴파일은 가능하나 실행 시 오류가 발생함

            //개발자가 의도적으로 원하는 경우에 명시적 형변환이 가능하다*************************************

            NoteBook notebook01 = new NoteBook();
            Computer computer01 = notebook01;   //부모타입으로 암시적 형변환 가능

            NoteBook notebook02 = (NoteBook)computer01; //다시 본래 타입으로 명시적 형변환을 함
            notebook02.ShutDown();
            //--------------------------------------------------------------------------------------------------------

            NoteBook note001 = new NoteBook();
            NetBook net001 = new NetBook();
            Desktop desk001 = new Desktop();
            DeviceManager manager = new DeviceManager();

            manager.TurnOff(note001);
            manager.TurnOff(net001);
            manager.TurnOff(desk001);

            //--------------------------------------------------------------------------------------------------------

            Computer[] machine = new Computer[] { new NoteBook(), new NetBook(), new Desktop() };   //암시적 형변환
                                                                                                    //잘 모르겠숨...
            DeviceManager managers = new DeviceManager();
            foreach (Computer device in machine)
            {
                managers.TurnOff(device);
            }

        }
    }
}
