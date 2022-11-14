using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD_START_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //return 0;

            if (args.Length < 2)
            {
                return;
            }
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);

        }
    }
}
