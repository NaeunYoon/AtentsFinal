using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class _12_17_Scale : MonoBehaviour
{
    void Start()
    {
        this.transform.localScale = new Vector3(2f, 2f, 2f);
        Debug.Log("localScale "+this.transform.localScale);     //������� ������ ��
        Debug.Log("lossyScale " + this.transform.lossyScale);   //�������� ������ ��

        /*
         �θ�ť�긦 333���� �ϸ� �ڽ� ť�갡 111�̾ 333���� ������� ť���� �������� �ȴ�
         ��������� ���� 2��(222)�� �þ���� ���������� ���� 6��(666)�� �þ��
         
        �⺻������ �̵� ȸ�� �������� �����ؼ� ��ȭ�� �� �� �ִ�
         */

        Debug.Log("localPosition " + this.transform.localPosition); //������� ��ġ�� (�θ�κ��� ~ ��ŭ �������ִ�)
        Debug.Log("Position " + this.transform.position);   //�������� ��ġ�� ( �� �߾����κ��� ~��ŭ �������ִ�)


    }

    void Update()
    {
        
    }
}
