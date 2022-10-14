using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_07_InstanceManager : _10_07_Singleton<_10_07_InstanceManager>
{//내가 생성한 인스턴스를 갖고 있는 매니저 (캐릭터 생성했으면 리스트를 저장 (보관))

    public List<_10_07_Character<CHARACTER>> chaList;     //몬스터를 저장
    public List<_10_07_Character<MONSTER>> monList;
    public _10_07_Player player; //멤버변수로 선언 (외부에서 인스턴스 캐릭터 플레이어를 알 수 있게) 
                          //플레이어는 캐릭터와 같이 저장 안하는게 나음 (같이 저장해도 됨)
    public _10_07_Monster monster;


  public void Initialize()
    {
        chaList = new List<_10_07_Character<CHARACTER>>();
        _10_07_ResourceManager.instance.LoadCharacter();
        monList = new List<_10_07_Character<MONSTER>>();
    }
    
    public void CreatePlayer(string _name,Transform _playerParent)
    {
      GameObject rcObj=  _10_07_ResourceManager.instance.GetRcCharacter(_name); //로드된 캐릭터의 인스턴스를 생성
      GameObject createObj =  GameObject.Instantiate<GameObject>(rcObj);

      /*_10_07_Character chaScript =  createObj.AddComponent<_10_07_Player>();*/    //다형성
      player = createObj.AddComponent<_10_07_Player>();    //다형성
      player.gameObject.layer = LayerMask.NameToLayer("Player");        //레이어와 태그는 에디터상에 만들어놔야 한다 (지정은 안해도 댐)
      player.tag = "Player";
      player.transform.position = _10_07_GameHelper.GetHeightMapPos(Vector3.zero);     //지형 높이에 상관없는 캐릭터 배치
      player.transform.SetParent(_playerParent);                                                                                   //캐릭터 생성위치는 파일에 저장되어 있거나 서버로부터 내려받는다
    
    }

    //public void CreateMonster(string _name, Transform _monsterParent)
    //{
    //    GameObject rcObj = _10_07_ResourceManager.instance.GetRcCharacter(_name); //로드된 캐릭터의 인스턴스를 생성
    //    GameObject createObj = GameObject.Instantiate<GameObject>(rcObj);

    //    /*_10_07_Character chaScript =  createObj.AddComponent<_10_07_Player>();*/    //다형성
    //        //다형성
    //    monster.gameObject.layer = LayerMask.NameToLayer("Monster");        //레이어와 태그는 에디터상에 만들어놔야 한다 (지정은 안해도 댐)
    //    monster.tag = "Monster";
    //    monster.transform.position = _10_07_GameHelper.GetHeightMapPos(Vector3.zero);     //지형 높이에 상관없는 캐릭터 배치
    //    monster.transform.SetParent(_monsterParent);                                                                                   //캐릭터 생성위치는 파일에 저장되어 있거나 서버로부터 내려받는다
    //}


    //테이블에서 로드한 내용대로 몬스터를 생성, 또는 서버에서 내려받은 데이터를 기반으로 생성
    //게임 인공지능 능력단위 참고 : 테이블 로드
    public void CreateMonster(string _fieldName,Transform _monsterPatent) 
    {
        //테이블이 아닌 10마리의 몬스터의 인스턴스를 생성
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
    //public void CreateMonster(string _fieldName, Transform _monsterParent)//테이블이 있는 경우 마을 이름이 넘어옴
    //{

    //}

}
