using System.Net;
using System.Net.Sockets;

namespace MockTest_05_MultiClients_01_S
{
    internal class Program
    {
        static Socket serverSocket;
        static int port = 8082;
        static string strIp = "127.0.0.1";

        static void Main(string[] args)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endIp = new IPEndPoint(IPAddress.Any, port); 



        }
    }
}