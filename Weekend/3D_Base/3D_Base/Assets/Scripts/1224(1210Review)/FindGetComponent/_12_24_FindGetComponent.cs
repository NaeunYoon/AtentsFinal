using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindGetComponent : MonoBehaviour
{
    
    void Start()
    {
        //������Ʈ�� �پ��ִ� ������Ʈ�� ������ ��
        //������ ������Ʈ���� ������Ʈ�� ������ �� GetComponent
        _12_24_Dragon obj = gameObject.GetComponent<_12_24_Dragon>();
        obj.Attack();
        //�� ������Ʈ�� �߰��Ǿ��ִ� ���� ���ӿ�����Ʈ�� ������Ʈ�� �����´�
        //������ ������Ʈ���� ������Ʈ�� ������ ��


        //������Ʈ�� ������Ʈ�� ���� ���� ���� ��?
        //�װ� ���� �� �����;� �� ��
        //������ ������Ʈ���� ���� �̸��� ������Ʈ�� ��� ������ ��
        _12_24_Dragon[] dragons = gameObject.GetComponents<_12_24_Dragon>();
        foreach (var item in dragons)
        {
            item.Attack();
        }

    }

    void Update()
    {
        
    }
}
