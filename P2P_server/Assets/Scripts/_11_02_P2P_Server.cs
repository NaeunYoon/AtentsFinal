using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   //
using System.Net.Sockets;   //
using System.Threading; //
using System.Net;
using UnityEditor.ShortcutManagement;
using Unity.VisualScripting;

delegate void MakeObj();

public enum ePACKETTYPE
{
    NONE,
    PEERINFO =1000,
    CHARACTERSEELECT,
}

public class _11_02_P2P_Server : MonoBehaviour
{
    Socket serverSocket;
    string strIP;
    int port;
    
    byte[] sendBuffer;
    byte[] receiveBuffer;
    GameObject other;
    //Thread t;

    MakeObj doCreate;

    Queue<byte[]> packetQueue;

    ePACKETTYPE ePACKETTYPE;
    private void Awake()    //초기화 해주는 곳
    {
        //컴퓨터에서 아이피를 바로 받아와도 댐

        strIP = "127.0.0.1";
        port = 8082;    
        sendBuffer = new byte[128];
        receiveBuffer = new byte[128];

        doCreate = null;
        packetQueue = new Queue<byte[]>();

        //ThreadStart thread = new ThreadStart(resources);
        //t = new Thread(thread);
        ePACKETTYPE = ePACKETTYPE.NONE;
    }

    void Start()
    {
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(strIP), port);
        serverSocket.Bind(endpoint);
        serverSocket.Listen(100);
        serverSocket.BeginAccept(AddPeer,null); //start에서 실행해야 유니티가 실행되는 화면을 확일할 수 있다
    }
    public void ResourcesCube()
    {
        //Debug.Log("리소스 스레드");
        ////다른 피어가 연결되었을 경우, 서버 클라이언트 Cube를 리소스 폴더에서 로드하여 인스턴스 생성
        //GameObject obj = Resources.Load<GameObject>("Character/Cube");
        //Instantiate(obj);
        //Debug.Log("큐브 생성");        

        GameObject tmp = Resources.Load<GameObject>("Cube");
        if (tmp != null)
        {
            other = GameObject.Instantiate<GameObject>(tmp);
        }     /*=> 같은 공간에 있는 스레드가 아니라서 생성되지 않는다*/

        GameObject myChar = Instantiate<GameObject>(tmp);
        doCreate -= ResourcesCube;

        serverSocket.BeginReceive(receiveBuffer,0,receiveBuffer.Length,SocketFlags.None, ReceiveCallBack,null);    //이제 상대방과 통신을 할 수 있음
    }

    public void ReceiveCallBack(IAsyncResult ar)
    {
        //queue에 enqueue 보냈으니까 큐에 저장한다
        byte[] tmp = new byte[128];
        Array.Copy(receiveBuffer,tmp,receiveBuffer.Length);
        Array.Clear(receiveBuffer,0,receiveBuffer.Length);
        packetQueue.Enqueue(tmp);   //패킷 큐에 있는 내용을 넣어준다
        serverSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
    }

    public void AddPeer(IAsyncResult ar)
    {
        Socket otherPeer = serverSocket.EndAccept(ar);
        //ThreadStart thread = new ThreadStart(resources);
        //t = new Thread(thread);
        //t.Start();
        Debug.Log(otherPeer.RemoteEndPoint +"님이 접속했습니다");
        doCreate = ResourcesCube;
    }
    
    void Update()
    {
        if(doCreate != null)
        {
            doCreate();
        }

        if (packetQueue.Count > 0)
        {
            byte[] data = packetQueue.Dequeue();
            //앞의 2바이트는 패킷타입(2), 내용(126), 이 순서로 데이터를 파싱
            //패킷타입 2바이트 가져오는 코드
            byte[] _Packet = new byte[2];
            Array.Copy(data, 0, _Packet, 0, 2);

            short packetType = BitConverter.ToInt16(_Packet,0);
            switch ((int)packetType)
            {
                case (int)ePACKETTYPE.PEERINFO:
                          
                    break;

                case (int)ePACKETTYPE.CHARACTERSEELECT:
                            
                    break;
            }
        }

        //보내는 사람 입장에서는 전송을 하고 응답을 받았을때 엔큐 하고
        //받는 사람은 받았을 때 엔큐하고
        //업데이트 문에서는 엔큐를 꺼내서 동기화를 한다

        //큐에 있는 내용을 하나씩 가져온다
    }
}
