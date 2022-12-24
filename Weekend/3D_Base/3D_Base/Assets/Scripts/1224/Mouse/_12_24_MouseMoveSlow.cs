using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_MouseMoveSlow : MonoBehaviour
{

    Vector3 pos;

    /*
     벡터는 방향과 크기를 가지고 있으나 나는 크기는 필요가 없음
     그래서 벡터의 크기를 1로 만들어버린다
     
     */

    void Start()
    {
        
    }

    public void SetPosition(Vector3 _pos)
    {
        pos = _pos;
    }

    void Update()
    {
        Vector3 direction = pos - transform.position;     //방향벡터
        //transform.position += direction.normalized * 2.0f * Time.deltaTime;

        transform.position += new Vector3(direction.x, 0f, direction.z).normalized * 2.0f * Time.deltaTime;

    }
}
