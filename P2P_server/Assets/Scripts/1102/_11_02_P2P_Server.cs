using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   //
using System.Net.Sockets;   //
using System.Threading; //
using System.Net;
using UnityEditor.ShortcutManagement;
using Unity.VisualScripting;
using Game._11_03_Packet;

public delegate void MakeObj();
public delegate void Move(int _uid, float x, float y, float z);
public class DelegateWrap  //패킷을 받음(누가 어디로 움직인다는 정보)
                           //이동을 하려고 하다보니 업데이트에서 move가 계속 호출되어야 하는데
                           //delegate함수의 매개변수를 알아야 누군지 알 것 아님
                           //구래서 이 구조체를 만듬. 이 id가 이 함수를 계속 호출할거야

{
    public CHAMOVE charmove;
    public Move doMove;
}
public enum ePACKETTYPE
{
    NONE,
    PEERINFO =1000,
    CHARACTERSEELECT,
    CHARMOVE
}

public struct PEERINFO
{
    public ePACKETTYPE packetType;
    public int uid;
    public string name;
    public short charType;
}
public struct CHAMOVE
{
    public ePACKETTYPE packetType;
    public int uid;
    public float xPos;
    public float yPos;
    public float zPos;

}

public class _11_02_P2P_Server : MonoBehaviour
{
    Socket serverSocket;
    string strIP;
    int port;
    
    byte[] sendBuffer;
    byte[] receiveBuffer;
    GameObject other;
    Vector3 endPos;
    MakeObj doCreate;
    Move doMove;
    //Thread t;
    Dictionary<int, DelegateWrap> dolist;
    Queue<byte[]> packetQueue;
    Socket otherPeer;

