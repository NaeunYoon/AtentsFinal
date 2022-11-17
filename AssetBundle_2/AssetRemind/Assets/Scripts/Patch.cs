//using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class Patch : MonoBehaviour
{
    double currenVersion;
    double latestVersion;
    Dictionary<double, string> patchInfo;   //double : 버전, string : 패치 내용을 확인하기 위한 것

    private IEnumerator Start() 
    {
        patchInfo = new Dictionary<double, string>();   
        //playerPrefab의 문자열을 더블형으로 바꿔서 더블 변수에 넣어줌
        currenVersion = double.Parse(PlayerPrefs.GetString("Version", "1.0"));
        
        yield return StartCoroutine(DownLoadBundle("DownLoadList.csv"));
        yield return StartCoroutine(VersionPatch());

    }

    IEnumerator VersionPatch()
    {   //현재버전과 최신버전이 같으면 break
        if(latestVersion == currenVersion)       
            yield break;
        //patchinfo에 있는 버전별 파일을 읽어서 다운로드 한다
        foreach(KeyValuePair<double,string> item in patchInfo)
        {   //
            currenVersion = item.Key;
            yield return null;
            yield return StartCoroutine(ReadVersionPatch(item.Value));
            Debug.Log(item.Key);
        }
        yield return null;
    }

    IEnumerator ReadVersionPatch(string _fileName)
    {
        //patchInfo의 파일 이름이 담긴 경로를 url에 넣어준다
        string url = $"file:///{Application.dataPath}/PatchInfo/{_fileName}";
        //파일의 내용을 읽어서 패치를 진행한다
        using (StreamReader sr = new StreamReader(_fileName))
        {
            string line = string.Empty;
            while((line = sr.ReadLine()) != null)
            {
                Debug.Log(line);
            }
            sr.Close();
        }
        yield return null;
    }


    IEnumerator DownLoadBundle(string _name)
    {   //Asset/PatchInfo에 있는 파일의의 경로를 url에 넣어준다
        string url = "file:///"+Application.dataPath+"/PatchInfo/"+_name;
        Debug.Log(url);
        //http로부터 받은 에셋번들을 다운로드 하기 위해 최적화된 UnityWebRequest를 생성하고
        //경로를 넣어준다
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        //www로부터 받은 데이터를 처리한다
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();  //연결
        Debug.Log("Send");
        if(www.result != UnityWebRequest.Result.Success)    
        {
            Debug.Log(www.error);
            Debug.Log("실패");
        }
        else//성공
        {
            Debug.Log("성공");
            //PatchDownLoad안의 파일 경로를 저장해주고
            string downLoadPath = Application.dataPath + "DownLoad" + _name;
            Debug.Log(downLoadPath);
            //받은 데이터를 바이트 배열에 저장한다
            byte[] file = www.downloadHandler.data;
            //경로에 받은 데이터를 넣고 파일을 생성한다
            File.WriteAllBytes(downLoadPath, file);
            
            using( StreamReader sr = new StreamReader(downLoadPath))
            {
                string line = string.Empty;
                //sr에 담긴 데이터가 널이 아니면
                while((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                    //sr에 있는 데이터를 , 단위로 읽어서 배열에 저장한다
                    string[] verInfo = sr.ReadLine().Split(',');
                    //버전0과 패치파일을 출력하고
                    Debug.Log($"버전 ={verInfo[0]}");
                    Debug.Log($"패치 내용 파일{verInfo[1]}");
                    //verInfo에 담긴 버전을 더블로 변환해서 latest 버전에 넣어주고
                    latestVersion = double.Parse(verInfo[0]);
                    //patchinfo에 최신버전 과 패치 파일을 넣어준다
                    patchInfo.Add(latestVersion, verInfo[1]);
                }
                sr.Close();
            }
            Resources.UnloadUnusedAssets();
        }
    }
}
