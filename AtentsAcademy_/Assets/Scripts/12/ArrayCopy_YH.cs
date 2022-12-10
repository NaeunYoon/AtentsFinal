using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

/**
 * sBuffer에 데이터를 이어서 대입하는 코드 작성.
 */
public class ArrayCopy_YH : MonoBehaviour
{
    byte[] sBuffer;
    int CURRENTINDEX { get; set; }
    int READCOUNT { get; set; }
    private void Awake()
    {
        sBuffer = new byte[128];
        CURRENTINDEX= 0;
    }

    // 프로퍼티를 이용하여 sBuffer에 데이터를 이어서 대입하는 프로그램 코드를 작성
    public byte[] ADDPACKET { get { return sBuffer; } 
        set {
            for (int i = 0; i < value.Length; i++)
            {
                sBuffer[CURRENTINDEX++] = value[i];
            }
        }}
    public byte[] GETINT { get {
            int getLength = 4;
            byte[] result = new byte[getLength];
            for (int i = 0; i < sBuffer.Length; i++)
            {
                if (i < getLength)
                {
                    result[i] = sBuffer[i];
                }
                else
                {
                    sBuffer[i - getLength] = sBuffer[i];    // 앞으로 당기기
                }
            }
            return result;
        } }
    public byte[] GETSHORT { get {
            int getLength = 2;
            byte[] result = new byte[getLength];
            for (int i = 0; i < sBuffer.Length; i++)
            {
                if (i < getLength)
                {
                    result[i] = sBuffer[i];
                }
                else
                {
                    sBuffer[i - getLength] = sBuffer[i];    // 앞으로 당기기
                }
            }
            return result;
        } }
    public byte[] GETBYTES { get {
            byte[] byteLength = new byte[2];
            byteLength[0] = sBuffer[0];
            byteLength[1] = sBuffer[1];

            int getLength = BitConverter.ToInt16(byteLength);
            byte[] result = new byte[getLength];
            for (int i = 2; i < sBuffer.Length; i++)
            {
                if (i < getLength + 2)
                {
                    result[i-2] = sBuffer[i];
                }
                else
                {
                    sBuffer[i - getLength - 2] = sBuffer[i];    // 앞으로 당기기
                }
            }
            return result;
        } }
    private void Start()
    {
        READCOUNT = 0;

        ADDPACKET = BitConverter.GetBytes((int)1325);
        ADDPACKET = BitConverter.GetBytes((short)125);
        
        // 문자열 저장
        string str = "안녕하세요";
        byte[] strByte = Encoding.Default.GetBytes(str);
        ADDPACKET = BitConverter.GetBytes((short)strByte.Length); // 문자열은 문자열의 길이를 먼저 저장해줘야한다.
        ADDPACKET = strByte;    // 문자열 저장

        // sbuffer에 있는 내용을 자료형에 맞게 저장
        Debug.Log(BitConverter.ToInt32(GETINT));
        Debug.Log(BitConverter.ToInt16(GETSHORT));
        Debug.Log(Encoding.UTF8.GetString(GETBYTES));
    }
}
