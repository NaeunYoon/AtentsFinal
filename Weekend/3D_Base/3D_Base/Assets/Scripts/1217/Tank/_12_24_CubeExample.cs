using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class _12_24_CubeExample : MonoBehaviour
{
    private Vector3 _pos;

    void Start()
    {
        
    }

    public void SetPosition(Vector3 pos)
    {
        _pos = pos;
    }
    void Update()
    {
        //스크린을 찍었을 때 스크린의 위치값에서 큐브의 위치를 뺴서 방향벡터를 구한다. (벡터의 크기는 필요가 없다)
        //방향을 향해서 가기만 하면 되기 때문에 방향값만 필요함
        //벡터는 방향과 크기를 가진 물리량인데, 크기는 필요 없기 때문에 크기를 normalized 해서 1로 만들어준다
        //벡터의 길이를 1로 만든 벡터를 단위벡터 라고 한다 ( 보통 방향만 필요할 때 사용한다)

        Vector3 direction = _pos - transform.position; //방향벡터를 만들었다
        //방향만 있으면 되니까 정규화를 해준다 (크기를 가지고 있는 상태)
        //normalized 함으로써 크기가 1인 벡터를 돌려준다
        //transform.position += direction.normalized *2f * Time.deltaTime;
        transform.position += new Vector3( direction.x,0f,direction.z).normalized * 2f * Time.deltaTime;
        //
    }
}
