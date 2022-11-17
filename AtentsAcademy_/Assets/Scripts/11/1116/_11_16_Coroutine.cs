using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class _11_16_Coroutine : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("Seconds");
        StartCoroutine("Variable");
        StartCoroutine(Tests());

    }


    void Update()
    {
        
    }

    IEnumerator Seconds()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("������ �ϴ� �ڵ�");

           yield return new WaitForSeconds(1f);
        }
            Debug.Log("������ �� ��");
    }

    IEnumerator Variable()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
        }
        Debug.Log("������ ���� 100 �̻��Դϴ�");
        yield return null;
    }


    void Test1()
    {
        Debug.Log("Test1");
    }

    void Test2()
    {
        Debug.Log("Test2");
    }

    IEnumerator Tests()
    {
        Test1();
        yield return StartCoroutine("Test2");
    }


}
