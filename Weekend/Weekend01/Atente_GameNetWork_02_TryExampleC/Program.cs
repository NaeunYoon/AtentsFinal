using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Atente_GameNetWork_02_TryExampleC
{
    internal class Program
    {
        static Socket clientSock;
        static string strIp = "127.0.0.1";
        static int port = 8082;
        static void Main(string[] args)
        {
            try
            {
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp), port);

            clientSock.Connect(ip); //서버에 접속 요청 (원격 호스트에 대한 연결을 설정)

            byte[] receiveBuffer = new byte[1024];
            clientSock.Receive(receiveBuffer);  //데이터 수신 -> 안녕하세요 메세지가 바이트 배열로 저장

            string receiveMessage = Encoding.Default.GetString(receiveBuffer);  //문자열로 변환해서
            Console.WriteLine(receiveMessage);  //출력

            Array.Clear(receiveBuffer,0,receiveBuffer.Length);  //receive버퍼에서 받은 데이터 지워서 초기화

                string userMessage = string.Empty;
                byte[] sendBuffer;
                while (!userMessage.Contains("!"))
                {
                    userMessage = Console.ReadLine();           
                    sendBuffer= Encoding.Default.GetBytes(userMessage); //내가 입력한 메시지를 바이트배열로 바꾼다
                    clientSock.Send(sendBuffer);    //클라이언트가 입력한 메세지를 서버에 send 한다
                    //Console.WriteLine(userMessage);
                    Console.WriteLine("보낸 메세지 " + userMessage);
                    Array.Clear(sendBuffer, 0, sendBuffer.Length);    //send버퍼 지워서 초기화해준다
                    clientSock.Receive(receiveBuffer); //서버에서 send해야만 receive / 데이터를 수신한다 (동기함수)

                    receiveMessage = Encoding.Default.GetString((receiveBuffer));   //받은 데이터를 문자열로 바꿔주고
                    Console.WriteLine("받은 메세지 "+ receiveMessage);   //출력함
                    Array.Clear(receiveBuffer, 0, receiveBuffer.Length);    //re버퍼 지워서 초기화해준다
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
