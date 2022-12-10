using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public enum ePACKET
{
    INITIALIZE=0
}

public class _12_09_ArrayCopy : MonoBehaviour
{
    byte[] sBuffer;
    public int CURINDEX { get; set; }
    //int CURRENTINDEX { get; set; }
    public int READCOUNT { get; set; }
    private void Awake()
    {
        //sBuffer=new byte[128];
        sBuffer = new byte[128];
        CURINDEX = 0;

    }
    //������Ƽ�� �̿��ؼ� sBuffer�� �����͸� �̾ �����ϴ� ���α׷� �ڵ带 �ۼ�
    public byte[] ADDPACKET
    {
        get { return sBuffer; }
        set
        {
            byte[] _value = value;
            for (int i = 0; i < _value.Length ; i++)
            {
                sBuffer[CURINDEX++] = _value[i];
            }
        }
    }

    public byte[] GETINT
    {
        get 
        { 
            byte[] result = new byte[4];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX+4; i++)
            {
                result[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 4;
            return result;
        
        }
    }

    public byte[] GETLONG
    {
        get
        {
            byte[] result = new byte[8];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 8; i++)
            {
                result[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 8;
            return result;

        }
    }
    public byte[] FLOAT
    {
        get
        {
            byte[] result = new byte[4];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 4; i++)
            {
                result[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 4;
            return result;

        }
    }
    public byte[] GETSHORT
    {
        get
        {
            byte[] result = new byte[2];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 2; i++)
            {
                result[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 2;
            return result;

        }
    }
    public byte[] GETDOUBLE
    {
        get
        {
            byte[] result = new byte[8];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 8; i++)
            {
                result[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 8;
            return result;

        }
    }
    public byte[] GETBYTES
    {
        get
        {
            byte[] byteLength = new byte[2];
            byteLength[0] = sBuffer[0];
            byteLength[1] = sBuffer[1];

            int getLength = BitConverter.ToInt16(byteLength);
            byte[] result = new byte[getLength];
            for (int i = 2; i < sBuffer.Length; i++)
            {
                if (i < getLength + 2)
                {
                    result[i - 2] = sBuffer[i];
                }
                else
                {
                    sBuffer[i - getLength - 2] = sBuffer[i];    // ������ ����
                }
            }
            return result;
        }
    }
    //public byte[] GETBYTES
    //{
    //    get
    //    {
    //        byte[] result = new byte[READCOUNT];
    //        int j = 0;
    //        for (int i = CURRENTINDEX; i < CURRENTINDEX + READCOUNT; i++)
    //        {
    //            result[j++] = sBuffer[i];
    //        }
    //        CURRENTINDEX = CURRENTINDEX + READCOUNT;
    //        return result;

    //    }
    //}

    void Start()
    {
        ////���ۿ� ��Ŷ�� �����ϴ� �ڵ�
        //CURINDEX = (int)ePACKET.INITIALIZE;
        //READCOUNT = (int)ePACKET.INITIALIZE;
        //ADDPACKET = BitConverter.GetBytes((int)1234); //4����Ʈ�� s ���ۿ� ����
        //ADDPACKET = BitConverter.GetBytes((short)120); //2����Ʈ�� �̾ s ���ۿ� ����

        //byte[] strByteArr = Encoding.Default.GetBytes("�ȳ��ϼ���");
        ////1. ���ڿ��� ����Ʈ ���� ����
        ////2. ���ڿ��� ������ ����Ʈ�� ��ȯ�ؼ� ����
        //ADDPACKET = BitConverter.GetBytes((short)strByteArr.Length);
        //ADDPACKET = strByteArr;

        ////s���ۿ� �ִ� ������ �ڷ����� �µ��� �Ľ�
        //CURINDEX = (int)ePACKET.INITIALIZE;
        //READCOUNT = (int)ePACKET.INITIALIZE;
        //int number = BitConverter.ToInt32(GETINT);
        //short age = BitConverter.ToInt16(GETSHORT);
        //READCOUNT = BitConverter.ToInt32(GETINT);
        //string str = Encoding.Default.GetString(GETBYTES);
        //Debug.Log("number = " + number);
        //Debug.Log("age = " + age);
        //Debug.Log("readCount = " + READCOUNT);
        //Debug.Log("string = " + str);

        READCOUNT = 0;

        ADDPACKET = BitConverter.GetBytes((int)1325);
        ADDPACKET = BitConverter.GetBytes((short)125);

        // ���ڿ� ����
        string str = "�ȳ��ϼ���";
        byte[] strByte = Encoding.Default.GetBytes(str);
        ADDPACKET = BitConverter.GetBytes((short)strByte.Length); // ���ڿ��� ���ڿ��� ���̸� ���� ����������Ѵ�.
        ADDPACKET = strByte;    // ���ڿ� ����

        // sbuffer�� �ִ� ������ �ڷ����� �°� ����
        Debug.Log(BitConverter.ToInt32(GETINT));
        Debug.Log(BitConverter.ToInt16(GETSHORT));
        Debug.Log(Encoding.UTF8.GetString(GETBYTES));

    }
    
    void Update()
    {
        
    }
}
