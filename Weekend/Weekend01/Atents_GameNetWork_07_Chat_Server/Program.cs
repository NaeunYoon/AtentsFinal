using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_07_Chat_Server
{
    internal class Program
    {
        static Socket serverSocket;
        static string strIP = "127.0.0.1";
        static int port = 8082;
        static byte[] sendBuffer;
        static byte[] receiveBuffer;

        static void Main(string[] args)
        {
            sendBuffer = new byte[128];
            receiveBuffer = new byte[128];
            
        }
    }
}
