using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_46
{
    /*
      콜백 메서드 
        콜백 : 피호출자에서 호출자의 메서드를 호출하는 것을 의미, 
        호출된 호출자측의 메서드를 콜백메서드 라고 한다 
      */
    class Target    
    {
        public void Do(Source obj)  //1.source 타입이 호출자, 
        {
            Console.WriteLine(obj.GetResult()); //2. 콜백, 콜백메서드
        }
    }

    class Source
    {
        public int GetResult()
        {
            return 10;
        }

        public void Test()
        {
            Target target = new Target();
            target.Do(this);        //1. 피호출자
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
