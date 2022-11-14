using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_24
{
    //단일상속만 지원함
    public class Computer
    {
        protected bool powerOn; //protected로 바꿔줌

        public void Boot()
        {

        }

        virtual public void ShutDown()
        {

        }

        public void Reset()
        {

        }
    }

    public class NoteBook : Computer
    {
        public override void ShutDown()
        {
            base.ShutDown();
        }

        bool fingerScan;
        public bool HasFingerScanDevice()
        {

            return fingerScan;
        }

        public void CloseLid()
        {
            if(powerOn == true)
            {
                 ShutDown(); //추가된 메서드 내에서 부모 메서드 호출

            }
        }
    }

    public class Desktop : Computer
    {

    }

    //public class NoteBook
    //{

    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            NoteBook noteBook = new NoteBook();
            noteBook.Boot();    //notebook 인스턴스에 대해 부모의 메서드 호출

        }
    }
}
