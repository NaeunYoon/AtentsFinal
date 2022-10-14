using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_07_GameManager : MonoBehaviour
{//���ӸŴ����� �����غ� ��ӹ޴� �̱���, ���� �����ִ� ������
 //����Ʈ : ���ӸŴ��� �ȿ� �ν��Ͻ��� �־�� ��
    public static _10_07_GameManager instance;
    public Transform playerParent;
    public Transform monsterParent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        _10_07_InstanceManager.instance.Initialize();
        _10_07_InstanceManager.instance.CreatePlayer("TrollGiant",playerParent);
        //_10_07_InstanceManager.instance.CreateMonster("Cube", monsterParent);
        _10_07_InstanceManager.instance.CreateMonster("Village_1", monsterParent);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
