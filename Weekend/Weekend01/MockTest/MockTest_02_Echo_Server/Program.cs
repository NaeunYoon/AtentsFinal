using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MockTest_02_Echo_Server
{
    internal class Program
    {   //1. socket ip port 선언
        static Socket serverSocket;
        static string strIP = "211.104.182.195";
        static int port = 8082;
        static void Main(string[] args)
        {
            //2. socket ip port 연결
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endIp = new IPEndPoint(IPAddress.Any, port);
            //3. bind listen accept 해준다
            serverSocket.Bind(endIp);
            Console.WriteLine("Bind");
            serverSocket.Listen(100);
            Console.WriteLine("Listen");
            Socket client = serverSocket.Accept();
            Console.WriteLine("Accept");
            Console.WriteLine($"클라이언트 접속 : {client.RemoteEndPoint}");   //클라이언트 ip따옴 / get만 있고 set은 없음

            //4. 데이터 보내기 : string "안녕하세요" 를 byte 배열로 바꿔서 보내야 한다
            string message = "안녕";
            byte[] sendBuffer = new byte[1024];
            sendBuffer = Encoding.Default.GetBytes(message);
            client.Send(sendBuffer);        //이거 좀 헷갈림. 클라이언트에서 받은걸 소켓에 저장하고 받은걸 보냄

            while(true) //6. 계속 버퍼 만들고 인코딩 하기 싫으니까 while문 돌림
            {

            //5. 에코서버 만들기 : 클라이언트가 메세지를 서버한테 보내면 서버는 그대로 출력해준다
            byte[] recvBuffer = new byte[1024]; //버퍼가 여러개 필요한가...? 근데 이거 없으면 제대로 출력 안댐;;
            client.Receive(recvBuffer);
            string receivedMessage = Encoding.Default.GetString(recvBuffer);
            Console.WriteLine($"클라이언트로부터 받은 메세지 :{receivedMessage} ");

            sendBuffer = recvBuffer;    //버퍼 여러개 안쓰려고 이렇게 하나요?  이렇게 해도 되긴 됨..헉 여기 헷갈림.. 도대체 버퍼가 몇개야;
                                        //이거 쓰나 안쓰나 되긴 함..
            byte[] sendBuffer2 = new byte[1024];
            sendBuffer2 = Encoding.Default.GetBytes(receivedMessage);
            client.Send(sendBuffer2);

            }

        }
    }
}