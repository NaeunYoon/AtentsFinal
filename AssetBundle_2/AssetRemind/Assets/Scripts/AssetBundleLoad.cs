using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using UnityEngine.Networking;

public class AssetBundleLoad : MonoBehaviour
{ 
    void Start()
    {
        StartCoroutine(DownLoadBundle("cube_1"));
    }

    //IEnumerator LoadBundle()
    //{
    //    string url = "file:///" + Application.dataPath + "/AssetBundle/" + "cube_1.bundle";
    //    UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
    //    yield return www.SendWebRequest();

    //    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

    //    var prepabs = bundle.LoadAsset<GameObject>("cube");

    //    GameObject go = GameObject.Instantiate(prepabs);
    //    go.transform.position = Vector3.zero;

    //    bundle.UnloadAsync(false);
    //    Resources.UnloadUnusedAssets();
    //}
    
    IEnumerator DownLoadBundle(string _name)
    {
        //���¹����� �ִ� ��θ� �����ͼ� url�� �־��ش�
        string url = "file:///" + Application.dataPath + "/AssetBundle/" + _name + ".bundle";
        //UnityWebRequest : �� �������� HTTP ��� �帧�� ó�� (�������� ������ ����Ҷ�)
        //��θ� �����ͼ�..�������� ��� �帧�� ó���ϴ� 
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();
        //�������� �޾ƿ� ���� ������ ���� ����ҿ� �����Ϸ��� �޾ƿ� �����͸� ���� ������� �ؾ��ߴµ�,
        //�׷��� ���ؼ��� �켱 �޾ƿ� ���� ������ ������, byte[] data�� ã�Ƴ��� �ű⿡ �������� �� �־�� �ߴ�.
        //�׷��� ù ��°�� �õ��� ����� ���� �������� UnitWebRequest.GetAssetBundle()�� �޾ƿ�
        //UnityWebRequest request���� request.downloadHandler.data�� ���ؼ� �����ϴ� ���̾���.

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string fullPath = Application.dataPath + "/DownLoadBundle/" + _name + ".bundle";
            byte[] file = www.downloadHandler.data;
            File.WriteAllBytes(fullPath, file);
            var bundle = AssetBundle.LoadFromFile(fullPath);

            GameObject[] prepabs = bundle.LoadAllAssets<GameObject>();
            foreach(GameObject item in prepabs)
            {
                GameObject obj = Instantiate<GameObject>(item);
                obj.transform.position = Vector3.zero;
                obj.name = item.name;
            }
            bundle.Unload(false);
            // -False : ���鳻���� ������ �������� �����ʹ� ��ε� ������,
            // �� ����κ��� �̹� �ε�� ���� ��ü���� �״�� �д�.
            // ���� �� ����κ��� �߰������� �ҷ��� �� ����.
            //- True : ����κ��� �ε�� ��� ��ü���� ���� ���ŵȴ�.
            //���� �� ���� �� ���µ��� �����ϴ� ��ü�� �ش� ������ �����ȴ�.
            Resources.UnloadUnusedAssets();
            //Resources.UnloadUnusedAssets(); �Լ��� ȣ�� �Ǿ��� ��
            //Reference Count�� 0�� ������Ʈ�� �޸𸮿��� ���� ��Ű�� �˴ϴ�.(������ ����)
        }


    }
}
