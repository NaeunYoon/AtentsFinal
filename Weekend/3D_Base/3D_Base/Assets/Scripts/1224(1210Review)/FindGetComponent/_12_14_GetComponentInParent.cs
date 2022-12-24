using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_14_GetComponentInParent : MonoBehaviour
{
    void Start()
    {
        //계층구조상에서 부모방향의 컴포넌트를 하나 가져올 때
        _12_24_Slime slime = this.gameObject.GetComponentInParent<_12_24_Slime>();
        //이 컴포넌트가 있는 위치에서 위쪽 부모를 한번 찾는다
        slime.Attack();

        //계층구조상에서 부모 방향의 오브젝트의 컴포넌트를 모두 가지고 올 떄
        _12_24_Slime[] slimes = gameObject.GetComponentsInParent<_12_24_Slime>();
        foreach (var item in slimes)
        {
            item.Attack();
        }
    }

    void Update()
    {
        //UpDate 메세지 루프에서 GetComponent 관련 함수를 호출하면 안된다
        //GetComponent는 호출 비용이 큰 함수이다
        //Start나 Awake 함수에서 GetComponent 를 호출해서 컴포넌트의 참조값을 멤버필드에 저장하고
        //멤버필드를 이용해서 Update에서 컴포넌트를 작동시켜야 한다.

        //이렇게 사용하면 안됨->
        //_12_24_Slime slime01 = gameObject.GetComponent<_12_24_Slime>();
        //slime01.Attack();
    }
}
