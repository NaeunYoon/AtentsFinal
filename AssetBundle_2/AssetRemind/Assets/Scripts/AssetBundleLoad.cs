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
        //에셋번들이 있는 경로를 가져와서 url에 넣어준다
        string url = "file:///" + Application.dataPath + "/AssetBundle/" + _name + ".bundle";
        //UnityWebRequest : 웹 서버와의 HTTP 통신 흐름을 처리 (웹서버랑 데이터 통신할때)
        //경로를 가져와서..웹서버늬 통신 흐름을 처리하는 
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();
        //서버에서 받아온 에셋 번들을 로컬 저장소에 저장하려면 받아온 데이터를 파일 입출력을 해야했는데,
        //그러기 위해서는 우선 받아온 에셋 번들의 데이터, byte[] data를 찾아내고 거기에 엑세스할 수 있어야 했다.
        //그래서 첫 번째로 시도한 방법이 위의 예제에서 UnitWebRequest.GetAssetBundle()로 받아온
        //UnityWebRequest request에서 request.downloadHandler.data를 통해서 접근하는 것이었다.

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
            // -False : 번들내에서 에셋의 압축파일 데이터는 언로드 되지만,
            // 이 번들로부터 이미 로드된 실제 객체들은 그대로 둔다.
            // 또한 이 번들로부터 추가적으로 불러올 수 없다.
            //- True : 번들로부터 로드된 모든 객체들이 같이 제거된다.
            //만약 씬 내에 이 에셋들을 참조하는 객체는 해당 참조가 누락된다.
            Resources.UnloadUnusedAssets();
            //Resources.UnloadUnusedAssets(); 함수가 호출 되었을 때
            //Reference Count가 0인 오브젝트를 메모리에서 해제 시키게 됩니다.(참조가 없는)
        }


    }
}
