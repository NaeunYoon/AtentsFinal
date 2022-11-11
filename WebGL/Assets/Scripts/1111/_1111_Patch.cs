//using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using Newtonsoft.Json.Schema;

/* 
 에셋번들을 이용해서 패치를 제작하고자 한다
 패치를 제작하고자 한다면 버전정보
 버전정보는 어떻게 알아야 할까요?
  
1) 현재 자신의 버전과 최신버전을 비교해야 한다
   최신버전을 알아오는 방법은 시작 시 웹서버 또는 서버를 통하여 최신 버전정보를 내려받는다.
2) 버전에 해당되는 파일을 다운로드 한다
   버전에 해당되는 파일을 어떻게 알 수 있을까요
   -서버의 버전 폴더를 관리
   -최신버전 폴더만 관리 하는 방법

상황 : 패치정보 경로 Assets/PatchInfo
       게임실행 시 패치정보의 문서를 다운로드
       참고로 버전은 1.0부터 시작했으며, 현재 서비스 버전은 1.2 이다.
       1.0 -> 1.1 -> 1.2
       패치정보의 파일이름 : GamePatchInfo.txt
       파일내용 : 1.0 패치경로 D: GamePatch_1_0.csv 
                                    패치파일 이름 : GamePatch_1_0.assetbundle
                                                    Cube_1.assetbundle (Cube_1.prepab)
                                                    Cube_2.assetbundle (Cube_2.prepab)
                  1.1 패치경로 D: GamePatch_1_1.csv
                                    
                  1.2 패치경로 D: GamePatch_1_2.csv 

1. 게임실행 시 패치정보의 문서를 다운로드
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

            //패치받아야 할 버전별 파일을 하나씩 읽어 파일을 다운로드
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
                //패치받아야 할 에셋 번들 내용
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
                    Debug.Log("버전"+verInfo[0]);
                    Debug.Log("패치내용" + verInfo[1]);
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
