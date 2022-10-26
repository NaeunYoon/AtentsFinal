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
            Socket userSock = serverSoket.EndAccept(ar);
            Console.WriteLine("접속한 사용자"+ userSock.RemoteEndPoint);
            string message = "안녕";
            byte[] tmp = Encoding.Default.GetBytes(message);
            userSock.Send(tmp);
            userSock.BeginReceive(receiveBuffer,0,receiveBuffer.Length,SocketFlags.None, ReceiveCallBack,userSock);
                                                                                        //작업이 완료 되었을 때 콜백함수,
                                                                                        //콜백함수에 전달되는 매개변수
                                                                                        //받은걸 버퍼에 보관 / 끝아면 자동호출
            //
        }
        static void ReceiveCallBack(IAsyncResult ar)
        {
            Socket userSock = (Socket)ar.AsyncState;    //유저소켓이 넘어옴
            Array.Copy(receiveBuffer, sendBuffer, receiveBuffer.Length);
            Array.Clear(receiveBuffer,0,receiveBuffer.Length);//복사했으니까 지움..
            userSock.BeginSend(sendBuffer,0,sendBuffer.Length,SocketFlags.None, SendCallBack, userSock);
            //전송이 끝나면 자동으로 샌드콜백 자동호출
        }
        static void SendCallBack(IAsyncResult ar)
        {
            Socket userSock = (Socket)ar.AsyncState;
            int sendLength = userSock.EndSend(ar);  //몇 바이트를 보냈는지 알아오기 위한 방법
            //유저소켓을 다시 리시브 상태로 돌려놓음
            userSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, userSock);

        }
    }
}
