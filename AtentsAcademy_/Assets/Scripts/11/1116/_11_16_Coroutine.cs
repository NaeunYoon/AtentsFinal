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
            Debug.Log("무엇을 하는 코드");

           yield return new WaitForSeconds(1f);
        }
            Debug.Log("무엇을 다 함");
    }

    IEnumerator Variable()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
        }
        Debug.Log("정수의 값이 100 이상입니다");
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
