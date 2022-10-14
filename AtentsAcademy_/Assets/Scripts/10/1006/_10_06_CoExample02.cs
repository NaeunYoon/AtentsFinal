using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_06_CoExample02 : MonoBehaviour
{
    // Update �Լ��� ������ ������ �ϴ� �ڷ�ƾ �Լ��� �ۼ�
    //�ڷ�ƾ �Լ������� �ݺ����� ����Ѵ�
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
        //1. 1�ʵ��ȿ� ��� ȣ��
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
            //1�� ���ȿ� while�� �󸶳� ȣ��Ǵ��� �׽�Ʈ / ������Ʈ �Լ����� ��
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
