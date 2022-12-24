using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _12_24_GetComponentInChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //계층구조상의 자식 오브젝트의 컴포넌트를 가져올 때
        _12_24_Slime slime = this.gameObject.GetComponentInChildren<_12_24_Slime>();
        slime.Attack();
        //맨 처음에 찾은 거 하나 리턴

        _12_24_Slime [] slimes = this.gameObject.GetComponentsInChildren<_12_24_Slime>();
        foreach (var item in slimes)
        {
            item.Attack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
