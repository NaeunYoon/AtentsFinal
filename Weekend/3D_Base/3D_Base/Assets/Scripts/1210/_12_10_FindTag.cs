using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindTag : MonoBehaviour
{
   
    void Start()
    {
        //Scnen �� tag�� ������ �ִ� ���ӿɺ���Ʈ�� ã��
        //ó�� ã�� ������Ʈ�� ����
        GameObject obj = GameObject.FindWithTag("Target");
        obj?.SetActive(false);
    }

    
    void Update()
    {
        
    }
}
