using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;   // 1. 유징 3개 해주기
using System.Threading; //
using System.Net.Sockets;   //
using System.Data;
using Unity.VisualScripting;
using System;
using System.Net.WebSockets;
using Game.Packet;
using UnityEngine.UIElements;
using System.Linq;

delegate void Do(); //8 createobj 받을 델리게이트
delegate void DOMOVE(int id, float x, float y, float z);
public class _11_04_Server : MonoBehaviour
{
    Socket serverSocket;        //2.
    int port;
    string strIP;
    byte[] receiveBuffer;
    byte[] sendBuffer;

    Socket clientSocket;    //6

    Do doCreate;    //9 델리게이트 변수
    DOMOVE doMove;

    public Queue<byte[]> queue; //14

    public class DelagateWrap   //24
    {
        CHARMOVE charmove;
        DOMOVE doMove;
    }

    GameObject mine;    //25
    GameObject other;


    private void Awake()
    {
        port = 8082;        //3.
        strIP = "127.0.0.1";
        receiveBuffer = new byte[128];
        sendBuffer = new byte[128];   
        queue = new Queue<byte[]>(); //15
        
    }

    void Start()
    {
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //4
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(strIP), port);
        serverSocket.Bind(endPoint);
        Debug.Log("Bind");
        serverSocket.Listen(10);
        Debug.Log("Listen");
        serverSocket.BeginAccept(AddPeer,null); //5.

    }

    public void AddPeer(IAsyncResult ar)
    {
        clientSocket = serverSocket.EndAccept(ar); //7.
        Debug.Log(clientSocket.RemoteEndPoint+"님이 접속하셨습니다");
        doCreate = CreateOBJ;//10
        clientSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None,ReceiveCallBack, clientSocket);//11

    }

    public void ReceiveCallBack(IAsyncResult ar)//12
    {
        Socket clientSocket = (Socket)ar.AsyncState;
        byte[] tmp = new byte[128];
        Array.Copy(sendBuffer, 0, tmp, 0, sendBuffer.Length);
        Array.Clear(sendBuffer, 0, sendBuffer.Length);//13
        queue.Enqueue(tmp);//16
        clientSocket.BeginReceive(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, ReceiveCallBack, clientSocket);   

        
    }
     public void CreateOBJ()//11
    {
        GameObject obj = Resources.Load<GameObject>("Cube");
        if(obj != null)
        {
           GameObject mine = Instantiate<GameObject>(obj);
        }
        GameObject other = Instantiate<GameObject>(obj);
        doCreate -= CreateOBJ;

    }

    public void MousePick()//17
    {
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hitInfo, Mathf.Infinity)){

                CHARMOVE charmove;

                charmove.x = hitInfo.point.x;
                charmove.y = hitInfo.point.y;
                charmove.z = hitInfo.point.z;

                byte[] clientPacket = BitConverter.GetBytes((ushort)ePacketType.CHAMOVE);
                byte[] uid = BitConverter.GetBytes((int)1);
                byte[] x = BitConverter.GetBytes((float)charmove.x);
                byte[] y = BitConverter.GetBytes((float)charmove.y);
                byte[] z = BitConverter.GetBytes((float)charmove.z);

                Array.Copy(clientPacket,0,sendBuffer,0,clientPacket.Length);
                Array.Copy(uid,0,sendBuffer,2,uid.Length);
                Array.Copy(x,0,sendBuffer,6,x.Length);
                Array.Copy(y,0,sendBuffer,10,y.Length);
                Array.Copy(z, 0, sendBuffer, 14, z.Length);

                clientSocket.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, SendCallBack, clientSocket);//18

            }
        }
    }

    public void Moveacharacter(int id, float x, float y, float z)   //26
    {
        Vector3 end = new Vector3(x, y, z);
        if(id == 1)
        {
            mine.transform.position = Vector3.MoveTowards(mine.transform.position, end, Time.deltaTime * 2f);
        }
        else
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, end, Time.deltaTime * 2f);
        }
    }

    public void SendCallBack(IAsyncResult ar)   //19
    {
        Socket clientSocket = (Socket)ar.AsyncState;
        byte[] tmp = new byte[128];
        Array.Copy(sendBuffer, 0, tmp,0, sendBuffer.Length);
        Array.Clear(sendBuffer, 0, sendBuffer.Length);
        
        queue.Enqueue(tmp);
        clientSocket.BeginReceive(tmp, 0, tmp.Length, SocketFlags.None, ReceiveCallBack, clientSocket);


    }

    void Update()
    {
        MousePick();//20

        if(doCreate != null)    //21
        {
            doCreate();
        }

        if (queue.Count > 0)    //22
        {
            byte[] bytes = queue.Dequeue();
            byte[] packetInfo = new byte[128];
            Array.Copy(bytes,0,packetInfo,0,2);

            short packetType = BitConverter.ToInt16(packetInfo, 0);

            switch ((int)packetType)
            {
                case (int)ePacketType.NONE:
                    break;


                case (int)ePacketType.PEERINFO:
                    break;

                case (int)ePacketType.CHAMOVE:  //23
                    doMove = Moveacharacter;
                    


                    break;
            }
        }

    }
}