    ePACKETTYPE ePACKETTYPE;
    private void Awake()    //초기화 해주는 곳
    {
        //컴퓨터에서 아이피를 바로 받아와도 댐

        strIP = "127.0.0.1";
        port = 8082;    
        sendBuffer = new byte[128];
        receiveBuffer = new byte[128];
        endPos = -Vector3.one;
        doCreate = null;
        packetQueue = new Queue<byte[]>();

        //ThreadStart thread = new ThreadStart(resources);
        //t = new Thread(thread);
        ePACKETTYPE = ePACKETTYPE.NONE;
        dolist = new Dictionary<int, DelegateWrap>();
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

    public void AddPeer(IAsyncResult ar)
    {
        Socket otherPeer = serverSocket.EndAccept(ar);
        //ThreadStart thread = new ThreadStart(resources);
        //t = new Thread(thread);
        //t.Start();
        Debug.Log(otherPeer.RemoteEndPoint +"님이 접속했습니다");
        doCreate = ResourcesCube;
        otherPeer.BeginReceive(receiveBuffer,0,receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, otherPeer);
    }
    public void ReceiveCallBack(IAsyncResult ar)
    {
        Socket otherPeer = (Socket)ar.AsyncState;
        //queue에 enqueue 보냈으니까 큐에 저장한다
        byte[] tmp = new byte[128];
        Array.Copy(receiveBuffer,tmp,receiveBuffer.Length);
        Array.Clear(receiveBuffer,0,receiveBuffer.Length);
        packetQueue.Enqueue(tmp);   //패킷 큐에 있는 내용을 넣어준다
        serverSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
    }
    public void SendCallBack(IAsyncResult ar)   //응답이 올 대 callback 함수 호출
    {
        //내가 보낸 내용을 queue에 담자
        byte[] tmpBuffer = new byte[128];

        Array.Copy(sendBuffer, 0, tmpBuffer, 0, sendBuffer.Length); //tmpBuffer에 복사
        Array.Clear(sendBuffer, 0, sendBuffer.Length);    //샌드버퍼 지워줌
        packetQueue.Enqueue(tmpBuffer); //tmp버퍼 내용을 enqueue
        serverSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
        //내가 비긴리시브 호출하면 리시브가 다시 안됨 한번 콜백이 일어나면 다시 비긴을 호출해줘야함
    }
    public void MousePick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                endPos = hitInfo.point; //목적지 저장함
                //마우스 픽 하자마자 큐에 넣는게 아님
                //샌드하고 콜백 한 다음에 넣음..왜인진 모름

                //MoveSend();

                //구조체에 마우스 픽 담아줌
                CHAMOVE chaMove;

                chaMove.xPos = hitInfo.point.x;
                chaMove.yPos = hitInfo.point.y;
                chaMove.zPos = hitInfo.point.z;

                //목적지 위치를 정할 때 마다 다른 피어에게 이동한다고 전송함
                byte[] packetType = BitConverter.GetBytes((short)ePACKETTYPE.CHARMOVE);
                byte[] id = BitConverter.GetBytes((int)1);
                byte[] xPos = BitConverter.GetBytes(chaMove.xPos);
                byte[] yPos = BitConverter.GetBytes(chaMove.yPos);
                byte[] zPos = BitConverter.GetBytes(chaMove.zPos);

                Array.Copy(sendBuffer, 0, sendBuffer, 0, packetType.Length);
                Array.Copy(id, 0, sendBuffer, 2, id.Length);
                Array.Copy(xPos, 0, sendBuffer, 6, xPos.Length);
                Array.Copy(yPos, 0, sendBuffer, 10, yPos.Length);
                Array.Copy(zPos, 0, sendBuffer, 14, zPos.Length);

                //패킷을 보내자~!

                otherPeer.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, SendCallBack, null);
            }
        }
    }
    public void MoveCharacter(int _uid, float x, float y, float z) //내꺼 움직임
    {

    }



    void Update()
    {
        MousePick();

        if (doCreate != null)
        {
            doCreate(); //델리게이트 함수 호출
        }

        if (packetQueue.Count > 0) //dequeue
        {
            byte[] data = packetQueue.Dequeue();
            //앞의 2바이트는 패킷타입(2), 내용(126), 이 순서로 데이터를 파싱
            //패킷타입 2바이트 가져오는 코드
            byte[] _Packet = new byte[2];
            Array.Copy(data, 0, _Packet, 0, 2);

            short packetType = BitConverter.ToInt16(_Packet, 0);
            switch ((int)packetType)
            {
                case (int)ePACKETTYPE.NONE:

                    break;

                case (int)ePACKETTYPE.PEERINFO:

                    break;

                case (int)ePACKETTYPE.CHARACTERSEELECT:
                    //doMove = MoveCharacter;
                    {
                        byte[] _id = new byte[4];
                        Array.Copy(data, 2, _id, 0, _id.Length);
                        int id = BitConverter.ToInt32(_id);

                        if (dolist.ContainsKey(id))
                        {

                            DelegateWrap actionValue;
                            if (dolist.TryGetValue(id, out actionValue))
                            {
                                dolist[id].charmove.xPos = 10;
                                dolist[id].charmove.yPos = 10;
                                dolist[id].charmove.zPos = 10;
                                //dolist[id].doMove = MoveCharacter;

                            }


                        }
                        else
                        {
                            DelegateWrap newData = new DelegateWrap();
                            newData.charmove.uid = id;
                            newData.charmove.xPos = 10;
                            newData.charmove.yPos = 10;
                            newData.charmove.zPos = 10;
                            newData.doMove = MoveCharacter;
                            dolist.Add(id, newData);
                        }

                        //DelegateWrap doWrap = new DelegateWrap();
                        //doWrap.charmove.uid = 10;
                        //doWrap.charmove.xPos = 10;
                        //doWrap.charmove.yPos = 10;
                        //doWrap.charmove.zPos = 10;
                        //doWrap.doMove = MoveCharacter;
                    }



                    break;
            }
        }

        for (int i = 0; i < dolist.Count; i++)
        {
            dolist[i].doMove(dolist[i].charmove.uid,
                            dolist[i].charmove.xPos,
                            dolist[i].charmove.yPos,
                            dolist[i].charmove.zPos);
        }

        //보내는 사람 입장에서는 전송을 하고 응답을 받았을때 엔큐 하고
        //받는 사람은 받았을 때 엔큐하고
        //업데이트 문에서는 엔큐를 꺼내서 동기화를 한다

        //큐에 있는 내용을 하나씩 가져온다
    }
}
