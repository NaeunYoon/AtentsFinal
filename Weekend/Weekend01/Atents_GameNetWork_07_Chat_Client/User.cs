using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Atents_GameNetWork_07_Chat_Client;


namespace UserInfo
{
    class User
    {

        //소켓 송신 수신버퍼를 알고 있어야함
        //쓰레드 안쓸거라 지우고, newclient 도 지웠음

        public Socket userSock;

        public int socketHandle;

        public byte[] sendBuffer;
        public byte[] receiveBuffer;
        private const short MAXBUFSIZE = 128;
        //List<User> userList;


        public User(int _socketHandle)   //기본클래스는 자신이기 때문에 소켓이 필요없음
        {
            //유저마다 유저 리스트를 각각 하나씩 가지고 있는 것.
            //전부 리스트를 갱신한다
            //사실 핸들이 필요하다함...

            sendBuffer = new byte[MAXBUFSIZE];
            receiveBuffer = new byte[MAXBUFSIZE];

            socketHandle = _socketHandle;
        }



        public User(Socket _sock)   //리스트 인자도 지움
        {
            userSock = _sock;
            sendBuffer = new byte[MAXBUFSIZE];
            receiveBuffer = new byte[MAXBUFSIZE];

        }

        public void ClearSendBuffer()   //버퍼를 지워주는 함수
        {
            Array.Clear(sendBuffer, 0, sendBuffer.Length);
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
            //userSock.Receive(receiveBuffer);
            /*Program.messageQueue.Enqueue(this);*/ //이건 뭐야..
            userSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, Program.ReceiveCallBack, this);

        }
        public void Send()
        {
            //userSock.Send(sendBuffer);
            userSock.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, Program.SendCallBack, this);
        }

        public void SendSyncronous()
        {
            userSock.Send(sendBuffer);
        }
        public void ClearBuffer()
        {
            Array.Clear(sendBuffer,0,sendBuffer.Length);
            Array.Clear(receiveBuffer, 0, receiveBuffer.Length);
        }

        public void Close()
        {
            Console.WriteLine($"{userSock.RemoteEndPoint}님이 접속을 종료하셨습니다");
            userSock.Shutdown(SocketShutdown.Both);
            userSock.Close();
        }
    }

}
