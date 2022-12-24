using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class _12_24_Translate : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate 함수를 사용
        //transform.Translate(new Vector3(0.01f, 0.01f, 0.01f));
        //transform.Translate(new Vector3(0.01f, 0.01f, 0.01f).normalized * 10f * Time.deltaTime);
        //transform.Translate(Vector3.forward*10f*Time.deltaTime);    //월드축임(월드축의 forward)
        //transform.Translate(Vector3.forward * 10f * Time.deltaTime,Space.World);//월드축 이동
        //transform.Translate(Vector3.forward * 10f * Time.deltaTime, Space.Self); //로컬축
        transform.position += transform.forward * 10f * Time.deltaTime;     //로컬좌표축으로 이동
    }
}
