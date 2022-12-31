using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_UI_Basic : MonoBehaviour
{
    /*
     
     ui는 앵커를 기준으로 잡는다.
     화면 사이즈가 매번 달라질 때마다 ui의 위치가 달라지면 안되기 때문에
     기준점을 앵커로 잡아야 한다 (화면을 기준으로 ~ 만큼 떨어진 곳에 위치함)
     alt를 누르면 프리셋이 된다. 화면에 딱 달라붙음
     렉트 트렌스폼 : 앵커를 기준으로 하는 상대좌표이다
    ui에서 사용하는 함수는 퍼블릭이여야 한다

     */

    public void OnClickButton()
    {
        Debug.Log("버튼클릭");
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
