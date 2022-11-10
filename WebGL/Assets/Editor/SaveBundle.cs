using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class SaveBundle
{
    [MenuItem("AssetBundle/Save")]
    static void SaveAssetBundle()
    {
        //BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);   // 이렇게해도되고
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", 
            BuildAssetBundleOptions.None, 
            BuildTarget.StandaloneWindows64);  // 이렇게 해도됨
    }

}
