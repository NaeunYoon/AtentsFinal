using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_05_ASync_Client
{
    internal class Program
    {
        static string strIp = "127.0.0.1";

        

        static Socket clientSock;
        static int port = 8082;
        static void Main(string[] args)
        {
            try
            {
                clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp), port);

                /*byte[] array; *//*= new byte[128];*/
                //IPAddress obj = new IPAddress(new byte[]{127,0,0,1});
                //IPAddress OBJ1 = new IPAddress(127001);
                //IPAddress o = new IPAddress(,,)

                clientSock.Connect(ip);                 // 원격 호스트에 대한 연결을 설정
                byte[] receiveBuffer = new byte[128];
                clientSock.Receive(receiveBuffer);
                string receiveMessage = Encoding.Default.GetString(receiveBuffer);
                Console.WriteLine(receiveMessage);
                Array.Clear(receiveBuffer, 0, receiveBuffer.Length);  // Receive버퍼 clear
                string userMessage = string.Empty;
                byte[] sendBuffer;
                while (!userMessage.Contains("!"))
                {
                    userMessage = Console.ReadLine();
                    sendBuffer = Encoding.Default.GetBytes(userMessage);
                    clientSock.Send(sendBuffer);    // 입력한 메시지를 서버로 전송
                    Console.WriteLine("보낸메시지 = " + userMessage);
                    Array.Clear(sendBuffer, 0, sendBuffer.Length);  // Send버퍼 clear
                    clientSock.Receive(receiveBuffer);              // 서버에서 Send해야만 Receive
                    receiveMessage = Encoding.Default.GetString(receiveBuffer);
                    Console.WriteLine("받은메시지 = " + receiveMessage);
                    Array.Clear(receiveBuffer, 0, receiveBuffer.Length);  // Send버퍼 clear
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }
    }
}
