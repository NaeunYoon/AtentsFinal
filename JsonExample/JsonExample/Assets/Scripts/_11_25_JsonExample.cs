using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class _11_25_JsonExample : MonoBehaviour
{
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
