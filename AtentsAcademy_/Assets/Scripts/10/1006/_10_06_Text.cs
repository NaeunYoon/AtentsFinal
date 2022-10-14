using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_06_Text : MonoBehaviour
{
    // Start is called before the first frame update

    public Text scoreText;
    string converSation;
    void Start()
    {
        //scoreText.text = "마을에서 <color=#ff0000>고블린</color>을 퇴치해주세요";

        converSation = "마을에서 <color=#ff0000>고블린</color>을 퇴치해주세요";
        scoreText.text =string.Empty;

        char [] arrayObj = converSation.ToCharArray();
        StartCoroutine(DisplayString(arrayObj));
    }

    //<color=#ff0000>고</color> <color=#ff0000>블</color> <color=#ff0000>린</color>
    IEnumerator DisplayString(char[]_arrayObj)
    {   string[] tmp = {"마","을","에","서","<color=#ff0000>고</color>", "<color=#ff0000>블</color>", "<color=#ff0000>린</color>",
            "을", "퇴","치","해","주","세","요"};
        for(int i=0;i< tmp.Length;i++)//(int i=0;i< arrayObj.Length;i++)
        {
            //scoreText.text += _arrayObj[i];
            yield return new WaitForSeconds(0.2f);
            scoreText.text += tmp[i];
        }
        
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}/*
  코루틴 : 멀티스레드는 아니나 동시작업을 할 수 있는 방법
           사용법 : StartCoroutine(함수호출)

    IEnumerator(){
    yield return new WaitForSeconds(float Time) : 원하는 시간만큼 기다리는 것
    yield return new WaitForSecondsRealTime(flaot Time) : TimeScale의 영향을 받지 않고 현실 시간에만 작동
    yield return new WaitForFixedUpdate() : 다음 FixedUpdate가 실행될 때 까지 기다리기
    yield return new WaitForEndOfFrame(): 하나의 프레임 웍이 완전히 종료할 때 호출
                                          Update,LateUpdate 이벤트가 모두 실행되고 화면에 렌더링이 끝난 이후에 호출
    yield return null; : 다음 Update가 실행될 때 까지 기다린다는 의미.
                         Update가 먼저 실행되고 null을 반환했던 코루틴이 이어서 진행된 후 LateUpdate가 진행
    yield return new WaitUntil (System.Func<Bool>predicate); : 특정 조건식이 성공할 떄 까지 기다리는 방법
                               반환변수가 불값인 델리게이트/람다식

    }   

     yield return StartCoroutine(Ienumerator coroutine): 코루틴 내부에서 또 다른 코루틴을 호출
                                                         코루틴이 완료될때까지 기다리며 여러 작업을 수행
    StopCoroutine(IEnumerator coroutine)
  
    스타트 함수에 IEnumerator Start 쓸 수 있다
  
  
  
  */
