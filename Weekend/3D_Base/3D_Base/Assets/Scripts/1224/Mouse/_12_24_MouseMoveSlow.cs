using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_MouseMoveSlow : MonoBehaviour
{

    Vector3 pos;

    /*
     ���ʹ� ����� ũ�⸦ ������ ������ ���� ũ��� �ʿ䰡 ����
     �׷��� ������ ũ�⸦ 1�� ����������
     
     */

    void Start()
    {
        
    }

    public void SetPosition(Vector3 _pos)
    {
        pos = _pos;
    }

    void Update()
    {
        Vector3 direction = pos - transform.position;     //���⺤��
        //transform.position += direction.normalized * 2.0f * Time.deltaTime;

        transform.position += new Vector3(direction.x, 0f, direction.z).normalized * 2.0f * Time.deltaTime;

    }
}
