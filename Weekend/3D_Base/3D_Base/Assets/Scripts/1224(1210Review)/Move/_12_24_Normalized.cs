using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class _12_24_Normalized : MonoBehaviour
{

    private float speed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        //�������� : ���̰� 1�� ���� (���Ⱚ�� ����)
        //
        //transform.position += new Vector3(1.0f, 1.0f, 0.0f).normalized * speed * Time.deltaTime;
        //���⸸ ������ �ְ� ũ��� 1�� �����̴�. ���ǵ� ���� ���� �ְ� ��Ÿ�� �ָ�
        //1�ʿ� 10��ŭ �̵��ϰ� �� �� �ִ�

        //�⺻������ �������ִ� ���� Ÿ�� (�� �� ��ü�� ����������)
        transform.position += Vector3.up * speed * Time.deltaTime;
        //transform.position += Vector3.left * speed * Time.deltaTime;
        //transform.position += Vector3.right * speed * Time.deltaTime;
        //transform.position += Vector3.one * speed * Time.deltaTime;
        //transform.position += Vector3.down * speed * Time.deltaTime;
        //transform.position += Vector3.forward * speed * Time.deltaTime;



    }
}
