using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
   


 
 */
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
