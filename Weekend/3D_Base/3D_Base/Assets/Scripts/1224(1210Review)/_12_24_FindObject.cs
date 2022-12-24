using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindObject : MonoBehaviour
{
    void Start()
    {
        //씬 상의 모든 오브젝트 중에서 특정한 이름의 오브젝트를 찾을 때
        //어쩔 수 없을 때 사용한다 (주로 사용 안하는 것 추천)
        GameObject obj = GameObject.Find("TargetObject");
        //이름이 같은 오브젝트를 찾아서 리턴해준다

        //오브젝트가 널인 경우에는 실행시키지 않는다 => 안전한코드 만들기
        obj?.SetActive(false);

        

    }

    void Update()
    {
        
    }
}
