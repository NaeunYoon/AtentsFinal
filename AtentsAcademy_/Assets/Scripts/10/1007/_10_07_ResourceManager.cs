using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_07_ResourceManager : _10_07_Singleton<_10_07_ResourceManager>
{
    List<GameObject> rcChaList;
    const string charFolder = "Character";
  public void LoadCharacter()
    {
        rcChaList = new List<GameObject>(); //리소스 폴더에 있는 프리팹들을 리스트에 저장한다
        GameObject[] objs = Resources.LoadAll<GameObject>(charFolder);
        foreach(GameObject one in objs)
        {
            rcChaList.Add(one);
        }
    }
    public GameObject GetRcCharacter(string _name)  //로드한 리소스들을 리스트에 저장하고 내가 원하는 리소스를 검색해서 반환
    {
        return rcChaList.Find(o => (o.name.Equals(_name)));      //o.gameObject.name.Equals(_name) 결과는 같음
    }
}
