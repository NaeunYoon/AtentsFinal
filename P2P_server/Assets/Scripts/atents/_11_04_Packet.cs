using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Packet
{

    public enum ePacketType
    {
       NONE,
       PEERINFO=1000,
       CHAMOVE,
    }

     public struct PEERINFO
    {
        ePacketType ePacketType;
        int uid;


    }

    public struct CHARMOVE
    {
        public ePacketType ePacket;
        public int uid;
        public float x;
        public float y;
        public float z;
    }
}
 

 

