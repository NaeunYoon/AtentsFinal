using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_07_InstanceManager : _10_07_Singleton<_10_07_InstanceManager>
{//���� ������ �ν��Ͻ��� ���� �ִ� �Ŵ��� (ĳ���� ���������� ����Ʈ�� ���� (����))

    public List<_10_07_Character<CHARACTER>> chaList;     //���͸� ����
    public List<_10_07_Character<MONSTER>> monList;
    public _10_07_Player player; //��������� ���� (�ܺο��� �ν��Ͻ� ĳ���� �÷��̾ �� �� �ְ�) 
                          //�÷��̾�� ĳ���Ϳ� ���� ���� ���ϴ°� ���� (���� �����ص� ��)
    public _10_07_Monster monster;


  public void Initialize()
    {
        chaList = new List<_10_07_Character<CHARACTER>>();
        _10_07_ResourceManager.instance.LoadCharacter();
        monList = new List<_10_07_Character<MONSTER>>();
    }
    
    public void CreatePlayer(string _name,Transform _playerParent)
    {
      GameObject rcObj=  _10_07_ResourceManager.instance.GetRcCharacter(_name); //�ε�� ĳ������ �ν��Ͻ��� ����
      GameObject createObj =  GameObject.Instantiate<GameObject>(rcObj);

      /*_10_07_Character chaScript =  createObj.AddComponent<_10_07_Player>();*/    //������
      player = createObj.AddComponent<_10_07_Player>();    //������
      player.gameObject.layer = LayerMask.NameToLayer("Player");        //���̾�� �±״� �����ͻ� �������� �Ѵ� (������ ���ص� ��)
      player.tag = "Player";
      player.transform.position = _10_07_GameHelper.GetHeightMapPos(Vector3.zero);     //���� ���̿� ������� ĳ���� ��ġ
      player.transform.SetParent(_playerParent);                                                                                   //ĳ���� ������ġ�� ���Ͽ� ����Ǿ� �ְų� �����κ��� �����޴´�
    
    }

    //public void CreateMonster(string _name, Transform _monsterParent)
    //{
    //    GameObject rcObj = _10_07_ResourceManager.instance.GetRcCharacter(_name); //�ε�� ĳ������ �ν��Ͻ��� ����
    //    GameObject createObj = GameObject.Instantiate<GameObject>(rcObj);

    //    /*_10_07_Character chaScript =  createObj.AddComponent<_10_07_Player>();*/    //������
    //        //������
    //    monster.gameObject.layer = LayerMask.NameToLayer("Monster");        //���̾�� �±״� �����ͻ� �������� �Ѵ� (������ ���ص� ��)
    //    monster.tag = "Monster";
    //    monster.transform.position = _10_07_GameHelper.GetHeightMapPos(Vector3.zero);     //���� ���̿� ������� ĳ���� ��ġ
    //    monster.transform.SetParent(_monsterParent);                                                                                   //ĳ���� ������ġ�� ���Ͽ� ����Ǿ� �ְų� �����κ��� �����޴´�
    //}


    //���̺��� �ε��� ������ ���͸� ����, �Ǵ� �������� �������� �����͸� ������� ����
    //���� �ΰ����� �ɷ´��� ���� : ���̺� �ε�
    public void CreateMonster(string _fieldName,Transform _monsterPatent) 
    {
        //���̺��� �ƴ� 10������ ������ �ν��Ͻ��� ����
        for(int i = 0; i < 10; i++)
        {
            GameObject rcObj = _10_07_ResourceManager.instance.GetRcCharacter("Cube");
            GameObject createObj = GameObject.Instantiate<GameObject>(rcObj);
            _10_07_Character<MONSTER> addedScript  = createObj.AddComponent<_10_07_Monster>();
            MONSTER tmp = new MONSTER();
            tmp.name = "MONSTER" + i.ToString();
            tmp.eBelong = eBelong.COUNTRY1;
            tmp.type = 1;
            addedScript.data = tmp;
            Vector3 _spawnPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), Random.Range(-5f, 5f));
            
            createObj.transform.position = _10_07_GameHelper.GetHeightMapPos(_spawnPos);
            createObj.transform.SetParent(_monsterPatent);
            monList.Add(addedScript);
        }

    }
    //public void CreateMonster(string _name, Transform _monsterParent)
    //{

    //}
    //public void CreateMonster(string _fieldName, Transform _monsterParent)//���̺��� �ִ� ��� ���� �̸��� �Ѿ��
    //{

    //}

}
