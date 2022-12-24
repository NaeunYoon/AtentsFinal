using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_GetChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //계층구조상에서 자식오브젝트의 순서로 찾는 경우
        Transform tr = transform.GetChild(2);
        tr.gameObject.SetActive(false);
        //0번째자식 1번째자식 2번째자식 순서로 간다. 따라서 세번쨰 자식임.
        //부모 컴포넌트에 붙어 있어야 한다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
