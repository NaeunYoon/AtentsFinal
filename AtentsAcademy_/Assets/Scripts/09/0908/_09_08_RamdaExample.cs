using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ToDo();

public class _09_08_RamdaExample : MonoBehaviour
{
    /*
     Update �Լ��ּ� ���ǹ��� �� ���� ����Ͽ� Ư�� �̺�Ʈ���� �Լ��� �����ϴ� �ڵ�
     �� �Լ� ȣ���� 1���� �Ѵ�
     */

    ToDo toDo;


    void Start()
    {
        toDo = null;
    }

    public void SetEevent(int _eventIndex, ToDo _toDo)
    {
        Debug.Log(_eventIndex+"�� �̺�Ʈ�߻�");
        //��������Ʈ ü��
        toDo = _toDo;
        toDo += _toDo;
    }

    public void SetEeventArray(int _eventIndex, ToDo[] _toDos)
    {
        Debug.Log(_eventIndex + "�� �̺�Ʈ�߻�");

        foreach(ToDo one in _toDos)
        {
            toDo += one;
        } 
    }


    public void EventAction()       //2�� �̺�Ʈ �߻� �� ȣ��
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
        {   //��ȯ������ �����ϴ� �Լ��ϰ�� ������ �Լ��� �迭�� ������ �� ȣ��

            //Delegate [] array = ToDo.GetInvocationList();
            //foreach(Delegate one in array)
            //{
            //    toDo
            //}

            //��ȯ������ �������� �ʴ� �Լ��� ���

            toDo();
            Debug.Log("End Todo");
            toDo -= toDo;           //null�� ���� �ǹ�
            //toDo = null;
        }
    }
}
