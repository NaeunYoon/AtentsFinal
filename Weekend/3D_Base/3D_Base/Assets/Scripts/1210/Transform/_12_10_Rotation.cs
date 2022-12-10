using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_Rotation : MonoBehaviour
{
    private float x_rotation = 50f;
    private float y_rotation = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //축을 따로따로 호ㅣ전시키면 짐벌락 이라는 현상이 발생한다
        //따라서 쿼터니언을 사용해서 xyz를 한꺼번에 회전시킨다
        //
        //한번 회전
        //this.transform.rotation = Quaternion.Euler(30f, 60f, 30f);

        //계속 회전
        x_rotation += 10.0f * Time.deltaTime;
        y_rotation += 10.0f * Time.deltaTime;
        //this.transform.rotation = Quaternion.Euler(x_rotation, 60f, 30f);
        //this.transform.rotation = Quaternion.Euler(30f, y_rotation, 30f);
        this.transform.rotation = Quaternion.Euler(x_rotation, y_rotation, 30f);
    }
}
