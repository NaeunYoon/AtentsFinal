using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atents_GameNetWork_03_Server
{
    
    internal class Program
    {
        static Socket serverSock;
        static string strIp="127.0.0.1";
        static int port = 8082;

        static Thread t1;
        static bool isInterrupt;
        static List<Socket> userList;

        static void Main(string[] args)
        {
            isInterrupt = false;
            userList = new List<Socket>();  //자료구조에 유저리스트 보관
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp), port);

            serverSock.Bind(ip);
            Console.WriteLine("Bind");

            ThreadStart threadStart = new ThreadStart(NewClient);
            t1 = new Thread(threadStart);
            t1.Start();
            //임시코드 : 사용자마다 버퍼가 각각 존재해야 한다
            byte[] receiveBuffer = new byte[128];
            byte[] sendBuffer = new byte[128];

            while (!isInterrupt)    //반복문을 멈출 방법이 없기 때문에 변수 사용
            {
                //예외처리
                try
                {
                    if(userList.Count > 0)
                    {
                        userList[0].Receive(receiveBuffer);
                        Array.Clear(sendBuffer, 0, sendBuffer.Length);  //샌드버퍼가 할당되지 않았지만 이전에 있던게 있을까봐 클리어
                        Array.Copy(receiveBuffer, sendBuffer, receiveBuffer.Length);  //원본길이의 길이만큼
                        userList[0].Send(sendBuffer);
                        Array.Clear(receiveBuffer, 0, receiveBuffer.Length);
                    }
                }
                catch(SocketException e)    //소켓 익셉션이 발생하면...네? 뭐라고요 아시발
                {
                    userList[0].Shutdown(SocketShutdown.Both);  //셧다운 먼저
                    userList[0].Close();   //클로즈
                    userList.RemoveAt(0);
                    Console.WriteLine(e.Message);
                }
                catch(ObjectDisposedException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {

                }

            }

            t1.Join();
            Console.WriteLine("Join");
            t1.Interrupt();
            Console.WriteLine("Interrupt");

        }


        static void NewClient()
        {
            while (!isInterrupt)
            {
            serverSock.Listen(100); //소켓을 수신상태로 설정(대기자수 100명) : 대기가 100이라는건
                                    //만약 3000명이 동접한다고 하면 3000명을 동시에 수용하는게 아니라 접속을 한명씩 처리한다는 의미
                                    //대기열이라는 개념임
                                    //3000명이 동접하면 100명은 대기열이고 나머지는 다시 접속을 시도해야함
            Console.WriteLine("Listen");    //유저가 접속을 하면 리스트에 유저들을 보관
            Socket user = serverSock.Accept();  //새로 만든 연결에 대한 새 소켓을 할당
            Console.WriteLine("Accept");
            userList.Add(user);


            string message = "안녕하세요";
            byte[] tmp = Encoding.Default.GetBytes(message); 
            user.Send(tmp);
            Thread.Sleep(10);

            }


        }

    }
}
