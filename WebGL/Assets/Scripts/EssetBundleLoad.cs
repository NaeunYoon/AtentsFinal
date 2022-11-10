//using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
//using UnityEngine.Windows;

public class EssetBundleLoad : MonoBehaviour
{
    private IEnumerator Start()
    {
        // 1. 에셋번들 로드하는 방법 - file이용한 로드
        string url = "file:///" + Application.dataPath + "/AssetBundles/" + "cube_1.assetbundle";
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return www.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
        var prefab = bundle.LoadAsset<GameObject>("Cube_1");

        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = Vector3.zero;
    }

    IEnumerator DownLoadBundle(string _name)
    {
        string url = "file:///" + Application.dataPath + "/AssetBundles/" + _name;
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return www.SendWebRequest();
    }

    IEnumerator DownLoadBundle2(string _name)
    {
        string url = "file:///" + Application.dataPath + "/AssetBundles/" + _name+".assetbundle";
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return www.SendWebRequest();

        if (www.isDone)
        {
            string fullPath = Application.dataPath + "/AssetBundles/" + _name + ".assetbundle";


            File.WriteAllBytes(fullPath,www.downloadHandler.data);
            var myLoadAssetBundle = AssetBundle.LoadFromFile(Application.dataPath+"/"+_name);
            myLoadAssetBundle.LoadAsset<GameObject>("");

        }

    }


    void Update()
    {
        
    }
}
