using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MockTest_05_MultiClients_01_S
{
    internal class Program
    {
        static Socket serverSocket;
        static int port = 8082;
        static string strIp = "127.0.0.1";

        static Thread t;
        static List<User> userList;

        static void Main(string[] args)
        {   userList = new List<User>();

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endIp = new IPEndPoint(IPAddress.Parse(strIp), port); 

            serverSocket.Bind(endIp);
            Console.WriteLine("BIND");

            ThreadStart threadStart = new ThreadStart(NewClient);
            t= new Thread(threadStart);
            t.Start();

            try
            {
                while(true){

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            t.Join();
            Console.WriteLine("JOIN");
            t.Interrupt();
            Console.WriteLine("INTERRUPT");

        }

        static void NewClient()
        {
            while(true)
            {
            serverSocket.Listen(100);
            Console.WriteLine("LISTEN");
            Socket userSock = serverSocket.Accept();
            Console.WriteLine("ACCEPT");

            User user = new User();
            userList.Add(user);

            string message = "안녕하세요";
            byte[] sendBuffer = new byte[128];
            sendBuffer = Encoding.Default.GetBytes(message);
            userSock.Send(sendBuffer);
            Console.WriteLine("서버가 보낸메세지 : "+ message);

            }

        }
    }
}