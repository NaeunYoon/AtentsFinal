using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_43
{
    /*
     델리게이트 : 메서드 자체를 값으로 갖는 타입
                  delegate 예약어가 필요하다 ( 접근제한자 delegate 반환타입 식별자(매개변수))
     
     */
    delegate int FuncDelegate(object arg);

    public class Disk
    {
        public int Clean(object arg)
        {
            Console.WriteLine("작업실행");
            return 0;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Disk disk = new Disk();
            FuncDelegate cleanFunc = new FuncDelegate(disk.Clean);
            FuncDelegate workFunc = disk.Clean;
            cleanFunc(disk);
            workFunc(disk);
            Console.WriteLine(cleanFunc);
            Console.WriteLine(workFunc);

            disk.Clean(null);   //clean 메서드를 직접 호출
            cleanFunc(null);    //델리게이트를 통해 clean 메서드 호출

            
        }
    }
}
