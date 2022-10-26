using System.Net;
using System.Net.Sockets;

namespace MockTest_05_MultiClients_01_C
{
    internal class Program
    {
        static Socket clientSocket;
        static int port = 8082;
        static string strIp = "127.0.0.1";
        static void Main(string[] args)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endIp = new IPEndPoint(IPAddress.Any, port);
        }
    }
}