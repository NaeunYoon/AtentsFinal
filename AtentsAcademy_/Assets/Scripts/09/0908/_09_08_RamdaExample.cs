using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ToDo();

public class _09_08_RamdaExample : MonoBehaviour
{
    /*
     Update 함수애서 조건문을 한 번만 사용하여 특정 이벤트에만 함수를 실행하는 코드
     단 함수 호출은 1번만 한다
     */

    ToDo toDo;


    void Start()
    {
        toDo = null;
    }

    public void SetEevent(int _eventIndex, ToDo _toDo)
    {
        Debug.Log(_eventIndex+"번 이벤트발생");
        //델리게이트 체인
        toDo = _toDo;
        toDo += _toDo;
    }

    public void SetEeventArray(int _eventIndex, ToDo[] _toDos)
    {
        Debug.Log(_eventIndex + "번 이벤트발생");

        foreach(ToDo one in _toDos)
        {
            toDo += one;
        } 
    }


    public void EventAction()       //2번 이벤트 발생 시 호출
    {
        Debug.Log("EventAction");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetEevent(2, EventAction);
        }

        if(toDo != null)
        {   //반환형식이 존재하는 함수일경우 각각의 함수를 배열로 저장한 후 호출

            //Delegate [] array = ToDo.GetInvocationList();
            //foreach(Delegate one in array)
            //{
            //    toDo
            //}

            //반환형식이 존재하지 않는 함수일 경우

            toDo();
            Debug.Log("End Todo");
            toDo -= toDo;           //null과 같은 의미
            //toDo = null;
        }
    }
}
