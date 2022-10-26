using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MockTest_01_Client
{
    internal class Program
    {
            //1. Socket,Ip,Port 생성 (static이여야함)
        static Socket clientSock;
        static int port = 8082;
        static string strIp = "127.0.0.1";
        static void Main(string[] args)
        {   //2. Socket,Ip,Port 연결
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            //IpEndPoint종단점 내위치에서 string문자열 형식의ip를 ip형식으로 바꿈
            IPEndPoint endIp = new IPEndPoint(IPAddress.Parse(strIp),port);    

            //3. 클라이언트인 경우 connect 해준다
            clientSock.Connect(endIp);

            //4. 데이터를 받는다
            byte[] receivebuffer = new byte[1024];
            clientSock.Receive(receivebuffer);
            string message = Encoding.Default.GetString(receivebuffer);
            Console.WriteLine(message);


        }
    }
}