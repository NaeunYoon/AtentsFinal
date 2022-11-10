using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class SaveBundle
{
    [MenuItem("AssetBundle/Save")]
    static void SaveAssetBundle()
    {
        //BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);   // �̷����ص��ǰ�
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", 
            BuildAssetBundleOptions.None, 
            BuildTarget.StandaloneWindows64);  // �̷��� �ص���
    }

}
