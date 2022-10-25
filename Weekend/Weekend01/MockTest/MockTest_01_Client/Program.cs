using System.Net.Sockets;

namespace MockTest_01_Client
{
    internal class Program
    {
        static Socket clientSock;
        static int port = 8082;
        static string strIp = "127.0.0.1";
        static void Main(string[] args)
        {
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }
    }
}