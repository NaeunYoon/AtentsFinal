using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindGameObjectsWithTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //여러개의 태깅된 오브젝트들을 한꺼번에 액션을 취하게 할 때
        //씬상의 태그를 가지고 있는 모든 오브젝트를 찾아서 오브젝트 배열로 리턴합니다
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var item in objs)
        {
            item.gameObject.SetActive(false);
            //Destroy(item.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
