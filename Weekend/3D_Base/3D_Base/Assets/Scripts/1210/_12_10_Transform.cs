using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_Transform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 계층 구조상에서 자식오브젝트에 이름으로 찾을 때.
        Transform tr = transform.Find("Cube (3)");
        tr.gameObject.SetActive(false);

        //계층구조상에서 자식오브젝트의 순서로 찾는 경우
        Transform tr2 = transform.GetChild(0);
        tr2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
