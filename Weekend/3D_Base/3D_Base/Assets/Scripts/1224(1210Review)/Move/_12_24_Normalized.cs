using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class _12_24_Normalized : MonoBehaviour
{

    private float speed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        //단위벡터 : 길이가 1인 벡터 (방향값만 있음)
        //
        //transform.position += new Vector3(1.0f, 1.0f, 0.0f).normalized * speed * Time.deltaTime;
        //방향만 가지고 있고 크기는 1인 벡터이다. 스피드 값을 따로 주고 델타를 주면
        //1초에 10만큼 이동하게 할 수 있다

        //기본적으로 제공해주는 벡터 타입 (이 것 자체가 단위벡터임)
        transform.position += Vector3.up * speed * Time.deltaTime;
        //transform.position += Vector3.left * speed * Time.deltaTime;
        //transform.position += Vector3.right * speed * Time.deltaTime;
        //transform.position += Vector3.one * speed * Time.deltaTime;
        //transform.position += Vector3.down * speed * Time.deltaTime;
        //transform.position += Vector3.forward * speed * Time.deltaTime;



    }
}
