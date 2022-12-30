using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class _12_17_Target : MonoBehaviour
{
    [SerializeField] public Transform target;

    float yrot = 0f;
    float xroy = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        //������Ʈ�� Ȯ �Ĵٺ��� ����� ��.
        this.transform.LookAt(target);

        //������Ʈ�� ������ �Ĵٺ��� ����� �Ϸ���?
        //Ÿ���ϰ� �ش� ������Ʈ���� ���Ͱ��� ����� 
        //Ÿ���� ������, Ÿ����ġ���� ���� ��ġ�� ����, Ÿ�� �������� ���ϴ� ���Ͱ� �����
        //���⺤�͸� ������µ� ���� ���� ������Ʈ�� �ٸ� ���� ����Ű�� ����
        //�迧�� �ٸ����� ���� �ִٰ� Ÿ�������� ȸ���ϰ� �ϴ� ���ε�
        //Ȯ ȸ����Ű�� ���� �ƴ϶� ������ ȸ����Ű�� �ϰ� ����
        //�� ��Ÿ����ŭ�� ȸ����Ű�� ���� �迧 �Լ��� �ϴ� ���ε�
        //�׷���, ���⺤�͸� ���� ������ �ش� �����ǿ� ���ʹϾ��� ������ ���ش�
        Vector3 dir = target.transform.position - this.transform.position;
        //�����Լ��� ����϶�� ��
        //�� ȸ�� = ���� ���� ��ġ�� ȸ�� ������ Ÿ���� ���⺤���� ȸ������ �����ְ�, ȸ���ӵ��� �����ؼ� �����Ѵ�
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir),Time.deltaTime * 0.8f);
        //start -------------------------------------end
        //this.transform.rotation         Quaternion.LookRotation(dir)
        //0-------------------------------------------1.0
        //0.1 �̸� 10��ŭ ���ִ°���


        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * 0.03f);
        //rpg ���Ͱ����� ���� �� ����ٴϵ��� �ϴ� �� ����Ѵ�

        //Ÿ���� �߽����� �����ϴ� �Լ�
        this.transform.RotateAround(target.transform.position, Vector3.up, 10f * Time.deltaTime);
        //y���� �������� �� ������Ʈ�� Ÿ���� ������ ����
        //�Ǵ� ���� ���Ƿ� ���͸� ���� �� ���� ����
        //this.transform.RotateAround(target.transform.position, new Vector3(1f,0f,1f), 10f * Time.deltaTime);


    }
}
