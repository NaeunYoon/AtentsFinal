using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_14_GetComponentInParent : MonoBehaviour
{
    void Start()
    {
        //���������󿡼� �θ������ ������Ʈ�� �ϳ� ������ ��
        _12_24_Slime slime = this.gameObject.GetComponentInParent<_12_24_Slime>();
        //�� ������Ʈ�� �ִ� ��ġ���� ���� �θ� �ѹ� ã�´�
        slime.Attack();

        //���������󿡼� �θ� ������ ������Ʈ�� ������Ʈ�� ��� ������ �� ��
        _12_24_Slime[] slimes = gameObject.GetComponentsInParent<_12_24_Slime>();
        foreach (var item in slimes)
        {
            item.Attack();
        }
    }

    void Update()
    {
        //UpDate �޼��� �������� GetComponent ���� �Լ��� ȣ���ϸ� �ȵȴ�
        //GetComponent�� ȣ�� ����� ū �Լ��̴�
        //Start�� Awake �Լ����� GetComponent �� ȣ���ؼ� ������Ʈ�� �������� ����ʵ忡 �����ϰ�
        //����ʵ带 �̿��ؼ� Update���� ������Ʈ�� �۵����Ѿ� �Ѵ�.

        //�̷��� ����ϸ� �ȵ�->
        //_12_24_Slime slime01 = gameObject.GetComponent<_12_24_Slime>();
        //slime01.Attack();
    }
}
