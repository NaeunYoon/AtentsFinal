using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_CannonBall : MonoBehaviour
{

    private float _rot = 0f;

    private Vector3 _start;
    private Vector3 _end;

    void Start()
    {
        _start = _end = transform.position;
    }

    void Update()
    {

        //������ٵ� ����ϹǷμ� ���Ƿ� �߷°��� �ο��ϴ� ���� �ּ�ó�� ��


        ////���� ������ ( ����)���� ���ư��� �Ѵ�
        //this.transform.position += this.transform.forward * 10f * Time.deltaTime;
        ////�����̶� ȸ������ �ʾƵ� ������ �ȸ���θ� ��� ������ �������� �𸣱� ������ ȸ���� ��Ŵ


        //_end = this.transform.position;
        ////������� �������� ���ư��ٰ� �߷� ������ �ް� ��
        ////magnitude : ������ ũ��(����) end�� ���� ũ��� start�� ���� ũ���� ���� 4 �̻��� ���� �� ������ �߷��� ������ �޾ƶ�
        //if((_end.magnitude - _start.magnitude) > 4f)
        //{
        //    //���� �߷��� ������ �ޱ� ������ õõ�� �Ʒ��� �������� �Ѵ� ( ���� �������� ��������)
        //    _rot += 10f * Time.deltaTime;
        //    //�ʴ� 10�� �����̰� �Ѵ�
        //    this.transform.rotation = Quaternion.Euler(_rot, 0f, 0f);
        //}

        if(this.transform.position.y <= 0.0f)   //��ź�� ���鿡 ������ ��ź�� ���� ó���Ѵ�.
        {
            Destroy(this.gameObject,3f);
        }



    }
}
