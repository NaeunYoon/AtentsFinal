using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_07_ProcessTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exe_name = @"C:\Users\whale\OneDrive\문서\AtentsFinal_1\Weekend\Weekend01
                                \Atents_GameNetWork_07_Chat_Client\bin\Debug\Atents_GameNetWork_07_Chat_Client.exe";
            for(int i = 0; i < 500; i++)
            {
                Process.Start(exe_name);

            }
        }
    }
}
