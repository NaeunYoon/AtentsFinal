using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindTags : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Scene상에 Monster 라는 태그를 가진 오브젝트들을 찾아서 파괴 
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var item in objs)
        {
            Destroy(item.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
