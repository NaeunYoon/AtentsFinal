using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game._11_03_Packet
{
    public enum ePACKETTYPE
    {
        NONE,
        PEERINFO = 1000,
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

}
