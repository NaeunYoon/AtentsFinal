using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_05_Coroutine : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("��ŸƮ");

        StartCoroutine(DisplayData());
    }

    IEnumerator DisplayData()
    {
        Debug.Log("before yield");
        yield return null;
        Debug.Log("after yield");
    }
    void Update()
    {
        Debug.Log("������Ʈ");
    }
}
