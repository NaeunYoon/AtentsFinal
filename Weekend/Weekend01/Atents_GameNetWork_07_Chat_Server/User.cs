using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Atents_GameNetWork_07_Chat_Server;


namespace UserInfo
{
    class User
    {

        //소켓 송신 수신버퍼를 알고 있어야함
        //쓰레드 안쓸거라 지우고, newclient 도 지웠음

        public Socket userSock;
        public byte[] sendBuffer;
        public byte[] receiveBuffer;
        private const short MAXBUFSIZE = 128;
        //List<User> userList;

        //유저마다 자신의 상태가 있고 상태에 따라 패킷을 보낸다


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
        public void Receive(User _user)
        {
            //userSock.Receive(receiveBuffer);
            /*Program.messageQueue.Enqueue(this);*/ //이건 뭐야..
            userSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, Program.ReceiveCallBack, _user);

        }
        public void Send(User _user)
        {
            //userSock.Send(sendBuffer);
            userSock.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, Program.SendCallBack, _user);
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
