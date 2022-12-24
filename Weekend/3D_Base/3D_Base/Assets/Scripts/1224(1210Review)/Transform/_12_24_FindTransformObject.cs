using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindTransformObject : MonoBehaviour
{
    void Start()
    {
        //게임 오브젝트는 무조건 트랜스폼을 가지고 있다
        //얘는 계층구조에 있는 것을 찾아준다
        //계층구조상에서 자식 오브젝트의 이름으로 찾을 때,
        Transform tr = transform.Find("Cube (3)");
        tr.gameObject.SetActive(false);
        //빈 게임오브젝트가 아니라 부모에다가 넣어준다.
        //자식으로 있는 경우만 된다 (자식의 자식은 안됨)
    }

    void Update()
    {
        
    }
}
