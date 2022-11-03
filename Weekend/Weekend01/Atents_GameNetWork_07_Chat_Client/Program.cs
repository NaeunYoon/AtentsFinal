using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserInfo;

namespace Atents_GameNetWork_07_Chat_Client
{
    public enum ePACKETTYPE
    {   eWELCOME=1000,  //1000
        eUSERINFO,    //사용자정보(개인정보) 1001
        eCONVERSATION  //채팅 추가 1002
    }
    public struct WELCOME
    {
        public int userID;  //:0
        public string message;//:1
    }

    public struct USERINFO  //구조체 정의 : 구조체의 값을 채워서 보내준다
    {
        public int userID;  //서버에서 할당한 ID :0
    }


    internal class Program
    {
        /*
         통신의 절차를 생각해보자 흠.. 비동기로 할거임
        1. 소켓을 생성하고
        2. connect 하고
        3. 서버로부터 메세지를 수신받는다 (할당받은 id를 추가해서 전송)
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
        static List<User> userList;

        static void Main(string[] args)
        {
            userList = new List<User>();
            //sendBuffer = new byte[128];
            //receiveBuffer = new byte[128];
            user = new User(new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
            IPEndPoint endIP =new IPEndPoint(IPAddress.Parse(strIP), port);

            user.userSock.Connect(endIP);
            user.userSock.Receive(user.receiveBuffer);
            PacketParser();
            user.ClearReceiveBuffer();
            user.Receive(user); //갑자기 비동기 방식으로 수신;;;;

            //user.userSock.Receive(user.receiveBuffer);
            //PacketParser();
            //user.ClearReceiveBuffer();
            //user.Receive(); //동기방식으로 메세지를 받았음

            //PacketParser();

            //user.ClearReceiveBuffer();

            //string receiveMessage = Encoding.Default.GetString(user.receiveBuffer);
            //Console.WriteLine(receiveMessage);
            //user.ClearReceiveBuffer();
            //길이 헤드 내용

            string userMessage = string.Empty;

            while (!userMessage.Contains("!"))
            {
                userMessage = Console.ReadLine();

                byte[] _PACKETTYPE = BitConverter.GetBytes((ushort)ePACKETTYPE.eCONVERSATION);
                byte[] tmp = Encoding.Default.GetBytes(userMessage);

                Array.Copy(_PACKETTYPE,0, user.sendBuffer,0, _PACKETTYPE.Length);
                Array.Copy(tmp, 0, user.sendBuffer, 2, tmp.Length);
                user.Send(user);
                //user.ClearSendBuffer();

            }
            user.Close();

        }

        public static void ReceiveCallBack(IAsyncResult ar)
        {
            PacketParser(); //패킷을 받을 때마다 패킷이 무엇을 해야 할지 알려줌
            user.Receive(user);
        }

        public static void SendCallBack(IAsyncResult ar)
        {
            user.ClearSendBuffer();
            user.Receive(user);
        }

        public static void PacketParser()
        {
            byte[] _PACKETTYPE = new byte[2];   //패킷헤더는 항상 2바이트가 추가됨
            Array.Copy(user.receiveBuffer, 0, _PACKETTYPE, 0, _PACKETTYPE.Length);   //0 : 시작인덱스, 2: 바이트
                                                                //(리시브버퍼에 있는걸 0번부터 2바이트만큼 패킷 배열에 복사)
            short packetType = BitConverter.ToInt16(_PACKETTYPE, 0);    //v패킷타입을 정수형으로 변환

            switch (packetType)
            {
                case (int)ePACKETTYPE.eWELCOME: //웰컴메세지 보낼 때
                    {

                        byte[] _uid = new byte[4];  //id 는 정수형 이므로 4바이트
                        byte[] _message = new byte[122];    //실제 대화내용 2바이트, 4바이트 뺴니까 실제로 122바이트 (메시지는 대화내용)
                        Array.Copy(user.receiveBuffer,2, _uid, 0/*4*/, _uid.Length);
                        //배옆에서 앞의 2바이트 처음부터 읽음 (카피한부분) 시작인덱스 0부터1까지 읽은거 ㅇㅇ
                        //그 다음은 2바이트부터 ㅇ4바이트를 읽음 (시작인덱스 2부터 시작)
                        //배열 2번째부터 4바이트 읽겠다
                        Array.Copy(user.receiveBuffer, 6, _message, 0, _message.Length);
                        //6바이트가 시작 인덱스고 122의 길이만큼 읽겠다
                        //전체 배열에 있는걸 분리해서 저장한거임

                        //receive 버퍼에 있는걸 길이만큼 복사한거임
                        int uid = BitConverter.ToInt32(_uid, 0); //바이트를 정수로 바꿈 (서버에서 할당한 나의 아이디)
                        string message = Encoding.Default.GetString(_message); //바이트를 정수로 바꿈 (바이트 메시지를 문자열로 바꿈) /안녕하세요
                            Console.WriteLine(message);
                    }
                        break;

                case (int)ePACKETTYPE.eUSERINFO:
                    {
                        byte[] _uid = new byte[4];  //id 는 정수형 이므로 4바이트
                        Array.Copy(user.receiveBuffer, 2, _uid, 0/*4*/, _uid.Length);
                        int uid = BitConverter.ToInt32(_uid, 0);
                        User other = new User(uid); //유저클래스의 인스턴스를 생성하고
                        userList.Add(other);    //유저리스트에 넣어줌
                        Console.WriteLine(uid+"님의 정보를 수신했습니다");
                            
                    }
                    break;

                case (int)ePACKETTYPE.eCONVERSATION:
                    {
                        Console.WriteLine("대화내용을 수신했습니다");
                    }
                    break;
            }
        }


    }
}
