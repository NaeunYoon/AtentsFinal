using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_14_ScrollView : MonoBehaviour
{
    /*
     스크롤뷰의 역할을 하는 컴포넌트 : ScrollRect ;쩝ㄷ 기억력 좋으시네;

     몬스터의 위치를 변경하려면 이미지의 rectTransform을 변경해줌
     
     
     */

    public ScrollRect scrollRect;

    void Start()
    {
        scrollRect.normalizedPosition = new Vector2(1,1); //이걸 왜구하는건데...
    }

    
    void Update()
    {
       //Vector2 tmp = scrollRect.normalizedPosition;  //scrollRect.normalizedPosition을 통해서 스크롤의 위치를 계산할 수 있다..
       // tmp.x += Time.deltaTime*0.1f;
       // scrollRect.normalizedPosition = tmp;
    }
}
