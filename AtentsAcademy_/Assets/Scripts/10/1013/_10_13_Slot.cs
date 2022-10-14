using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
public class _10_13_Slot : MonoBehaviour
{
    public Image uiIcon;

    /*
     렉트 구조체는 이미 유아이가 갖고있움 ( 유아이의 크기는 렉트가)
     
     */

    

    public RectTransform rcTransform;
    Rect rc;
    public Rect RC
    {   //내가 RC를 사용할 때 값을 가져올거다
        get
        {
            rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;     
            rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
            return rc;
        }
    }
    void Start()
    {
        rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;     //x,y를 좌상단으로 하는 rect 구조체
        rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
        rc.xMin = rc.x;
        rc.yMin = rc.y;
        rc.xMin = rc.x+rcTransform.rect.width;
        rc.yMin = rc.y+rcTransform.rect.height;
        rc.width = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;
    }

    public bool isInRect(Vector2 _pos)  //매개변수로 전달된 _pos 가 rc에 포함되는지 검사
    {   //이거사용할때
        if(_pos.x >= RC.x && 
            _pos.x <= RC.x + RC.width && 
            _pos.y >= RC.y - RC.height && 
            _pos.y <= RC.y)
            return true;
        return false;
    }

    void Update()
    {
        
    }
}
