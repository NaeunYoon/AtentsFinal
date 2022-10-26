using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Atents_GameNetWork_04_Client
{
    internal class Program
    {
        static Socket clientSock;
        static string strIp = "127.0.0.1";
        static int port = 8082;

        static void Main(string[] args)
        {
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endIp = new IPEndPoint(IPAddress.Parse(strIp), port);

            clientSock.Connect(endIp);
            Console.WriteLine("연결완료");

            while (true)
            {
                string message = String.Empty;
                message = Console.ReadLine();
                Console.WriteLine("내가 입력한 메세지 : " + message);
                byte[] sendBuffer =  new byte[1024];
                sendBuffer = Encoding.Default.GetBytes(message);
                clientSock.Send(sendBuffer);
                byte[] receiveBuffer = new byte[1024];  
                clientSock.Receive(receiveBuffer);
                string receivedMessage = Encoding.Default.GetString(receiveBuffer);
                Console.WriteLine("서버에게서 받은 메세지" + receivedMessage);
            }

            
            
        }
    }
}
