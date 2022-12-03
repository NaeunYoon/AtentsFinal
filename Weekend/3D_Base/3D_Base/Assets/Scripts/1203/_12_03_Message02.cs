using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_03_Message02 : MonoBehaviour
{

    void Start()
    {
        
    }
    public void Eat()
    {
        Debug.Log("Eat " + this.name + "(부모)");
    }

    void Update()
    {
        //SendMessage("Eat");       //같은 오브젝트 다른 컴포넌트에 보낼 때
        /*BroadcastMessage("Move");*/   //자식 오브젝트에 일괄적으로 메세지 전송
        /*BroadcastMessage("Eat",SendMessageOptions.RequireReceiver);*/ // 에러 시
        SendMessageUpwards("Eat");   //부모한테 보냄
    }
}
