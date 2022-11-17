using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

public class BundleSave
{
    [MenuItem("AssetBundle/Save")]

    static void SavaAssetBundle()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundle", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }

}
