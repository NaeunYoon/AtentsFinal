using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_04_Obj_Pooling : MonoBehaviour
{
    /*
     오브젝트 풀링 기법 : 게임오브젝트를 생성하고 삭제할 때 발생하는 오버헤드를 줄이는 방법
                          한번 생성된 게임 오브젝트를 재사용하기 위해 풀을 이용한다

     재사용하기 위한 방법 : 삭제 대신 비활성화를 이용하여 풀에 보관하고, 
                            삭제해야 할 게임 오브젝트는 풀에서 검색하여 활성화시켜 사용
                            삭제 대신 비활성화, 생성 시 활성화, 활성화 할 게임 오브젝트가 없을 경우 생성

     필요한 내용 : 생성된 게임 오브젝트를 저장할 자료구조 (List)
                   List<GameObject> moblist;
                   그러나 몬스터에 오브젝트 풀링 기법을 적용하고자 한다면 컴포넌트 형식으로 리스트에 저장해야 한다
                   (GetComponent 함수를 사용하지 않기 위해) => List<Monster> moblist;
     
     
     */

    List<Monster> moblist;                              //1. 스크립트 타입을 저장하도록 선언함
    //활성화 된 게임오브젝트만 존재하는 리스트
    //비활성화 된 게임 오브젝트만 존재하는 리스트로 동시에 사용하여 구분/관리 할 수도 있음

    private void Awake()
    {
        moblist = new List<Monster>();                  //2. 초기화
    }
    void Start()
    {
        string name = string.Empty;
        for(int i = 0; i < 10; i++)
        {
            name = "Meshtint Free Knight_" + i.ToString();
            Monster monstrtScript = CreateMonster(name);
            //화면에 등장하는 게임 오브젝트 이름이 동일하기 때문에 바꿔준다
            monstrtScript.gameObject.name = "Meshtint Free Knight_" + i.ToString();
            //생성한 몬스터의 이름과 위치를 변경
            monstrtScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
        
    }

    public Monster CreateMonster(string _name)                      //3. 몬스터 생성 함수
    {
        Monster monsterScript = moblist.Find(o => (/*o.gameObject.name.Equals(_name)&& */o.gameObject.activeSelf==false));  
        //비활성화 된 오브젝트가 존재하면 무조건 가져와서 활성화
        //리스트에서 생성하고자 하는 게임오브젝트와 이름이 동일한 게임오브젝트 검색 && 비활성화 된 게임오브젝트를 검색

        if(monsterScript != null)   //찾고자 하는(사용할 수 있는) 몬스터가 있으면 실행 -> 리스트에서 검색한 오브젝트를 리턴 (활성화)
        {
            monsterScript.gameObject.SetActive(true); 
            return monsterScript;
        }
        else                       //새로 생성해줘야 하는 경우, 리소스매니저 클래스를 사용하여 필요한 리소스 로드
        {
            int pos = name.IndexOf("_");
            string rcName = name.Substring(0,_name.Length - (_name.Length- pos));

           GameObject rcMonster= Resources.Load<GameObject>(rcName);
           GameObject monsterObj = Instantiate<GameObject>(rcMonster);      //로드한 리소스를 인스턴시에이트
            Monster newMonsScr = monsterObj.AddComponent<Monster>();        //생성한 오브젝트에 스크립트 추가
            moblist.Add(newMonsScr);                                        //리스트에 저장
            return newMonsScr;                                              //내가 저장한 스크립트 반환
        }
    }
    public void DisableMonster(string _name)     //이름을 매개변수로 전달받아서 이 이름의 몬스터를 검색, 화면에 활성화된 상태여야 한다
    {
        Monster monsterScript = moblist.Find(o => (o.gameObject.name.Equals(_name) && o.gameObject.activeSelf == true));

        if(monsterScript != null)
        {
                 monsterScript.gameObject.SetActive(false);      //비활성화
        }
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    
        {
            string name = "Meshtint Free Knight_" + Random.Range(0, 10).ToString();
            DisableMonster(name);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            string name = "Meshtint Free Knight_" + Random.Range(0, 10).ToString();
            Monster monstrtScript = CreateMonster("Meshtint Free Knight");
            monstrtScript.gameObject.name = "Monster";
            monstrtScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
    }
}
