using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindObject : MonoBehaviour
{
    
    void Start()
    {
        //Scnen���� ��� ������Ʈ �߿��� Ư���� �̸��� ������Ʈ�� ã�� ��
        GameObject obj = GameObject.Find("Cube (5)");

        obj?.SetActive(false);
        //nullable
    }


    void Update()
    {
        
    }
}
