using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Rotation : MonoBehaviour
{

    /*회전시킨다는 것은 로테이션의 x,y,z 값을 변경하는 것이다
      회전을 하려면, 
     
     */

    private float yrot = 0f;
    private float xrot = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        /*
         오일러 각축방식 : 각각의 축을 따로 회전한다 (따로따로 시킨다) 이럴 경우 짐벌락 현상이 발생한다
        => 축이 하나가 없어져버리는 현상이 발생한다.
        => 짐벌락 현상을 방지하기 위해 쿼터니언 (사원수) 를 사용한다
        => x,y,z 를 한꺼번에 회전을 시킨다 
        
         */

        //한 번 바뀜
        //this.transform.rotation = Quaternion.Euler(30f, 60f, 30f);

        //오일러각을 입력받아 쿼터니언으로 바꿔주고 로테이션에 저장해준다


        //계속 회전하고 싶다면?
        yrot += 30f * Time.deltaTime;
        xrot += 20f * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(xrot, yrot, 0f);
    }
}
