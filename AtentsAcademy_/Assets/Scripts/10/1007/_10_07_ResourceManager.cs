using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_07_ResourceManager : _10_07_Singleton<_10_07_ResourceManager>
{
    List<GameObject> rcChaList;
    const string charFolder = "Character";
  public void LoadCharacter()
    {
        rcChaList = new List<GameObject>(); //���ҽ� ������ �ִ� �����յ��� ����Ʈ�� �����Ѵ�
        GameObject[] objs = Resources.LoadAll<GameObject>(charFolder);
        foreach(GameObject one in objs)
        {
            rcChaList.Add(one);
        }
    }
    public GameObject GetRcCharacter(string _name)  //�ε��� ���ҽ����� ����Ʈ�� �����ϰ� ���� ���ϴ� ���ҽ��� �˻��ؼ� ��ȯ
    {
        return rcChaList.Find(o => (o.name.Equals(_name)));      //o.gameObject.name.Equals(_name) ����� ����
    }
}
