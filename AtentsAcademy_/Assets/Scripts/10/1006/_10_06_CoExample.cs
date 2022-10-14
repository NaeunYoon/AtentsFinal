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
        StartCoroutine(coroutine);      //변수로 코루틴 호출

        yield return null;      //1. 다음 업데이트 이후 진입하겠다 => 아래에 있는 구문 실행 안됨
        Debug.Log("after null");
        yield return new WaitForSeconds(2f);        //3. 2초동안 기다린다 (2초 뒤에 진입)
        yield return StartCoroutine(Test_1());      //5. 테스트1 실행
        yield return StartCoroutine(Test_2());      //12. test_1호출 이후에 test2 호출
    }


    IEnumerator Test_1()        //6. 실행
    {
        for(int i=0; i < 10; i++)
        {
            Debug.Log(i);       //7. 0출력
            yield return null;      //8. 다음 업데이트 이후에 진입
                                    //10. 1출력
        }
    }

    IEnumerator Test_2()    //13. 호출
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i+"#");   //14. 0#호출
                                //16. 호출ㄴ
            yield return null;
        }
    }

    
    void Update()       //2. 업데이트 함수 2번 호출
                        //4. 업데이트 호출
                        //9. 업데이트 호출
                        //11. 업데이트 호출
                        //15. 호출
    {
        Debug.Log("update");
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(coroutine);
        }

    }
}
