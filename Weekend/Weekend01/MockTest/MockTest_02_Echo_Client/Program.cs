using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MockTest_02_Echo_Client
{
    internal class Program
    {   //1.
        static Socket clientSocket;
        static string strIp = "211.104.182.195";
        static int port = 8082;
        static void Main(string[] args)
        {   //2.
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endIp = new IPEndPoint(IPAddress.Parse(strIp), port);
            //3. 연결해준다
            clientSocket.Connect(endIp);
            Console.WriteLine("연결완료");

            //4. 바이트로 들어오기 때문에 선언해주고 메세지 받아서 출력해준다
            byte[] receiveBuffer = new byte[1024];
            clientSocket.Receive(receiveBuffer);
            string message = Encoding.Default.GetString(receiveBuffer);
            Console.WriteLine(message);

            //5. 에코서버 만들기 ( 클라이언트가 메세지를 만들어서 보내면 서버가 보내진 메세지를 다시 출력한다 ) 
            string sendMessage = string.Empty;  //문자열 초기화 해줌
            sendMessage = Console.ReadLine();   //사용자 입력을 받음
            Console.WriteLine($"내가 입력한 메세지 : {sendMessage}");   //내가 입력한 메세지 그냥 다시 보여주는거
            
            byte[] sendBuffer = new byte[1024]; //바이트로 변환해야 해서 할당해줌
            sendBuffer = Encoding.Default.GetBytes(sendMessage);    // 받은 문자열을 바이트로 바꿔준다
            clientSocket.Send(sendBuffer);  //바꿔진 바이트를 보내준다 (클라이언트가 데이터를 보냄) => 서버가 받음

            byte[] receivedMessage = new byte[1024];
            clientSocket.Receive(receivedMessage);
            string message2 = Encoding.Default.GetString(receivedMessage);
            Console.WriteLine("서버로부터 받은 메세지 " +message2);
            //근데 왜 한번만 하고 끝나냐고..;
            


        }
    }
}