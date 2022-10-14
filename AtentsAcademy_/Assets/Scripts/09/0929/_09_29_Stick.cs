using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class _09_29_Stick : MonoBehaviour
{
    public static _09_29_Stick instance;

    //��ƽ�� �����ϰ� �ϳ��� �����ϱ� ������ �̱������� �۾� ����

    /*
     ��ƽ
        -��ƽ�� ����
        -��ƽ�� �۵� ��Ģ (���ǹ�����)
            ���� ���� �巡�� (����) �Ͽ� �����̸� ���Ӱ����� ĳ���Ͱ� �����δ�
            �ٱ��� ���� ������ ��� �� ����
            
    ��ƽ�� ����� ����
        -��ƽ�� ���ҽ� ����
        
     */

    public Image inner;     //�ܺη� ����, image�� ������Ʈ�̴�.
    /*public RectTransform inner2; */            //�ι�° ���

    Vector3 startPos;       //���⺤�͸� ���ϱ� ���� vector �� ����Ѵ�

    float radius;

    public RectTransform rcTr;

    public Vector3 dir { get; set; }//�ܺο��� dir�� ����ó�� �����ٰ� ���
    


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

        radius = rcTr.sizeDelta.x * 0.5f;      //ū ���� �������� ���� (ui�� ũ�⸦ ���� �� sizeDelta)
        
        dir = Vector3.zero;
    }

    
    void Update()
    {
        
    }
    public void OnpointerDown(BaseEventData _eventData) //���콺�� ���� ���� ������ ���� ��ġ�� inner �� ����
                                                        //�̺�Ʈ ó���� outer�� �Ѵ�
    {
        //Down ������ ��ġ�� �˰��� �Ѵٸ�

        PointerEventData eventData = (PointerEventData) _eventData;
        Debug.Log("���� ��ġ="+eventData.position);
        inner.transform.position = eventData.position;
        //inner2.position = eventData.position;
    }

    public void OnpointerUP(BaseEventData _eventData)
    {
        //Down ������ ��ġ�� �˰��� �Ѵٸ�

        PointerEventData eventData = (PointerEventData)_eventData;
        Debug.Log("�� ��ġ=" + Vector3.zero);
        //inner.transform.localPosition = Vector3.zero;
        inner.transform.position = startPos;
        //inner2.position = eventData.position;
        dir = Vector3.zero;
    }
        //�巡�״� 3���� �ܰ�� ������ �� �ִ� (�巡�� ���� -> �巡�� ���� -> �巡�� ����)

    public void OnBeginDrag(BaseEventData _eventData)    //�巡�� ����
    {   
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = eventData.position;
    }

    public void OnDrag(BaseEventData _eventData)    //�巡�� ����
    {
        PointerEventData eventData = (PointerEventData)_eventData;

        dir = eventData.position - (Vector2)startPos;       //����ȯ

        float distance = Vector3.Distance(startPos, eventData.position);    //�Ÿ����ϱ�

        if(distance > radius)
        {
            inner.transform.position = startPos + dir.normalized* radius;         //�� ���ͻ��� �� �� ���
            //�������� ũ�� 1 
        }
        else
        {
            inner.transform.position = startPos + dir.normalized * distance;
            //�������� 1�� �Ÿ��� ���ϸ� �Ÿ������� ���̰� �ȴ�(���)
        }

        //�ι�° ���

        //if (dir.sqrMagnitude > radius)
        //{
        //    inner.transform.position = startPos + dir.normalized * radius;         
        //}
        //else
        //{
        //    inner.transform.position = startPos + dir.normalized * dir.sqrMagnitude;
        //}



    }

    public void OnEndDrag(BaseEventData _eventData)    //�巡�� ����
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = startPos;
    }


}
