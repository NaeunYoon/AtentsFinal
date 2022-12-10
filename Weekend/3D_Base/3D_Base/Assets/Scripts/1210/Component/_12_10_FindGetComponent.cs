using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindGetComponent : MonoBehaviour
{
    _12_10_Slime slime1;
    void Start()
    {

        slime1 = GetComponent<_12_10_Slime>();
        //������ ������Ʈ���� ������Ʈ�� �����Ҷ�GetComponent
        //var obj = gameObject.GetComponent<_12_10_Dragon>();
        //obj.Attack();


        //������ ������Ʈ���� ������Ʈ���� ������ ��
        //_12_10_Dragon[] dragons = gameObject.GetComponents<_12_10_Dragon>();
        //foreach(var dragon in dragons)
        //{
        //    dragon.Attack();
        //}

        //------------------------------------------------
        //���������� �ڽĿ�����Ʈ�� ������Ʈ�� �ϳ� ������ ��

        //_12_10_Slime slime = this.GetComponentInChildren<_12_10_Slime>();
        //slime.Attack();
        ////���������� �ڽĿ�����Ʈ�� ������Ʈ���� ������ ��
        //_12_10_Dragon[] dragons = this.GetComponentsInChildren<_12_10_Dragon>();
        //foreach (var item in dragons)
        //{
        //    item.Attack();
        //}

        //���������󿡼� �θ� ������Ʈ�� ������ ��
        _12_10_Slime slime = this.GetComponentInParent<_12_10_Slime>();
        slime.Attack();

        _12_10_Slime [] slimes = this.GetComponentsInParent<_12_10_Slime>();
        foreach (var item in slimes)
        {
            item.Attack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update �޼��� �������� Getcomponent ���� �Լ��� ȣ���ϸ� �ȵȴ�
        //GetComponent�� ȣ������ ū �Լ��Դϴ�
        //Start�� Awake �Լ����� Getcomponent �Լ��� ȣ���ؼ�
        //������Ʈ�� �������� ����ʵ忡 ������ �ϰ�
        //����ʵ带 �̿��ؼ� ������Ʈ���� ������Ʈ�� �۵���Ű����

        //�̷��� ���� ����� ��

        //_12_10_Slime s = GetComponent<_12_10_Slime>();
        //s.Attack();

        slime1?.Attack();
    }
}
