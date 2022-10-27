using System.Net;
using System.Net.Sockets;
using System.Text;

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
            IPEndPoint endIp = new IPEndPoint(IPAddress.Parse(strIp), port);

            clientSocket.Connect(endIp);
            Console.WriteLine("CONNECT");

            byte[] receiveBuffer = new byte[128];
            clientSocket.Receive(receiveBuffer);
            string receiveMessage = Encoding.Default.GetString(receiveBuffer);
            Console.WriteLine("서버로부터 받은 메세지 : " +receiveMessage);

            Array.Clear(receiveBuffer, 0, receiveMessage.Length);   //서버로부터 받은 메세지 버퍼 지워줌
            
            string message = string.Empty;
            

        }
    }
}