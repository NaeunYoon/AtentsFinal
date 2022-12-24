using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_TargetObjectMove : MonoBehaviour
{
    /*
     A에서 B로 향하고 싶다면 B로 향하는 벡터를 만들면 된다
     B에서A로 빼면 된다. 그 벡터 방향으로 움직이게 하면 된다.
     */

    //방법1
    //Find 명령어로 찾는다
    GameObject targetObject;

    //방법2
    //연결해서 찾는다
    [SerializeField] private GameObject _TargetObject;


    void Start()
    {
        //방법1 find를 쓰는 것은 동적으로 만든 오브젝트를
        targetObject = GameObject.Find("TargetObject");


    }

    void Update()
    {
        //TargetObject 방향으로 이동시키기(1)
        //Vector3 direct = targetObject.transform.position - this.transform.position;
       // transform.position += direct.normalized * 10f * Time.deltaTime;

        //TargetObject 방향으로 이동시키기(2)
        Vector3 direct = _TargetObject.transform.position - this.transform.position;
        transform.position += direct.normalized * 10f * Time.deltaTime;
    }
}
