using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Atents_GameNetWork_02_TryExample
{
    internal class Program
    {
        static Socket serverSock;
        static string strIp = "127.0.0.1";
        static int port = 8082;
        static List<Socket> userList;       //접속한 유저를 리스트에 보관
        static void Main(string[] args)
        {
            userList = new List<Socket>();

            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp), port);

            serverSock.Bind(ip);
            Console.WriteLine("Bind");
            serverSock.Listen(100);
            Console.WriteLine("Listen");
            try
            {
                Socket user = serverSock.Accept();
                Console.WriteLine("Accept");
                Console.WriteLine("접속한 유저 " + user.RemoteEndPoint);
                string message = "안녕하세요";
                byte[] tmp = Encoding.Default.GetBytes(message);
                user.Send(tmp);

                while (true)
                {
                    //userList.Add(user);

                    byte[] receiveBuffer = new byte[128];
                    byte[] sendBuffer = new byte[128];
                    user.Receive(receiveBuffer);
                    Array.Clear(sendBuffer, 0, sendBuffer.Length);  //샌드버퍼가 할당되지 않았지만 이전에 있던게 있을까봐 클리어
                    Array.Copy(receiveBuffer, sendBuffer, receiveBuffer.Length);  //원본길이의 길이만큼
                    user.Send(sendBuffer);
                    Array.Clear(receiveBuffer, 0, receiveBuffer.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
             Console.WriteLine("프로그램 종료"); 
        }
    }
}
