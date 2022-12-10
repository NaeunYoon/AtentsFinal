using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindTag : MonoBehaviour
{
   
    void Start()
    {
        //Scnen 상에 tag를 가지고 있는 게임옵브젝트를 찾기
        //처음 찾은 오브젝트를 리턴
        GameObject obj = GameObject.FindWithTag("Target");
        obj?.SetActive(false);
    }

    
    void Update()
    {
        
    }
}
