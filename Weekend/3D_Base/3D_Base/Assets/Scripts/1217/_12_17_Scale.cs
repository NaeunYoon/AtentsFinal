using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class _12_17_Scale : MonoBehaviour
{
    void Start()
    {
        this.transform.localScale = new Vector3(2f, 2f, 2f);
        Debug.Log("localScale "+this.transform.localScale);     //상대적인 스케일 값
        Debug.Log("lossyScale " + this.transform.lossyScale);   //절대적인 스케일 값

        /*
         부모큐브를 333으로 하면 자식 큐브가 111이어도 333으로 상대적인 큐브의 스케일이 된다
         상대적으로 보면 2배(222)가 늘어났지만 절대적으로 보면 6배(666)가 늘어났다
         
        기본적으로 이동 회전 스케일을 조합해서 변화를 줄 수 있다
         */

        Debug.Log("localPosition " + this.transform.localPosition); //상대적인 위치값 (부모로부터 ~ 만큼 떨어져있다)
        Debug.Log("Position " + this.transform.position);   //절대적인 위치값 ( 씬 중앙으로부터 ~만큼 떨어져있다)


    }

    void Update()
    {
        
    }
}
