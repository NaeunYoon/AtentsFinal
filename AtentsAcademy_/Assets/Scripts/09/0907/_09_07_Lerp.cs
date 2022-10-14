using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_07_Lerp : MonoBehaviour
{
    /*
     
    선형보간 : 중간값을 연산하는 것 (직선 운동하는 게임 오브젝트가 일정한 시간이 진행됨에 따라서 b와 a (x좌표)값이 존재하는데, t초동안 진행
    t가 0이 되면 결과는 a, 시간이 0일 때 x 좌표는a에 있다
    t가 증가하면 최댓값이 1임
    t가 0.1이면 b는 0.1, a는 0.9
    b쪽으로 0.1만큼 나가고 a의 입장에서는 0.1이 줄어드는 것

    t : 시간 // 시간이 진행됨에 따라서 b와a값이 존재하는데,
    a : 출발지 b : 도착지

    결과 = bt + (1-t)a  // (1-t)a + bt
    시간이0일 때 x의 좌표는 a 에 있음
    t가 증가하게 되면, 최저값이 1
    중간값을 연산하는 것
     
     
     */

    // animate the game object from -1 to +1 and back
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    void Update()
    {
        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;                                 //t가 증가하면 a의 값은 점점 줄어든다

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
