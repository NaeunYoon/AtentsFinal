using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Move : MonoBehaviour
{
    //3d �������� ��ȭ�� �̵� ȸ�� ������ ���̴�
    //Ʈ���� ���� ���� �����ؼ� �̵��� �� �ִ�
    void Start()
    {
        
    }

    void Update()
    {
        //�ð��� ���� ��ġ�� ��� �ٲ�� �ϱ� ������ ������Ʈ���� ȣ���Ѵ�
        //�̵��� ��Ű���� �� ������Ʈ�� �پ��ִ� Ʈ������ ���� ������ ���� �����Ѵ�
        //x,y,z, ���� �����ϸ� �̵�
        Vector3 pos = this.transform.position;
        //pos.x += 0.05f;
        pos.x -= 0.05f;
       // pos.y += 0.05f;
        pos.y -= 0.05f;
        //pos.z += 0.05f;
        pos.z -= 0.05f;
        this.transform.position = pos;

    }
}
