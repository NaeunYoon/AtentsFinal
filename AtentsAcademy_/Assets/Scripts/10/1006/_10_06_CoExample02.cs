using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_06_CoExample02 : MonoBehaviour
{
    // Update 함수와 유사한 역할을 하는 코루틴 함수를 작성
    //코루틴 함수에서는 반복문을 사용한다
    public bool isUpdate { get; private set; }
    float coElapsed;
    float elapsed;
    int count;
    int coCount;
    void Start()
    {
        coElapsed = 0;
        elapsed = 0;
        isUpdate = true;
        StartCoroutine(Loop());
    }

    IEnumerator Infinity()
    {
        
        for(int i = 0; i < 10; i++)
        {
            Debug.Log(i);
            yield return new WaitForEndOfFrame();   
        }
    }
    private void Update()
    {
        elapsed+=Time.deltaTime;
        count++;
        //1. 1초동안에 몇번 호출
        if(elapsed >= 1f)
        {
            elapsed -= 1f;
            Debug.Log(count);
            count = 0;
        }
    }
    IEnumerator Loop()
    {

        while (isUpdate)
        {
            //1초 동안에 while이 얼마나 호출되는지 테스트 / 업데이트 함수와의 비교
            coElapsed += Time.deltaTime;
            if(coElapsed >= 1)
            {
                coElapsed -= 1f;
                coCount++;
                Debug.Log(coCount);
                coCount = 0;
            }   
            yield return null;
        }
        yield break;
        
    }
    


}
