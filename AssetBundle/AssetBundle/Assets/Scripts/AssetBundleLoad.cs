using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleLoad : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(LoadBundle());   // ���1 - file�������� �̿�
        StartCoroutine(DownLoadBundle("cube_1"));   // ���2 ���������� ��ġ �޴� ���� ����
    }

    // 1. ���¹��� �ε��ϴ� ��� - file�̿��� �ε�
    IEnumerator LoadBundle()
    {
        string url = "file:///" + Application.dataPath + "/AssetBundles/" + "cube_1.bundle";   // 1. ���� ����� �����͵��� �ִ���ġ.
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);   //2. UnityWebRequest www�� ���¹����� ��θ� �־��ش�
        yield return www.SendWebRequest();  //3. ���� ������ ����� �Ѵ�!
        // ���� �Ʒ� ���ʹ� www.SendWebRequest�Ϸ�� ����
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);//4.���¹����� �����°�. ����? �޸𸮻����� �����Դ�.
        

        var prefab = bundle.LoadAsset<GameObject>("Cube");  //5. ������ ������ �ε��Ѵ�
        //var prefab = bundle.LoadAllAssets<GameObject>();

        GameObject go = GameObject.Instantiate(prefab); //7. ���信 �÷����´�
        go.transform.position = Vector3.zero;   //8. ��ġ�� �������ش�

        bundle.Unload(false);    // 9. �ش� ���¹����� �����͸� free�� ����
        Resources.UnloadUnusedAssets();    // 10. ������� �ʴ� ������ �޸� ��ȯ
    }

    // 2. ����Ʈ�� ���� ����
    // �������� �ִ� ������ �������� ��. �������� ������ �ٽ� �ε��ؼ� �ҷ���
    IEnumerator DownLoadBundle(string _name)
    {
        // ���� : �ƴ�.. �������� �ִ� ������ �����޴°Ŷ�� �ϴµ�, �� ���⼭�� file:///�̵��� ������?
        // �츮�� �������� �ȹ�����. => ��������� �׳� �����սô�. �ƽð��� ������? �̷��� ����.
        string url = "file:///" + Application.dataPath + "/AssetBundles/" + _name + ".bundle";
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        www.downloadHandler = new DownloadHandlerBuffer();  // �̰ſ־�? -> .data�� �����ؼ� ���� �������� ���ؼ���.
        yield return www.SendWebRequest();  // ����

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);  // ���� �ޱ� ����
        }
        else
        {
            string fullPath = Application.dataPath + "/DownLoadBundle/" + _name + ".bundle";   //
            byte[] file = www.downloadHandler.data; // �̷� �������� ������δ� ������ �ȵȴٰ� ������
            File.WriteAllBytes(fullPath, file);   // ���� ������ ����� ����.

            var myLoadAssetbundle = AssetBundle.LoadFromFile(fullPath);  // ������ ����Ʈ�迭�� ���¹��� ���·� load

            GameObject[] prefabs = myLoadAssetbundle.LoadAllAssets<GameObject>();   //���¹����� �ε����ش�
            foreach (GameObject item in prefabs)    //���ʷ� ���� �÷��ش�
            {
                GameObject obj = Instantiate<GameObject>(item);
                obj.transform.position = Vector3.zero;
                obj.name = item.name;
            }

            myLoadAssetbundle.Unload(false);    // ������ free�� ����
            Resources.UnloadUnusedAssets();    // ������� �ʴ� ������ �޸� ��ȯ
        }
    }
}
