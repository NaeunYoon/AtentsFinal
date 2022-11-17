using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class FileCopy : MonoBehaviour
{
    string sourceDir;
    string destDir;


    void Start()
    {
        sourceDir = "C:Game/PatchInfo";
        destDir = "C:Game/DownLoad";
        StartCoroutine(CopyFileTo());
    }

    IEnumerator CopyFileTo()
    {
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }
        string[] fileName = Directory.GetFiles(sourceDir);

        //foreach(string one in fileName)
        for (int i = 0; i < fileName.Length; i++)
        {
            Debug.Log(fileName[i]);
            var file = new FileInfo(fileName[i]);
            Debug.Log(file.Name);   //파일 확장자를 포함한 파일 이름
            string destafileName = destDir + file.Name;

            yield return new WaitForSeconds(0.2f);
            //File.Move(one, destafileName);
            File.Copy(fileName[i], destafileName, true);
            yield return null;
        }
    }

    
    void Update()
    {
        
    }
}
