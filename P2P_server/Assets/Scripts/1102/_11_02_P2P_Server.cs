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
public class DelegateWrap  //��Ŷ�� ����(���� ���� �����δٴ� ����)
                           //�̵��� �Ϸ��� �ϴٺ��� ������Ʈ���� move�� ��� ȣ��Ǿ�� �ϴµ�
                           //delegate�Լ��� �Ű������� �˾ƾ� ������ �� �� �ƴ�
                           //������ �� ����ü�� ����. �� id�� �� �Լ��� ��� ȣ���Ұž�

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
    private void Awake()    //�ʱ�ȭ ���ִ� ��
    {
        //��ǻ�Ϳ��� �����Ǹ� �ٷ� �޾ƿ͵� ��

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
        serverSocket.BeginAccept(AddPeer,null); //start���� �����ؾ� ����Ƽ�� ����Ǵ� ȭ���� Ȯ���� �� �ִ�
    }
    public void ResourcesCube()
    {
        //Debug.Log("���ҽ� ������");
        ////�ٸ� �Ǿ ����Ǿ��� ���, ���� Ŭ���̾�Ʈ Cube�� ���ҽ� �������� �ε��Ͽ� �ν��Ͻ� ����
        //GameObject obj = Resources.Load<GameObject>("Character/Cube");
        //Instantiate(obj);
        //Debug.Log("ť�� ����");        

        GameObject tmp = Resources.Load<GameObject>("Cube");
        if (tmp != null)
        {
            other = GameObject.Instantiate<GameObject>(tmp);
        }     /*=> ���� ������ �ִ� �����尡 �ƴ϶� �������� �ʴ´�*/

        GameObject myChar = Instantiate<GameObject>(tmp);
        doCreate -= ResourcesCube;

        serverSocket.BeginReceive(receiveBuffer,0,receiveBuffer.Length,SocketFlags.None, ReceiveCallBack,null);    //���� ����� ����� �� �� ����
    }

    public void AddPeer(IAsyncResult ar)
    {
        Socket otherPeer = serverSocket.EndAccept(ar);
        //ThreadStart thread = new ThreadStart(resources);
        //t = new Thread(thread);
        //t.Start();
        Debug.Log(otherPeer.RemoteEndPoint +"���� �����߽��ϴ�");
        doCreate = ResourcesCube;
        otherPeer.BeginReceive(receiveBuffer,0,receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, otherPeer);
    }
    public void ReceiveCallBack(IAsyncResult ar)
    {
        Socket otherPeer = (Socket)ar.AsyncState;
        //queue�� enqueue �������ϱ� ť�� �����Ѵ�
        byte[] tmp = new byte[128];
        Array.Copy(receiveBuffer,tmp,receiveBuffer.Length);
        Array.Clear(receiveBuffer,0,receiveBuffer.Length);
        packetQueue.Enqueue(tmp);   //��Ŷ ť�� �ִ� ������ �־��ش�
        serverSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
    }
    public void SendCallBack(IAsyncResult ar)   //������ �� �� callback �Լ� ȣ��
    {
        //���� ���� ������ queue�� ����
        byte[] tmpBuffer = new byte[128];

        Array.Copy(sendBuffer, 0, tmpBuffer, 0, sendBuffer.Length); //tmpBuffer�� ����
        Array.Clear(sendBuffer, 0, sendBuffer.Length);    //������� ������
        packetQueue.Enqueue(tmpBuffer); //tmp���� ������ enqueue
        serverSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
        //���� ��丮�ú� ȣ���ϸ� ���ú갡 �ٽ� �ȵ� �ѹ� �ݹ��� �Ͼ�� �ٽ� ����� ȣ���������
    }
    public void MousePick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
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
                byte[] id = BitConverter.GetBytes((int)1);
                byte[] xPos = BitConverter.GetBytes(chaMove.xPos);
                byte[] yPos = BitConverter.GetBytes(chaMove.yPos);
                byte[] zPos = BitConverter.GetBytes(chaMove.zPos);

                Array.Copy(sendBuffer, 0, sendBuffer, 0, packetType.Length);
                Array.Copy(id, 0, sendBuffer, 2, id.Length);
                Array.Copy(xPos, 0, sendBuffer, 6, xPos.Length);
                Array.Copy(yPos, 0, sendBuffer, 10, yPos.Length);
                Array.Copy(zPos, 0, sendBuffer, 14, zPos.Length);

                //��Ŷ�� ������~!

                otherPeer.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, SendCallBack, null);
            }
        }
    }
    public void MoveCharacter(int _uid, float x, float y, float z) //���� ������
    {

    }



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

        //������ ��� ���忡���� ������ �ϰ� ������ �޾����� ��ť �ϰ�
        //�޴� ����� �޾��� �� ��ť�ϰ�
        //������Ʈ �������� ��ť�� ������ ����ȭ�� �Ѵ�

        //ť�� �ִ� ������ �ϳ��� �����´�
    }
}
