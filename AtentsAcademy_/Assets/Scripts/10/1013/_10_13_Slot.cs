using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
public class _10_13_Slot : MonoBehaviour
{
    public Image uiIcon;

    /*
     ��Ʈ ����ü�� �̹� �����̰� �����ֿ� ( �������� ũ��� ��Ʈ��)
     
     */

    

    public RectTransform rcTransform;
    Rect rc;
    public Rect RC
    {   //���� RC�� ����� �� ���� �����ðŴ�
        get
        {
            rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;     
            rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
            return rc;
        }
    }
    void Start()
    {
        rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;     //x,y�� �»������ �ϴ� rect ����ü
        rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
        rc.xMin = rc.x;
        rc.yMin = rc.y;
        rc.xMin = rc.x+rcTransform.rect.width;
        rc.yMin = rc.y+rcTransform.rect.height;
        rc.width = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;
    }

    public bool isInRect(Vector2 _pos)  //�Ű������� ���޵� _pos �� rc�� ���ԵǴ��� �˻�
    {   //�̰Ż���Ҷ�
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
