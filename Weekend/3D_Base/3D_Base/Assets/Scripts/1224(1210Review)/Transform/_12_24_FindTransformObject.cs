using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindTransformObject : MonoBehaviour
{
    void Start()
    {
        //���� ������Ʈ�� ������ Ʈ�������� ������ �ִ�
        //��� ���������� �ִ� ���� ã���ش�
        //���������󿡼� �ڽ� ������Ʈ�� �̸����� ã�� ��,
        Transform tr = transform.Find("Cube (3)");
        tr.gameObject.SetActive(false);
        //�� ���ӿ�����Ʈ�� �ƴ϶� �θ𿡴ٰ� �־��ش�.
        //�ڽ����� �ִ� ��츸 �ȴ� (�ڽ��� �ڽ��� �ȵ�)
    }

    void Update()
    {
        
    }
}
