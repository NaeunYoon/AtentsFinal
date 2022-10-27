using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace atents10
{
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
            Console.WriteLine("접속한 사용자 :" + userSock.RemoteEndPoint + " 유저 ID :" + userSock.Handle);
            string message = "안녕";
            byte[] tmp = Encoding.Default.GetBytes(message);


            User user = new User(userSock);
            user.Receive();

            userSock.Send(tmp);


        }
        public static void ReceiveCallBack(IAsyncResult ar)
        {
            User user = (User)ar.AsyncState;
            try
            {

                user.CopyReceiveToSendBuffer();
                user.Send();

            }
            catch (SocketException e)
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
 
                user.ClearSendBuffer();
                user.Receive();

            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
                user.Close();
            }

        }
    }
}
