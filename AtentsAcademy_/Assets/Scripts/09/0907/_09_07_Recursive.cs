using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_07_Recursive : MonoBehaviour
{
    /*자식의 게임 오브젝트에서 특정 게임오브젝트를 검색하는 함수 작성 (재귀호출) */

    void Start()
    {
        Transform findTr = FindGameObjectInChild("Bip001 Neck", transform);
        if(findTr != null)
        {
            Debug.Log(findTr.name);
        }
    }

    public Transform FindGameObjectInChild(string _name, Transform _tr)
    {
        if (_tr.name == _name)
            return _tr;
        for(int i = 0; i < _tr.childCount; i++)
        {
            Transform childTr = FindGameObjectInChild(_name, _tr.GetChild(i));
            if(childTr != null)
            {
                return childTr;
            }
        }
            return null;
        
    }
    void Update()
    {
        
    }
}
