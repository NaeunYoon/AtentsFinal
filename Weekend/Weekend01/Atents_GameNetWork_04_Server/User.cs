using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Atents_GameNetWork_04_Server;

namespace Atents_GameNetWork_04_Server
{
    internal class User/* : IDisposable*/
    {
        //소켓 송싱 수신버퍼를 알고 있어야함

        public Socket userSock;
        public byte[] sendBuffer;
        public byte[] receiveBuffer;
        private const short MAXBUFSIZE = 128;
        List<User> userList;
        Thread t1;

        

        public User(Socket _sock, List<User> _userList)
        {
            userSock = _sock;
            sendBuffer = new byte[MAXBUFSIZE];
            receiveBuffer = new byte[MAXBUFSIZE];
            userList = _userList;
            ThreadStart threadStart = new ThreadStart(NewClient);
            t1 = new Thread(threadStart);
            t1.Start();

        }
        public void NewClient()
        {
            while (true)
            {
                try
                {
                    Receive();
                    ClearSendBuffer();
                    CopyReceiveToSendBuffer();
                    Send();
                    ClearReceiveBuffer();

                    Thread.Sleep(10);

                }
                catch (SocketException e)
                {
                    Close(); ;
                    userList.Remove(this);
                    Console.WriteLine(e.Message);
                    t1.Join();  //자신의 스레드 안에서 종료하는건 위험할 수 있음
                    t1.Interrupt();
                    //throw;
                }
                catch(ObjectDisposedException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {

                }
            }
        }
        public void ClearSendBuffer()   //버퍼를 지워주는 함수
        {
            Array.Clear(sendBuffer,0,sendBuffer.Length);
        }
        public void ClearReceiveBuffer()   //버퍼를 지워주는 함수
        {
            Array.Clear(receiveBuffer, 0, receiveBuffer.Length);
        }
        public void CopyReceiveToSendBuffer()    //버퍼에 있는 내용을 복사해줌
        {
            Array.Copy(receiveBuffer, sendBuffer, receiveBuffer.Length);    //소스의 길이만큼 카피해준다
        }
        //public void Dispose()   //인터페이스 (유저 끊음)
        //{
        //    userSock.Shutdown(SocketShutdown.Both);
        //    userSock.Close();
        //}
        public void Receive()
        {
            userSock.Receive(receiveBuffer);
            /*Program.messageQueue.Enqueue(this);*/ //이건 뭐야..

        }
        public void Send()
        {
            userSock.Send(sendBuffer);
        }
        public void Close()
        {
            Console.WriteLine($"{userSock.RemoteEndPoint}님이 접속을 종료하셨습니다");
            userSock.Shutdown(SocketShutdown.Both);
            userSock.Close();
        }


    }
}
