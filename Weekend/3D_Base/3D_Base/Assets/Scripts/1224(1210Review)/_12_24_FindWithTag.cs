using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindWithTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Ÿ���̶�� �±װ� �޷��ִ� ������Ʈ
        //�� ó���� ã�� ���� �����Ѵ�.
        //�ΰ��� �����ص�, ù��°�� ã�� �͸� �������ش�.
        GameObject obj = GameObject.FindWithTag("Target");
        obj.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
