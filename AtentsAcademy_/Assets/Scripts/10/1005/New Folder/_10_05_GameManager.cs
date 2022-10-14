using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_05_GameManager : MonoBehaviour
{
    List<_10_05_Monster> mobList;
    public Transform mobParent;
    private void Awake()
    {
        mobList = new List<_10_05_Monster>();
    }
    void Start()
    {

        Vector3 rayPos = Vector3.zero;
        for(int i = 0; i < 10; i++)
        {
            float x = Random.Range(-15, 15);
            float y = Random.Range(-15, 15);
        }


        createCharacter(Vector3.zero,"Cube");
    }
    //public _10_05_Monster CreateCharacter(Vector3 _origin, string _name)
    //{
    //    _origin.y += 100f;
    //    RaycastHit hit;
    //    if (Physics.Raycast(_origin, -Vector3.up, out hit, Mathf.Infinity))
    //    {
    //       GameObject rcChar = _10_05_ResourceManager.instance.GetCharacter(_name);
    //       GameObject obj = GameObject.Instantiate<GameObject>(rcChar,hit.point,Quaternion.identity);
    //        _10_05_Monster script = obj.AddComponent<_10_05_Monster>();
    //        mobList.Add(script);
    //        return script;
    //    }return null;
    //}

    public Vector3? GetTerrainPosition(Vector3 _origin)     //nullable �� ������ ����/��Ÿ�� ������ null�� ������ �� �ִ�
                                                            //int? a = null;
                                                            //a=200;
                                                            //DATA? findData = info.FindData("");       ����ü���� ��� ����
                                                            //if(findData.HasValue)
                                                            //Debug.Log(findData.Value.name);
    {
        _origin.y += 100f;
        RaycastHit hit;
        if (Physics.Raycast(_origin, -Vector3.up, out hit, Mathf.Infinity))
        {
            return hit.point;
        }return null;
    }
    public _10_05_Monster createCharacter(Vector3 _origin, string _name)
    {
        Vector3? terrainPos = GetTerrainPosition(_origin);
        {
            if (terrainPos.HasValue)
            {
                GameObject rcChar = _10_05_ResourceManager.instance.GetCharacter(_name);
                GameObject obj = GameObject.Instantiate<GameObject>(rcChar, terrainPos.Value, Quaternion.identity);
                _10_05_Monster script = obj.AddComponent<_10_05_Monster>();
                mobList.Add(script);
                return script;
            }
            return null;
        }
        }
    
    void Update()
    {
        
    }
}
