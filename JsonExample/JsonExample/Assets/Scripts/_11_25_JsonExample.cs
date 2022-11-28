using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using static _11_25_Mob;

public class _11_25_JsonExample : MonoBehaviour
{

    List<_11_25_Mob> list;

    void Start()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("JobInfo_1");
        JSONNode root = JSON.Parse(txtAsset.text);
        Debug.Log(root["Name"].Value);
        Debug.Log(int.Parse( root["Age"].Value));
        Debug.Log(bool.Parse( root["Man"].Value));

        JSONNode jobinfo= root["JobInfo"];
        Debug.Log(jobinfo["class"].Value);
        Debug.Log(jobinfo["Job"].Value);
        //Debug.Log(root["Name"].Value);
        //JSONNode n1 = root["Name"];

        list = new List<_11_25_Mob>();
        for (int i = 0; i < 3; i++)
        {
            _11_25_Mob tmp = new _11_25_Mob();
            tmp.INDEX = 100;
            tmp.NAME = "°¡³ª´Ù" +i.ToString();
            list.Add(tmp);
        }

        string jsonData = JsonUtility.ToJson (new Serialization<_11_25_Mob>(list));
        Debug.Log(jsonData);

        List<_11_25_Mob> mobList = JsonUtility.FromJson < Serialization<_11_25_Mob>>(jsonData).ToList();
        for (int i = 0; i < mobList.Count; i++)
        {
            Debug.Log(mobList[i].INDEX);
            Debug.Log(mobList[i].NAME);
        }




    }


    void Update()
    {
        
    }
}
