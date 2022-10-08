using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekend07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool a = true;      //논리연산은 불타입만 가능
            bool b = false;

            bool ret = a && b; //논리AND
            Console.WriteLine($"a : {a} && b : {b} = ret ; {ret}");

            ret = a || b; //논리OR
            Console.WriteLine($"a : {a} || b : {b} = ret ; {ret}");

            ret = !a; //논리NOT
            Console.WriteLine($"!a : {a}  = {ret}");


        }
    }
}
