using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_16_CoPractice : MonoBehaviour
{

    public int cnt;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("1����");
        yield return new WaitForSeconds(1f);
        Debug.Log("2����");
        yield return new WaitForSeconds(1f);
        Debug.Log("3����");
        yield return new WaitForSeconds(1f);
        Debug.Log("4����");
        yield return new WaitForSeconds(1f);
        Debug.Log("5����");

        StartCoroutine(WaitProcess());
        yield return StartCoroutine(Test1());
        yield return StartCoroutine(Test2());
    }
    
    void Update()
    {
        cnt++;
    }

    IEnumerator WaitProcess()
    {
        yield return new WaitUntil(() => cnt >= 100);
        Debug.Log("������ ���� 100 �̻��Դϴ�");
    }

    IEnumerator Test1()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("Test1 " + i.ToString());
        }
        yield return null;
    }

    IEnumerator Test2()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return null;
            Debug.Log("Test2 " + i.ToString());
        }
    }

}
