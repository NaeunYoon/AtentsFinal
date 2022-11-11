//using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using Newtonsoft.Json.Schema;

/* 
 ���¹����� �̿��ؼ� ��ġ�� �����ϰ��� �Ѵ�
 ��ġ�� �����ϰ��� �Ѵٸ� ��������
 ���������� ��� �˾ƾ� �ұ��?
  
1) ���� �ڽ��� ������ �ֽŹ����� ���ؾ� �Ѵ�
   �ֽŹ����� �˾ƿ��� ����� ���� �� ������ �Ǵ� ������ ���Ͽ� �ֽ� ���������� �����޴´�.
2) ������ �ش�Ǵ� ������ �ٿ�ε� �Ѵ�
   ������ �ش�Ǵ� ������ ��� �� �� �������
   -������ ���� ������ ����
   -�ֽŹ��� ������ ���� �ϴ� ���

��Ȳ : ��ġ���� ��� Assets/PatchInfo
       ���ӽ��� �� ��ġ������ ������ �ٿ�ε�
       ����� ������ 1.0���� ����������, ���� ���� ������ 1.2 �̴�.
       1.0 -> 1.1 -> 1.2
       ��ġ������ �����̸� : GamePatchInfo.txt
       ���ϳ��� : 1.0 ��ġ��� D: GamePatch_1_0.csv 
                                    ��ġ���� �̸� : GamePatch_1_0.assetbundle
                                                    Cube_1.assetbundle (Cube_1.prepab)
                                                    Cube_2.assetbundle (Cube_2.prepab)
                  1.1 ��ġ��� D: GamePatch_1_1.csv
                                    
                  1.2 ��ġ��� D: GamePatch_1_2.csv 

1. ���ӽ��� �� ��ġ������ ������ �ٿ�ε�
2. 
 */
public class _1111_Patch : MonoBehaviour
{
    double currentVersion;
    double latestVersion;
    Dictionary<double, string> patchInfo;

    IEnumerator Start()
    {
        patchInfo = new Dictionary<double, string>();
        currentVersion = double.Parse(PlayerPrefs.GetString("Version", "1.0"));
        yield return StartCoroutine(DownLoadBundle("GamePatchInfo.csv"));
        yield return StartCoroutine((VersionPatch()));
    }

    IEnumerator VersionPatch()
    {
        if(latestVersion == currentVersion)
        
            yield break;    

            //��ġ�޾ƾ� �� ������ ������ �ϳ��� �о� ������ �ٿ�ε�
            foreach(KeyValuePair<double, string> one in patchInfo)
            {
                currentVersion = one.Key;
                ReadVersionPatch(one.Value);
                Debug.Log(one.Key);
                
            }
            yield return null;  
    }

    void ReadVersionPatch (string _filename)
    {
        using (StreamReader sr = new StreamReader(_filename))
        {
            string line = string.Empty;
            while((line = sr.ReadLine()) != null)
            {
                //��ġ�޾ƾ� �� ���� ���� ����
            }
        }
    }


    IEnumerator DownLoadBundle(string _name)
    {
        string url = "file:///" + Application.dataPath + "/PatchInfo/" + _name;
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string downloadPath = Application.dataPath + "/DownLoadBundle/"+_name;
            byte[] data = www.downloadHandler.data;
            File.WriteAllBytes(downloadPath, data);

            using (StreamReader sr = new StreamReader(downloadPath))
            {
                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                    string[] verInfo = line.Split(".");
                    Debug.Log("����"+verInfo[0]);
                    Debug.Log("��ġ����" + verInfo[1]);
                    latestVersion = double.Parse(verInfo[0]);
                    patchInfo[latestVersion] = verInfo[1];
                }
                sr.Close(); 
            }

            //var myLoadAssetBundle = AssetBundle.LoadFromFile(Application.dataPath + "/PatchDownLoad/"+_name);
            //GameObject[] prefabs = myLoadAssetBundle.LoadAllAssets<GameObject>();


        }

    }


    void Update()
    {
        
    }
}
