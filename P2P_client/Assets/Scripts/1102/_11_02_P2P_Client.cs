using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using Game._11_03_Packet;
using System;
using Unity.VisualScripting;
using UnityEngine.Experimental.GlobalIllumination;

public delegate void MakeObj();
public delegate void Move(int _uid,float x,float y,float z);

public class DelegateWrap  //패킷을 받음(누가 어디로 움직인다는 정보)
                            //이동을 하려고 하다보니 업데이트에서 move가 계속 호출되어야 하는데
                            //delegate함수의 매개변수를 알아야 누군지 알 것 아님
                            //구래서 이 구조체를 만듬. 이 id가 이 함수를 계속 호출할거야

{
    public CHAMOVE charmove;
    public Move doMove;
}
public class _11_02_P2P_Client : MonoBehaviour
{
    Socket clientSocket;
    string strIP;
    int port;
    byte[] sendBuffer;
    byte[] receiveBuffer;
    Vector3 endPos;
    Queue<byte[]> packetQueue;
    MakeObj doCreate;
    Move doMove;
  /*  List<DelegateWrap> doList;*/  //이걸 리스트로 만듬

    Dictionary<int, DelegateWrap> dolist;
    private void Awake()
    {   
        strIP = "127.0.0.1";
        port = 8082;
        sendBuffer = new byte[128];
        receiveBuffer = new byte[128];
        endPos = -Vector3.one;
        packetQueue = new Queue<byte[]>();  //패킷 큐 초기화
        //doList = new List<DelegateWrap>();  //초기화해줌
        dolist = new Dictionary<int, DelegateWrap>();
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
        GameObject obj = Resources.Load<GameObject>("Cube");
        Instantiate(obj);
        Debug.Log("큐브 생성");
    }
    
    public void MousePick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if( Physics.Raycast(ray, out hitInfo,Mathf.Infinity))
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
                byte[] id = BitConverter.GetBytes((int)10);
                byte[] xPos = BitConverter.GetBytes(chaMove.xPos);
                byte[] yPos = BitConverter.GetBytes(chaMove.yPos);
                byte[] zPos = BitConverter.GetBytes(chaMove.zPos);

                Array.Copy(sendBuffer, 0, sendBuffer, 0, packetType.Length);
                Array.Copy(id, 0, sendBuffer, 2, id.Length);
                Array.Copy(xPos, 0, sendBuffer, 6, xPos.Length);
                Array.Copy(yPos, 0, sendBuffer, 10, yPos.Length);
                Array.Copy(zPos, 0, sendBuffer, 14, zPos.Length);

                //패킷을 보내자~!

                clientSocket.BeginSend(sendBuffer,0,sendBuffer.Length,SocketFlags.None,SendCallBack, null);
            }   
        }
    }

    public void SendCallBack(IAsyncResult ar)   //응답이 올 대 callback 함수 호출
    {
        //내가 보낸 내용을 queue에 담자
        byte[] tmpBuffer = new byte[128];

        Array.Copy(sendBuffer, 0, tmpBuffer, 0, sendBuffer.Length); //tmpBuffer에 복사
        Array.Clear(sendBuffer,0,sendBuffer.Length);    //샌드버퍼 지워줌
        packetQueue.Enqueue(tmpBuffer); //tmp버퍼 내용을 enqueue
        clientSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null); 
        //내가 비긴리시브 호출하면 리시브가 다시 안됨 한번 콜백이 일어나면 다시 비긴을 호출해줘야함
    }
    public void ReceiveCallBack(IAsyncResult ar)
    {
        byte[] tmpBuffer = new byte[128];

        Array.Copy(receiveBuffer, 0, tmpBuffer, 0, receiveBuffer.Length); //tmpBuffer에 복사
        Array.Clear(receiveBuffer, 0, receiveBuffer.Length);    //샌드버퍼 지워줌
        packetQueue.Enqueue(tmpBuffer);
        clientSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
    }
    public void MoveCharacter(int _uid,float x, float y, float z) //내꺼 움직임
    {
        Vector3 endPos = new Vector3(x, y, z);
        //임시코드
        if (_uid == 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * 2f);

        }
        else
        {

        }


    }

    //public void OtherCharacter(int _uid)
    //{

    //}

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
                        byte[]_id = new byte[4];
                        Array.Copy(data, 2, _id, 0, _id.Length);
                        int id = BitConverter.ToInt32(_id);

                        if (dolist.ContainsKey(id))
                        {

                            DelegateWrap actionValue;
                            if(dolist.TryGetValue(id, out actionValue))
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

        foreach(KeyValuePair<int,DelegateWrap> one in dolist)
        {
            one.Value. doMove(one.Value.charmove.uid,
                              one.Value.charmove.xPos,
                              one.Value.charmove.yPos,
                              one.Value.charmove.zPos);
        }


        //for(int i = 0; i < dolist.Count; i++)
        //{
        //    dolist[i].doMove(dolist[i].charmove.uid,
        //                    dolist[i].charmove.xPos,
        //                    dolist[i].charmove.yPos,
        //                    dolist[i].charmove.zPos);
        //}



            
    }
}
