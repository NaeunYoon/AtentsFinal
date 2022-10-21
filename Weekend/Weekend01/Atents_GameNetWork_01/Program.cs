using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_01
{
    internal class Program
    {
        static Socket clientSock;
        static string strIp = "127.0.0.1";
        static int port = 8082;
        static void Main(string[] args)
        {
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp), port);

            clientSock.Connect(ip);

            byte[] receiveBuffer = new byte[1024];
            clientSock.Receive(receiveBuffer);
            string receiveMessage = Encoding.Default.GetString(receiveBuffer);
            Console.WriteLine(receiveMessage);
        }
    }
}
