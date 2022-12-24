using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Vector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vectoe를 이용해서 이동
        //Vector 는 방향과 크기를 갖는 물리량 (북쪽으로 5미터)   
        //transform.position += new Vector3(0.01f, 0.01f, 0.0f);
        //x축으로 0.01, y축으로 0.01 이동

        transform.position += new Vector3(1.0f, 1.0f, 0.0f) * Time.deltaTime;
        //델타타임 : 업데이트가 호출되고, 다음 업데이트가 호출 될 때 까지 걸리는 시간
        //빠른 시스템에서는 델타타임이 빠르고 느린 시스템에서는 델타타임이 길다
        //우리가 원하는건 어느 시스템에서나 1초에 이동하는 시간이 일정하길 원하기 때문에 
        //누계되는 델타타입에 델타타입을 곱해서 일정하게 움직이게 만들어준다

        //타입 객체 안의 타임들
        Time.fixedDeltaTime = 0.5f; //0.02초마다 호출
        Time.timeScale = 0.5f;  //슬로우모션 처리할 때 (1이 정상임)
                                //빠른 모션 처리할 때 (2로 설정)
                                //전체적인 업데이트 시간 조절

    }
}
