using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockTest_05_MultiClients_01_S
{
    internal class User
    {
        public Socket userSocket;
        public byte[] sendBuffer;
        public byte[] receiveBuffer;
        public const int MaxByfferSize = 128;
        List<User> userList = new List<User>();
        Thread t;

        public User(Socket _userSocket, List<User> _userList)
        {
            userSocket = _userSocket;
            sendBuffer = new byte[MaxByfferSize];
            receiveBuffer = new byte[MaxByfferSize];
            userList = _userList;

        }


    }



}
