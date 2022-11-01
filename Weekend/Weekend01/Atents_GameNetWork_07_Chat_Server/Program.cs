using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInfo;

namespace Atents_GameNetWork_07_Chat_Server
{
    public enum ePACKETTYPE //클라이언트와 서버는 구조체가 같아야 함 (또는 별도의 네임스페이스에 보관)
    {
        eWELCOME = 1000,
        eUSERINFO,    //사용자정보(개인정보)
        eCONVERSATION
    }

    public struct USERINFO  //구조체 정의 : 구조체의 값을 채워서 보내준다
    {
        public int userID;  //서버에서 할당한 ID

    }

    public struct WELCOME
    {
        public int userID;
        public string message;
    }

    internal class Program
    {
        static Socket serverSoket;
        static string strIp = "127.0.0.1";
        static int port = 8082;
        static Thread t1;
        //static bool isInterrupted;
        static List<User> userList;
        static bool interrupt;

        static byte[] receiveBuffer;
        static byte[] sendBuffer;

        static void Main(string[] args)
        {
            userList = new List<User>();
            sendBuffer = new byte[128];
            receiveBuffer = new byte[128];

            serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endIP = new IPEndPoint(IPAddress.Parse(strIp), port);
            serverSoket.Bind(endIP);
            Console.WriteLine("bind");
            serverSoket.Listen(100);
            Console.WriteLine("Listen");
            ThreadStart threadStart = new ThreadStart(NewClient);
            t1 = new Thread(threadStart);
            t1.Start();
            Console.WriteLine("쓰레드시작");
            t1.Join();
            t1.Interrupt();
        }
        static void NewClient()
        {
            while (!interrupt)
            {
                try
                {
                    
                    serverSoket.BeginAccept(AcceptCallBack, null);
                    Thread.Sleep(10);

                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void AcceptCallBack(IAsyncResult ar)
        {
            Console.WriteLine("Accept");
            Socket userSock = serverSoket.EndAccept(ar);    //소켓할당
            User user = new User(userSock);
            //userList.Add(user); //사용자가 접속할 때마다 리스트에 add
            Console.WriteLine("접속한 사용자 :" + userSock.RemoteEndPoint + " 유저 ID :" + userSock.Handle);
            //string message = "안녕";
            //byte[] tmp = Encoding.Default.GetBytes(message);

            //접속사용자에 대한 유저클래스의 인스턴스 생성 -> 비긴리시브 함수 주석처리
            WelcomePacket(user);
            SendUserInfo(user); //로그인 속도를 늦추더라도, 코드를 쉽게 작성하고자 이렇게 작성
            userList.Add(user); //사용자가 접속할 때마다 리스트에 add
            user.Receive(user);

            //userSock.Send(tmp);
            //userSock.BeginReceive(receiveBuffer,0,receiveBuffer.Length,SocketFlags.None, ReceiveCallBack,userSock);
            //작업이 완료 되었을 때 콜백함수,
            //콜백함수에 전달되는 매개변수
            //받은걸 버퍼에 보관 / 끝나면 자동호출
            //접속 요청을 한 사용자마다 비긴리시브 호출

        }

         static void WelcomePacket(User _user)
        {   //eWELCOME

            _user.ClearBuffer();

            byte[] _PACKETTYPE = BitConverter.GetBytes((ushort)ePACKETTYPE.eWELCOME);   //열거체를 2바이트 배열로 넣음
            byte[] _uid = BitConverter.GetBytes((int)_user.userSock.Handle);
            byte[] _message = Encoding.Default.GetBytes("안녕하세요");
            //각각의 바이트 배열에 넣음
            //이제 버퍼에 복사

            Array.Copy(_PACKETTYPE, 0, _user.sendBuffer, 0, _PACKETTYPE.Length);    //2
            Array.Copy(_uid,0,_user.sendBuffer, 2, _uid.Length);    //4 샌드버퍼의 몇번쨰 인덱스부터 넣을거임. 아이디는 012-> 3번쨰부터 4바이트 넣음
            Array.Copy(_message, 0, _user.sendBuffer, 6, _message.Length);  //6 
            _user.SendSyncronous();

            //_user.Send();
        }


        static void SendUserInfo(User _user) //지금 접속한 유저에게 다른 사용자 정보를 보내는거
        {
            //1. 접속한 유저에게 다른 사람의 정보를 전송해준다
            //2. 다른 유저에게 현재 접속한 사람을 전송한다
            _user.ClearBuffer();

            foreach (User one in userList)
            {
            byte[] _PACKETTYPE = BitConverter.GetBytes((ushort)ePACKETTYPE.eUSERINFO);   //열거체를 2바이트 배열로 넣음
            byte[] _uid = BitConverter.GetBytes((int)one.userSock.Handle);
            //각각의 바이트 배열에 넣음
            //이제 버퍼에 복사

            Array.Copy(_PACKETTYPE, 0, _user.sendBuffer, 0, _PACKETTYPE.Length);    //2
            Array.Copy(_uid, 0, _user.sendBuffer, 2, _uid.Length);    //4 샌드버퍼의 몇번쨰 인덱스부터 넣을거임. 아이디는 012-> 3번쨰부터 4바이트 넣음

                //_user.Send();
                _user.SendSyncronous();
            }

            //2. 다른 유저에게 현재 접속한 사람의 정보를 전송
            foreach(User one in userList)
            {
                byte[] _PACKETTYPE = BitConverter.GetBytes((ushort)ePACKETTYPE.eUSERINFO);   //열거체를 2바이트 배열로 넣음
                byte[] _uid = BitConverter.GetBytes((int)_user.userSock.Handle);
                //각각의 바이트 배열에 넣음
                //이제 버퍼에 복사

                Array.Copy(_PACKETTYPE, 0, one.sendBuffer, 0, _PACKETTYPE.Length);    //2
                Array.Copy(_uid, 0, one.sendBuffer, 2, _uid.Length);

                one.SendSyncronous();
            }

        }

        public static void PacketParser(User _user)
        {
            byte[] _PACKETTYPE = new byte[2];   //패킷헤더는 항상 2바이트가 추가됨
            Array.Copy(_user.receiveBuffer, 0, _PACKETTYPE, 0, _PACKETTYPE.Length);   //0 : 시작인덱스, 2: 바이트
                                                                                     //(리시브버퍼에 있는걸 0번부터 2바이트만큼 패킷 배열에 복사)
            short packetType = BitConverter.ToInt16(_PACKETTYPE, 0);    //v패킷타입을 정수형으로 변환

            switch (packetType)
            {
                case (int)ePACKETTYPE.eCONVERSATION:
                    //유저의 수신버퍼에 있는 내용을 모든 유저의 송신버퍼로 복사한 후 전송
                    foreach(User one in userList)
                    {
                        Array.Copy(_user.receiveBuffer, one.sendBuffer, _user.receiveBuffer.Length);
                        one.Send(_user);
                        Array.Clear(_user.receiveBuffer,0,_user.receiveBuffer.Length);
                    }

                    break;
            }

        }

        public static void ReceiveCallBack(IAsyncResult ar)
        {
            User user = (User)ar.AsyncState;
            try
            {
                //Socket userSock = (Socket)ar.AsyncState;    //유저소켓이 넘어옴
                //Array.Copy(receiveBuffer, sendBuffer, receiveBuffer.Length);
                //Array.Clear(receiveBuffer,0,receiveBuffer.Length);//복사했으니까 지움..
                //userSock.BeginSend(sendBuffer,0,sendBuffer.Length,SocketFlags.None, SendCallBack, userSock);
                //전송이 끝나면 자동으로 샌드콜백 자동호출

                //이전 에코서버임
                //user.CopyReceiveToSendBuffer();
                //user.Send();

                //받은 대화내용을 모든 유저에게 전송
                Console.WriteLine("대화내용 수신");
                PacketParser(user);
                user.Receive(user);
            }
            catch (SocketException e)
            {
                //User finduser = userList.Find(o => o.Equals(user));
                //if (finduser != null)
                //{
                try
                {

                    userList.Remove(user);
                    user.Close();
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //}
                Console.WriteLine(e.Message);
            }
            catch (ObjectDisposedException e)
            {

            }
        }
        public static void SendCallBack(IAsyncResult ar)
        {
            User user = (User)ar.AsyncState;
            try
            {
                //Socket userSock = (Socket)ar.AsyncState;
                //int sendLength = userSock.EndSend(ar);  //몇 바이트를 보냈는지 알아오기 위한 방법
                ////유저소켓을 다시 리시브 상태로 돌려놓음
                //userSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, userSock);
                user.ClearSendBuffer();
                
                //user.Receive();

            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
                user.Close();
            }

        }
    }
}
