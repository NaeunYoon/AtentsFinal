using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindGetComponent : MonoBehaviour
{
    _12_10_Slime slime1;
    void Start()
    {

        slime1 = GetComponent<_12_10_Slime>();
        //동일한 오브젝트상의 컴포넌트를 참조할때GetComponent
        //var obj = gameObject.GetComponent<_12_10_Dragon>();
        //obj.Attack();


        //동일한 오브젝트상의 컴포넌트들을 참조할 때
        //_12_10_Dragon[] dragons = gameObject.GetComponents<_12_10_Dragon>();
        //foreach(var dragon in dragons)
        //{
        //    dragon.Attack();
        //}

        //------------------------------------------------
        //계층구조상에 자식오브젝트의 컴포넌트를 하나 가져올 때

        //_12_10_Slime slime = this.GetComponentInChildren<_12_10_Slime>();
        //slime.Attack();
        ////계층구조상에 자식오브젝트의 컴포넌트들을 가져올 때
        //_12_10_Dragon[] dragons = this.GetComponentsInChildren<_12_10_Dragon>();
        //foreach (var item in dragons)
        //{
        //    item.Attack();
        //}

        //계층구조상에서 부모 컴포넌트를 가져올 때
        _12_10_Slime slime = this.GetComponentInParent<_12_10_Slime>();
        slime.Attack();

        _12_10_Slime [] slimes = this.GetComponentsInParent<_12_10_Slime>();
        foreach (var item in slimes)
        {
            item.Attack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update 메세지 루프에서 Getcomponent 관련 함수를 호출하면 안된다
        //GetComponent는 호출비용이 큰 함수입니다
        //Start나 Awake 함수에서 Getcomponent 함수를 호출해서
        //컴포넌트의 참조값을 멤버필드에 저장을 하고
        //멤버필드를 이용해서 업데이트에서 컴포넌트를 작동시키세요

        //이렇게 하지 말라는 말

        //_12_10_Slime s = GetComponent<_12_10_Slime>();
        //s.Attack();

        slime1?.Attack();
    }
}
