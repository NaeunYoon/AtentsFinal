using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_01_Server
{
    internal class Program
    {
        static Socket serverSock;
        static string  strIp = "127.0.0.1";
        static int port = 8082;
        static void Main(string[] args)
        {
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp),port);

            serverSock.Bind(ip);
            Console.WriteLine("Bind");
            serverSock.Listen(100);
            Console.WriteLine("Listen");
            Socket user = serverSock.Accept();
            Console.WriteLine("Accept");

            string message = "안녕하세요";
            byte[] sendBuffer = Encoding.Default.GetBytes(message);
            user.Send(sendBuffer);


        }
    }
}
