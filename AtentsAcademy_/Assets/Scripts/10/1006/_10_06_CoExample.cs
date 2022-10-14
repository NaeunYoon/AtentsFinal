using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_06_CoExample : MonoBehaviour
{
    IEnumerator coroutine;
    private void Awake()
    {
        coroutine = Test_1();
    }

    IEnumerator Start()
    {
        StartCoroutine(coroutine);      //������ �ڷ�ƾ ȣ��

        yield return null;      //1. ���� ������Ʈ ���� �����ϰڴ� => �Ʒ��� �ִ� ���� ���� �ȵ�
        Debug.Log("after null");
        yield return new WaitForSeconds(2f);        //3. 2�ʵ��� ��ٸ��� (2�� �ڿ� ����)
        yield return StartCoroutine(Test_1());      //5. �׽�Ʈ1 ����
        yield return StartCoroutine(Test_2());      //12. test_1ȣ�� ���Ŀ� test2 ȣ��
    }


    IEnumerator Test_1()        //6. ����
    {
        for(int i=0; i < 10; i++)
        {
            Debug.Log(i);       //7. 0���
            yield return null;      //8. ���� ������Ʈ ���Ŀ� ����
                                    //10. 1���
        }
    }

    IEnumerator Test_2()    //13. ȣ��
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i+"#");   //14. 0#ȣ��
                                //16. ȣ�⤤
            yield return null;
        }
    }

    
    void Update()       //2. ������Ʈ �Լ� 2�� ȣ��
                        //4. ������Ʈ ȣ��
                        //9. ������Ʈ ȣ��
                        //11. ������Ʈ ȣ��
                        //15. ȣ��
    {
        Debug.Log("update");
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(coroutine);
        }

    }
}
