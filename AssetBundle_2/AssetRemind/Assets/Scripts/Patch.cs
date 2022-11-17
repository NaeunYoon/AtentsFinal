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
    Dictionary<double, string> patchInfo;   //double : ����, string : ��ġ ������ Ȯ���ϱ� ���� ��

    private IEnumerator Start() 
    {
        patchInfo = new Dictionary<double, string>();   
        //playerPrefab�� ���ڿ��� ���������� �ٲ㼭 ���� ������ �־���
        currenVersion = double.Parse(PlayerPrefs.GetString("Version", "1.0"));
        
        yield return StartCoroutine(DownLoadBundle("DownLoadList.csv"));
        yield return StartCoroutine(VersionPatch());

    }

    IEnumerator VersionPatch()
    {   //��������� �ֽŹ����� ������ break
        if(latestVersion == currenVersion)       
            yield break;
        //patchinfo�� �ִ� ������ ������ �о �ٿ�ε� �Ѵ�
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
        //patchInfo�� ���� �̸��� ��� ��θ� url�� �־��ش�
        string url = $"file:///{Application.dataPath}/PatchInfo/{_fileName}";
        //������ ������ �о ��ġ�� �����Ѵ�
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
    {   //Asset/PatchInfo�� �ִ� �������� ��θ� url�� �־��ش�
        string url = "file:///"+Application.dataPath+"/PatchInfo/"+_name;
        Debug.Log(url);
        //http�κ��� ���� ���¹����� �ٿ�ε� �ϱ� ���� ����ȭ�� UnityWebRequest�� �����ϰ�
        //��θ� �־��ش�
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        //www�κ��� ���� �����͸� ó���Ѵ�
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();  //����
        Debug.Log("Send");
        if(www.result != UnityWebRequest.Result.Success)    
        {
            Debug.Log(www.error);
            Debug.Log("����");
        }
        else//����
        {
            Debug.Log("����");
            //PatchDownLoad���� ���� ��θ� �������ְ�
            string downLoadPath = Application.dataPath + "DownLoad" + _name;
            Debug.Log(downLoadPath);
            //���� �����͸� ����Ʈ �迭�� �����Ѵ�
            byte[] file = www.downloadHandler.data;
            //��ο� ���� �����͸� �ְ� ������ �����Ѵ�
            File.WriteAllBytes(downLoadPath, file);
            
            using( StreamReader sr = new StreamReader(downLoadPath))
            {
                string line = string.Empty;
                //sr�� ��� �����Ͱ� ���� �ƴϸ�
                while((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                    //sr�� �ִ� �����͸� , ������ �о �迭�� �����Ѵ�
                    string[] verInfo = sr.ReadLine().Split(',');
                    //����0�� ��ġ������ ����ϰ�
                    Debug.Log($"���� ={verInfo[0]}");
                    Debug.Log($"��ġ ���� ����{verInfo[1]}");
                    //verInfo�� ��� ������ ����� ��ȯ�ؼ� latest ������ �־��ְ�
                    latestVersion = double.Parse(verInfo[0]);
                    //patchinfo�� �ֽŹ��� �� ��ġ ������ �־��ش�
                    patchInfo.Add(latestVersion, verInfo[1]);
                }
                sr.Close();
            }
            Resources.UnloadUnusedAssets();
        }
    }
}
