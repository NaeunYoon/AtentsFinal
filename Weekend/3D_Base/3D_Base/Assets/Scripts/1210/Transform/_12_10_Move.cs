using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class _12_10_Move : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    GameObject target;

    float speed = 10f;
    void Start()
    {
        target = GameObject.Find("Target");

        Time.timeScale = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //x,y,z 값을 변경하여 이동
        //var pos= this.transform.position;
        //pos.x += 0.05f;
        //pos.y += 0.05f;
        //pos.z += 0.05f;
        //this.transform.position = pos;

        //Vector 를 이용해서 이동 (방향과 크기를 가지고 있는 물리량)
        //transform.position += new Vector3(0.01f, 0.01f, 0);

        //길이가 1인 벡터 : 단위벡터 * 스피드 * 델타타임
        //transform.position += new Vector3(0.01f, 0.01f, 0).normalized
        //    *speed*Time.deltaTime;

        //자체가 단위벡터인 것
        //transform.position += Vector3.up *speed* Time.deltaTime;
        //transform.position += Vector3.down * speed * Time.deltaTime;
        //transform.position += Vector3.left * speed * Time.deltaTime;
        //transform.position += Vector3.right * speed * Time.deltaTime;
        //transform.position += Vector3.forward * speed * Time.deltaTime;

        //제공되는 함수를 사용하기
        //transform.Translate(Vector3.up);
        //transform.Translate(new Vector3(0, 1, 0));
        //transform.Translate(new Vector3(0.01f, 0.01f, 0).normalized* speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        //다른 오브젝트 방향으로 이동시키기

        Vector3 direct = target.transform.position - this.transform.position;
        //이렇게 하면 두 쪽 방향 벡터가 만들어짐
        //그러나 우리는 방향만 필요함
        transform.position += direct.normalized * speed * Time.deltaTime;
        

    }


}
