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
    private void Awake()    //�ʱ�ȭ ���ִ� ��
    {
        //��ǻ�Ϳ��� �����Ǹ� �ٷ� �޾ƿ͵� ��

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

    public void ReceiveCallBack(IAsyncResult ar)
    {
        //queue�� enqueue �������ϱ� ť�� �����Ѵ�
        byte[] tmp = new byte[128];
        Array.Copy(receiveBuffer,tmp,receiveBuffer.Length);
        Array.Clear(receiveBuffer,0,receiveBuffer.Length);
        packetQueue.Enqueue(tmp);   //��Ŷ ť�� �ִ� ������ �־��ش�
        serverSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallBack, null);
    }

    public void AddPeer(IAsyncResult ar)
    {
        Socket otherPeer = serverSocket.EndAccept(ar);
        //ThreadStart thread = new ThreadStart(resources);
        //t = new Thread(thread);
        //t.Start();
        Debug.Log(otherPeer.RemoteEndPoint +"���� �����߽��ϴ�");
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
            //���� 2����Ʈ�� ��ŶŸ��(2), ����(126), �� ������ �����͸� �Ľ�
            //��ŶŸ�� 2����Ʈ �������� �ڵ�
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

        //������ ��� ���忡���� ������ �ϰ� ������ �޾����� ��ť �ϰ�
        //�޴� ����� �޾��� �� ��ť�ϰ�
        //������Ʈ �������� ��ť�� ������ ����ȭ�� �Ѵ�

        //ť�� �ִ� ������ �ϳ��� �����´�
    }
}
