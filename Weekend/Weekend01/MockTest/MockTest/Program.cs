

using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;

namespace MockTest
{
    internal class Program
    {
        static Socket serverSock;
        static int port = 8082;
        static string strIp = "127.0.0.1";
        static void Main(string[] args)
        {
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp), port);

            serverSock.Bind(ip);
            serverSock.Listen(100);
            Socket user = serverSock.Accept();

            string message = "안녕하세요";
            byte[] sendBuffer = Encoding.Default.GetBytes(message);
            user.Send(sendBuffer);


        }
    }
}