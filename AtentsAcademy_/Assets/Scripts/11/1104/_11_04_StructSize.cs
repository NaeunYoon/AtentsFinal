using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;   //유징 추가

public class _11_04_StructSize : MonoBehaviour
{
    struct A
    {
        public byte a;
        public long b;
        public char c;
        
    }

    [StructLayout(LayoutKind.Sequential,Pack = 1)]

    public struct Info
    {
        private byte a; //1
        private char c; //2
        private long b; //8         왜 10나옴?
    }


    [StructLayout(LayoutKind.Explicit)] //arrtibute 구조체의 속성을 정의해줌

    public struct CharacterInfo //구조체 안에 property / attribute 가 있다면 new 할당해줘야함
    {
        [FieldOffset(0)]
        public uint Word;
        [FieldOffset(0)]
        public byte Byte0;
        [FieldOffset(1)]
        public byte Byte1;
        [FieldOffset(2)]
        public byte Byte2;
        [FieldOffset(3)]
        public byte Byte3;
    }


    A a;
    Info info;

    void Start()
    {
        Debug.Log("int형 크기" + sizeof(int));
        Debug.Log("long형 크기" + sizeof(long));
        Debug.Log("char형 크기" + sizeof(char));

        Debug.Log(Marshal.SizeOf(info));    //마샬에서는 char가 1이래요 구래서 10

        CharacterInfo charInfo = new CharacterInfo();
        charInfo.Byte0 = 10;
        charInfo.Byte1 = 11;
        charInfo.Byte2 = 12;
        charInfo.Byte3 = 13;

        Debug.Log((uint)charInfo.Word);

        Debug.LogFormat("{0}",(uint)charInfo.Word);

        var copyCharInfo = new CharacterInfo();
        copyCharInfo.Word = charInfo.Word;
        Debug.LogFormat("{0}", copyCharInfo);
        Debug.LogFormat("{0}", copyCharInfo.Byte0);
        Debug.LogFormat("{0}", copyCharInfo.Byte1);
        Debug.LogFormat("{0}", copyCharInfo.Byte2);
        Debug.LogFormat("{0}", copyCharInfo.Byte3);


    }

    
    void Update()
    {
        
    }
}
