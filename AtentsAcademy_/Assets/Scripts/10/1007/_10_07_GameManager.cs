using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_07_GameManager : MonoBehaviour
{//게임매니저는 모노비해비어를 상속받는 싱글톤, 씬과 관련있는 컨텐츠
 //퀘스트 : 게임매니저 안에 인스턴스가 있어야 함
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
