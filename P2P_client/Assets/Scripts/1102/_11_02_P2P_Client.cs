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

public class DelegateWrap  //��Ŷ�� ����(���� ���� �����δٴ� ����)
                            //�̵��� �Ϸ��� �ϴٺ��� ������Ʈ���� move�� ��� ȣ��Ǿ�� �ϴµ�
                            //delegate�Լ��� �Ű������� �˾ƾ� ������ �� �� �ƴ�
                            //������ �� ����ü�� ����. �� id�� �� �Լ��� ��� ȣ���Ұž�

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
  /*  List<DelegateWrap> doList;*/  //�̰� ����Ʈ�� ����

    Dictionary<int, DelegateWrap> dolist;
    private void Awake()
    {   
        strIP = "127.0.0.1";
        port = 8082;
        sendBuffer = new byte[128];
        receiveBuffer = new byte[128];
        endPos = -Vector3.one;
        packetQueue = new Queue<byte[]>();  //��Ŷ ť �ʱ�ȭ
        //doList = new List<DelegateWrap>();  //�ʱ�ȭ����
        dolist = new Dictionary<int, DelegateWrap>();
    }
    void Start()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(strIP),port);
        clientSocket.Connect(endPoint); //�����Լ��� �ޱ�
        Debug.Log("connect");
        ResourcesRoad();

    }
    public void ResourcesRoad()
    {
        GameObject obj = Resources.Load<GameObject>("Cube");
        Instantiate(obj);
        Debug.Log("ť�� ����");
    }
    
    public void MousePick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if( Physics.Raycast(ray, out hitInfo,Mathf.Infinity))
            {
                endPos = hitInfo.point; //������ ������
                //���콺 �� ���ڸ��� ť�� �ִ°� �ƴ�
                //�����ϰ� �ݹ� �� ������ ����..������ ��

                //MoveSend();

                //����ü�� ���콺 �� �����
                CHAMOVE chaMove;    

                chaMove.xPos = hitInfo.point.x;
                chaMove.yPos = hitInfo.point.y;
                chaMove.zPos = hitInfo.point.z;

                //������ ��ġ�� ���� �� ���� �ٸ� �Ǿ�� �̵��Ѵٰ� ������
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

                //��Ŷ�� ������~!

                clientSocket.BeginSend(sendBuffer,0,sendBuffer.Length,SocketFlags.None,SendCallBack, null);
            }   
        }
    }

    public void SendCallBack(IAsyncResult ar)   //������ �� �� callback �Լ� ȣ��
    {
        //���� ���� ������ queue�� ����
        byte[] tmpBuffer = new byte[128];

        Array.Copy(sendBuffer, 0, tmpBuffer, 0, sendBuffer.Length); //tmpBuffer�� ����
        Array.Clear(sendBuffer,0,sendBuffer.Length);    //������� ������
        packetQueue.Enqueue(tmpBuffer); //tmp���� ������ enqueue
        clientSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null); 
        //���� ��丮�ú� ȣ���ϸ� ���ú갡 �ٽ� �ȵ� �ѹ� �ݹ��� �Ͼ�� �ٽ� ����� ȣ���������
    }
    public void ReceiveCallBack(IAsyncResult ar)
    {
        byte[] tmpBuffer = new byte[128];

        Array.Copy(receiveBuffer, 0, tmpBuffer, 0, receiveBuffer.Length); //tmpBuffer�� ����
        Array.Clear(receiveBuffer, 0, receiveBuffer.Length);    //������� ������
        packetQueue.Enqueue(tmpBuffer);
        clientSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
    }
    public void MoveCharacter(int _uid,float x, float y, float z) //���� ������
    {
        Vector3 endPos = new Vector3(x, y, z);
        //�ӽ��ڵ�
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
            doCreate(); //��������Ʈ �Լ� ȣ��
        }

        if (packetQueue.Count > 0) //dequeue
        {
            byte[] data = packetQueue.Dequeue();
            //���� 2����Ʈ�� ��ŶŸ��(2), ����(126), �� ������ �����͸� �Ľ�
            //��ŶŸ�� 2����Ʈ �������� �ڵ�
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
