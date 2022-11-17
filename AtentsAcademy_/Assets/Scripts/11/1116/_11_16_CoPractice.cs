using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_16_CoPractice : MonoBehaviour
{

    public int cnt;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("1초후");
        yield return new WaitForSeconds(1f);
        Debug.Log("2초후");
        yield return new WaitForSeconds(1f);
        Debug.Log("3초후");
        yield return new WaitForSeconds(1f);
        Debug.Log("4초후");
        yield return new WaitForSeconds(1f);
        Debug.Log("5초후");

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
        Debug.Log("변수의 값이 100 이상입니다");
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
