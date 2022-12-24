using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Move : MonoBehaviour
{
    //3d 공간상의 변화는 이동 회전 스케일 뿐이다
    //트랜스 폼의 값을 변경해서 이동할 수 있다
    void Start()
    {
        
    }

    void Update()
    {
        //시간에 따라서 위치를 계속 바꿔야 하기 때문에 업데이트에서 호출한다
        //이동을 시키려면 이 오브젝트에 붙어있는 트랜스폼 안의 포지션 값을 변경한다
        //x,y,z, 값을 변경하며 이동
        Vector3 pos = this.transform.position;
        //pos.x += 0.05f;
        pos.x -= 0.05f;
       // pos.y += 0.05f;
        pos.y -= 0.05f;
        //pos.z += 0.05f;
        pos.z -= 0.05f;
        this.transform.position = pos;

    }
}
