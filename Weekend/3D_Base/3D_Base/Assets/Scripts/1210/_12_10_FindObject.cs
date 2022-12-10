using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindObject : MonoBehaviour
{
    
    void Start()
    {
        //Scnen상의 모든 오브젝트 중에서 특정한 이름의 오브젝트를 찾을 때
        GameObject obj = GameObject.Find("Cube (5)");

        obj?.SetActive(false);
        //nullable
    }


    void Update()
    {
        
    }
}
