using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_41
{
    /*
     클래스간의 형변환
     
     */

    public class Currency
    {
        decimal money;
        public decimal Money    //프로퍼티
        {
            get { return money; }
        }

        public Currency(decimal money)  //생성자
        {
            this.money = money;
        }
    }

    public class Won : Currency
    {
        public Won(decimal money) : base(money)
        {

        }

        public override string ToString()
        {
            return Money + "Won";
        }
    }

    public class Dollar : Currency
    {
        public Dollar(decimal money) : base(money)
        {

        }

        public override string ToString()
        {
            return Money + "Dollar";
        }
    }

    public class Yen : Currency
    {
        public Yen(decimal money) : base(money)
        {

        }
        public override string ToString()
        {
            return Money + "Yen";
        }
    }

    


    internal class Program
    {
        static void Main(string[] args)
        {
            Won won = new Won(1000);
            Dollar dollar = new Dollar(1);
            Yen yen = new Yen(13);

            

        }
    }
}
