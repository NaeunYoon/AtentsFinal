using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class _11_02_P2P_Client : MonoBehaviour
{
    Socket clientSocket;
    string strIP;
    int port;
    byte[] sendBuffer;
    byte[] receiveBuffer;
    private void Awake()
    {   
        strIP = "127.0.0.1";
        port = 8082;
        sendBuffer = new byte[128];
        receiveBuffer = new byte[128];
    }
    void Start()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(strIP),port);
        clientSocket.Connect(endPoint); //동기함수로 받기
        Debug.Log("connect");
        ResourcesRoad();

    }
    public void ResourcesRoad()
    {
        GameObject obj = Resources.Load<GameObject>("Character/Cube");
        Instantiate(obj);
        Debug.Log("큐브 생성");
    }
    
    void Update()
    {
        
    }
}
