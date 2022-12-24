using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindGetComponent : MonoBehaviour
{
    
    void Start()
    {
        //오브젝트에 붙어있는 컴포넌트를 가져올 떄
        //동일한 오브젝트상의 컴포넌트를 참조할 때 GetComponent
        _12_24_Dragon obj = gameObject.GetComponent<_12_24_Dragon>();
        obj.Attack();
        //이 컴포넌트가 추가되어있는 같은 게임오브젝트의 컴포넌트를 가져온다
        //동일한 오브젝트상의 컴포넌트를 가져올 때


        //오브젝트에 컴포넌트가 여러 개가 있을 때?
        //그걸 전부 다 가져와야 할 때
        //동일한 오브젝트상의 같은 이름의 컴포넌트를 모두 가져올 때
        _12_24_Dragon[] dragons = gameObject.GetComponents<_12_24_Dragon>();
        foreach (var item in dragons)
        {
            item.Attack();
        }

    }

    void Update()
    {
        
    }
}
