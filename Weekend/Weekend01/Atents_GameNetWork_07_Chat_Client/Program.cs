using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UserInfo;

namespace Atents_GameNetWork_07_Chat_Client
{
    public enum PACKET
    {
        PEERINFO = 1000,
        MOVECHAR = 1001
    }

    internal class Program
    {
        /*
         통신의 절차를 생각해보자 흠.. 비동기로 할거임
        1. 소켓을 생성하고
        2. connect 하고
        3. 서버로부터 메세지를 수신받는다
        4. 접속해있는 사용자 정보를 서버로부터 수신
        5. 자신이 작성한 메시지를 서버로 보낸다
        6. 자신이 보낸 메세지를 서버로부터 수신하여 콘솔뷰에 출력한다
        7. 서버로부터 응답 결과를 받아서 출력하는 방식으로 할거임
        8. 다른 사용자가 보낸 메세지를 콘솔뷰에 출력
         */

        //static Socket clientSocket;
        static string strIP = "127.0.0.1";
        static int port = 8082;
        //static byte[] sendBuffer;
        //static byte[] receiveBuffer;

        static User user;

        static void Main(string[] args)
        {
            //sendBuffer = new byte[128];
            //receiveBuffer = new byte[128];
            User user = new User(new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
            IPEndPoint endIP =new IPEndPoint(IPAddress.Parse(strIP), port);
            user.userSock.Connect(endIP);
            user.Receive();
            string receiveMessage = Encoding.Default.GetString(user.receiveBuffer);
            Console.WriteLine(receiveMessage);
            user.ClearReceiveBuffer();
            //길이 헤어 내용

        }

        public static void ReceiveCallBack(IAsyncResult ar)
        {

        }

        public static void SendCallBack(IAsyncResult ar)
        {

        }

        public static void PacketParser()
        {
            byte[] _PACKET = new byte[2];
            Array.Copy(user.receiveBuffer, 0, _PACKET, 0, 2);
        }


    }
}
