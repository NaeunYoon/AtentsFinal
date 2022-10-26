

using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;

namespace MockTest
{
    internal class Program
    {
        //1. Socket,Ip,Port 생성 (static이여야함)
        static Socket serverSock;
        static int port = 8082;
        static string strIp = "127.0.0.1";
        

        static void Main(string[] args)
        {   //2. Socket,Ip,Port 연결
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IpEndPoint종단점 내위치에서 string문자열 형식의ip를 ip형식으로 바꿈
            IPEndPoint endIp = new IPEndPoint(IPAddress.Parse(strIp), port);

            //3. 서버인 경우 Bind,Listen,Accept 해준다

            serverSock.Bind(endIp);
            Console.WriteLine("Bind");
            serverSock.Listen(100); //최대 접속 인원이 아님(서버 수용량에 따라 다름) / 최대 대기 인원임
            Console.WriteLine("Listen");
            Socket client = serverSock.Accept();    //클라이언트 대기상태, 반환값이 되는 소켓 따로 정함
            Console.WriteLine("Accept");
            Console.WriteLine($"클라이언트 접속함 : { client.RemoteEndPoint}"); // Accept로 받은 클라이언트 ip를 출력

            //4. 데이터 보내기 : string "안녕하세요" 를 byte 배열로 바꿔서 보내야 한다
            string message = "안녕하세요";
            byte[] sendBuffer = new byte[1024];
            sendBuffer =  Encoding.Default.GetBytes(message);
            client.Send(sendBuffer);    //안녕하세요 보냄
        }
    }
}