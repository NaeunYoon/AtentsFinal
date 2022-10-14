using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class _09_29_Stick : MonoBehaviour
{
    public static _09_29_Stick instance;

    //스틱을 유일하게 하나만 존재하기 때문에 싱글톤으로 작업 가능

    /*
     스틱
        -스틱의 모양새
        -스틱의 작동 규칙 (원의방정식)
            안쪽 원을 드래그 (선택) 하여 움직이면 게임공간의 캐릭터가 움직인다
            바깥의 원의 영역을 벗어날 수 없다
            
    스틱의 모양은 원형
        -스틱의 리소스 구성
        
     */

    public Image inner;     //외부로 공개, image는 컴포넌트이다.
    /*public RectTransform inner2; */            //두번째 방법

    Vector3 startPos;       //방향벡터를 구하기 위해 vector 를 사용한다

    float radius;

    public RectTransform rcTr;

    public Vector3 dir { get; set; }//외부에서 dir을 변수처럼 가져다가 사용
    


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        startPos = inner.transform.position;

        radius = rcTr.sizeDelta.x * 0.5f;      //큰 원의 반지름을 구함 (ui의 크기를 구할 때 sizeDelta)
        
        dir = Vector3.zero;
    }

    
    void Update()
    {
        
    }
    public void OnpointerDown(BaseEventData _eventData) //마우스를 누를 떄의 행위에 대한 위치를 inner 에 대입
                                                        //이벤트 처리는 outer가 한다
    {
        //Down 누르는 위치를 알고자 한다면

        PointerEventData eventData = (PointerEventData) _eventData;
        Debug.Log("누른 위치="+eventData.position);
        inner.transform.position = eventData.position;
        //inner2.position = eventData.position;
    }

    public void OnpointerUP(BaseEventData _eventData)
    {
        //Down 누르는 위치를 알고자 한다면

        PointerEventData eventData = (PointerEventData)_eventData;
        Debug.Log("뗀 위치=" + Vector3.zero);
        //inner.transform.localPosition = Vector3.zero;
        inner.transform.position = startPos;
        //inner2.position = eventData.position;
        dir = Vector3.zero;
    }
        //드래그는 3가지 단계로 구분할 수 있다 (드래그 시작 -> 드래그 진행 -> 드래그 종료)

    public void OnBeginDrag(BaseEventData _eventData)    //드래그 시작
    {   
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = eventData.position;
    }

    public void OnDrag(BaseEventData _eventData)    //드래그 진행
    {
        PointerEventData eventData = (PointerEventData)_eventData;

        dir = eventData.position - (Vector2)startPos;       //형변환

        float distance = Vector3.Distance(startPos, eventData.position);    //거리구하기

        if(distance > radius)
        {
            inner.transform.position = startPos + dir.normalized* radius;         //두 벡터상의 한 점 계산
            //단위벡터 크기 1 
        }
        else
        {
            inner.transform.position = startPos + dir.normalized * distance;
            //단위벡터 1에 거리를 곱하면 거리까지의 길이가 된다(배수)
        }

        //두번째 방법

        //if (dir.sqrMagnitude > radius)
        //{
        //    inner.transform.position = startPos + dir.normalized * radius;         
        //}
        //else
        //{
        //    inner.transform.position = startPos + dir.normalized * dir.sqrMagnitude;
        //}



    }

    public void OnEndDrag(BaseEventData _eventData)    //드래그 종료
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = startPos;
    }


}
