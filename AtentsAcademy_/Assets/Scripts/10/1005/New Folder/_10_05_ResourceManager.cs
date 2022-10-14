using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_05_ResourceManager : MonoBehaviour
{
    public static _10_05_ResourceManager instance;

    List<GameObject> rcCharList;        //로드한 리소스를 담을 리스트

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        rcCharList = new List<GameObject>();
        CharacterLoad();
    }

    public void CharacterLoad()
    {
       GameObject[] rcChar= Resources.LoadAll<GameObject>("Character/");
        foreach(GameObject one in rcChar)
        {
            rcCharList.Add(one);
        }
    }

    public GameObject GetCharacter(string _name)
    {
        foreach(GameObject one in rcCharList)
        {
            if(one.name.Equals(_name))
            {
                return one;
            }
        }return null;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
