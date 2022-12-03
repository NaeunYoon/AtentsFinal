using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_03_GetComponentTest : MonoBehaviour
{
    // �������� ����� ��쿡�� Ŭ���� �ȿ��� �������ְ� awake���� �ʱ�ȭ���ش�

    private _12_03_Attack _attack;


    //���࿡ �� ������Ʈ�� �Ȱ��� ��ũ��Ʈ�� ���ٸ�??
    //�������ϱ� �迭�� �޾ƾ� �Ѵ�.
    private _12_03_Attack[]  _attacks;

    private void Awake()
    {
        _attack = GetComponent<_12_03_Attack>();    //���� �����ִ� �ϳ��� �����´�

        _attacks = GetComponents<_12_03_Attack>(); //���� ������Ʈ �ȿ� �ִ� ���� ������Ʈ���� ��� �����´�
        foreach(var attack in _attacks)
        {
            Debug.Log("----------------------");
            attack.Attack();
            attack.Defence();
            attack.Run();
        }

    }
    void Start()
    {
        //1�� ���
        var attack = this.GetComponent<_12_03_Attack>();
        
        _12_03_Attack attack2 = this.GetComponent<_12_03_Attack>();

        /*
         �� ������Ʈ�� ���� ������Ʈ�� �����
        �̹� ������Ʈ�� a������Ʈ�� �ְ�, �ٸ� ������Ʈ(b)���� a������Ʈ�� �ҷ��ͼ� ����Ѵ�.
        ���� ������Ʈ ���� ������Ʈ�� �ҷ��� �� ����Ѵ� (����ϰ� �����)
         */

        attack.Attack();
        attack.Defence();
        attack.Run();

        //2����� �̷��� ����� �� ����
        this.GetComponent<_12_03_Attack>().Attack();
        this.GetComponent<_12_03_Attack>().Defence();
        this.GetComponent<_12_03_Attack>().Run();

        //3����� : �Լ� �ȿ����� ����ϴ°� �ƴ϶��, ����ʵ�� �����ؼ� ����Ѵ� ( �ٸ� �Լ����� ��� ����) 
        _attack.Attack();
        _attack.Run();
        _attack.Defence();


        /*getComponent�� ���ſ� �Լ��� ����ϰ� ȣ���� ��쿡�� 1��ó�� ����
         ���� ȣ���ϴ� ��쿡�� 2������� ����Ѵ�.
         ����ʵ�� ����� ��쿡�� 3�� ����� ����Ѵ�.
         */
    }

    // Update is called once per frame
    void Update()
    {
        _attack.Attack();
        
    }
}
