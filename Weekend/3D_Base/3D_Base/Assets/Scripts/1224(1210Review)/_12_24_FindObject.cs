using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindObject : MonoBehaviour
{
    void Start()
    {
        //�� ���� ��� ������Ʈ �߿��� Ư���� �̸��� ������Ʈ�� ã�� ��
        //��¿ �� ���� �� ����Ѵ� (�ַ� ��� ���ϴ� �� ��õ)
        GameObject obj = GameObject.Find("TargetObject");
        //�̸��� ���� ������Ʈ�� ã�Ƽ� �������ش�

        //������Ʈ�� ���� ��쿡�� �����Ű�� �ʴ´� => �������ڵ� �����
        obj?.SetActive(false);

        

    }

    void Update()
    {
        
    }
}
