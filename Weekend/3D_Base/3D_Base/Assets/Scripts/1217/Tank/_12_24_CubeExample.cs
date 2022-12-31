using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class _12_24_CubeExample : MonoBehaviour
{
    private Vector3 _pos;

    void Start()
    {
        
    }

    public void SetPosition(Vector3 pos)
    {
        _pos = pos;
    }
    void Update()
    {
        //��ũ���� ����� �� ��ũ���� ��ġ������ ť���� ��ġ�� ���� ���⺤�͸� ���Ѵ�. (������ ũ��� �ʿ䰡 ����)
        //������ ���ؼ� ���⸸ �ϸ� �Ǳ� ������ ���Ⱚ�� �ʿ���
        //���ʹ� ����� ũ�⸦ ���� �������ε�, ũ��� �ʿ� ���� ������ ũ�⸦ normalized �ؼ� 1�� ������ش�
        //������ ���̸� 1�� ���� ���͸� �������� ��� �Ѵ� ( ���� ���⸸ �ʿ��� �� ����Ѵ�)

        Vector3 direction = _pos - transform.position; //���⺤�͸� �������
        //���⸸ ������ �Ǵϱ� ����ȭ�� ���ش� (ũ�⸦ ������ �ִ� ����)
        //normalized �����ν� ũ�Ⱑ 1�� ���͸� �����ش�
        //transform.position += direction.normalized *2f * Time.deltaTime;
        transform.position += new Vector3( direction.x,0f,direction.z).normalized * 2f * Time.deltaTime;
        //
    }
}
