using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindWithTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //타겟이라는 태그가 달려있는 오브젝트
        //맨 처음에 찾은 것을 리턴한다.
        //두개를 설정해도, 첫번째로 찾은 것만 리턴해준다.
        GameObject obj = GameObject.FindWithTag("Target");
        obj.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
