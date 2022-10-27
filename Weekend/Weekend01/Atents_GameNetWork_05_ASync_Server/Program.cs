using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atents_GameNetWork_05_ASync_Server
{//static 함수 : 유저클래스 내부의 함수를 콜백함수로 사용할 수도 있다
 //아래의 static 함수를 콜백함수로 작성한 것 : 상당한 의미를 시사하고 있음 
 //유저 안에 사용자 정의 함수를 콜백함수로 사용한거 / static 함수를 콜백함수로 사용하는 것의 차이
 //static 때문이다.

    /*
    BEGIN 이라고 시작하는 함수를 작성하면 지시를 하고 나느 ㄴ내 일을 함..
    BEGINSEND 하면 전송하는거니까.. 전송이 완료되면 콜백함수가 자동으로 호출된다
    우리가 작성한 함수를 콜백함수로 작성할 수 있음
    BEGINSEND -> SEND 완료 -> 콜백함수 자동 호출
    BEGINRECEIVE -> RECEIVE 완료 
    중요한건 콜백함수를 STAIC으로 사용한다는 것임. STATIC의 특징은 클래스 단위로 사용, STATIC은 1개임
    객체가 여러개라고 하더라도 STATIC함수는 공유해서 사용하는것임

    콜백함수를 하나로 사용하는거임 ㅇㅇ..
    BEGINDRECEIVE에서 USER클래스를 콜백하면 USER클래스의 인스턴스들이 호출된다
    사용자 클래스 안에 STATIC이 아닌 다른 함수를 사용했으면 계속 메모리 할당 해줘야함
    유저가 10명이면 유저 인스턴스 안에 함수가 주기적으로 호출되는거임
    자신의 인스턴스 안에 함수를 호출하는게 아니라 콜백함수를 STATIC으로 설정해서 한 개의 함수를 돌려서 사용한 것
    그러다 보니 함수의 호출이 하나의 함수로 콜백을 처리했기 때문에 인스턴스 안의 각각의 자신의 콜백함수를 호출한게 아니라
    STATIC으로 설정한 하나를 돌려서 사용한건데 정상적인 작동이 가능한가? 가능하다. 쓰레드는 CPU 스케쥴링을 하기 때문에
    주기적으로 번갈아가면서 실행 그래서 콜백 또한 각각 여러개 존재할 이유가 없다고 생각해도 무방하다
    어차피 쓰레드 함수들은 동시에 호출되는게 아님. 함수가 호출되고 있는 도중에 ㄷ다른 함수가 동시에 호출될 일은 없다
    그래서STATIC으로 사용하는 것이 오히려 성능면으로는 좋음
    유일한 하나의 함수를 호출하는 것은 효율성 측면에서 STATIC 함수가 더 유용하다.
     
    STATIC으로 하면 하나의 함수를 각각 다른 쓰레드에서 사용하는 것이다

     static 함수에서는 static 멤버변수만 사용할 수 있음
     */



    internal class Program
    {
        static Socket serverSoket;
        static string strIp = "127.0.0.1";
        static int port = 8082;
        static Thread t1;
        //static bool isInterrupted;

        static byte[] receiveBuffer;
        static byte[] sendBuffer;

        static void Main(string[] args)
        {
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
            while (true)
            {
            serverSoket.BeginAccept(AcceptCallBack, null);
            Thread.Sleep(10);
            }
        }
        static void AcceptCallBack(IAsyncResult ar)
        {
            Console.WriteLine("Accept");
            Socket userSock = serverSoket.EndAccept(ar);    //소켓할당
            Console.WriteLine("접속한 사용자 :"+ userSock.RemoteEndPoint + " 유저 ID :"+ userSock.Handle);  
            string message = "안녕";
            byte[] tmp = Encoding.Default.GetBytes(message);
            
            //접속사용자에 대한 유저클래스의 인스턴스 생성 -> 비긴리시브 함수 주석처리
            User user = new User(userSock);
            user.Receive();

            userSock.Send(tmp);
            //userSock.BeginReceive(receiveBuffer,0,receiveBuffer.Length,SocketFlags.None, ReceiveCallBack,userSock);
                                                                                        //작업이 완료 되었을 때 콜백함수,
                                                                                        //콜백함수에 전달되는 매개변수
                                                                                        //받은걸 버퍼에 보관 / 끝나면 자동호출
                                                                                        //접속 요청을 한 사용자마다 비긴리시브 호출

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
                user.CopyReceiveToSendBuffer();
                user.Send();

            }catch(SocketException e)
            {
                Console.WriteLine(e.Message);
                user.Close();
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
            user.Receive();

            }catch(SocketException e)
            {
                Console.WriteLine(e.Message);
                user.Close();
            }

        }
    }
}
