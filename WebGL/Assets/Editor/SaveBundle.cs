using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
   


 
 */
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
