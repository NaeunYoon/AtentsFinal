using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.EventSystems;

public class _1017_Slot : MonoBehaviour
{
    public Image _icon;
    public int itemCount;
    private Text text_count;
    private _1017_Inventory inventory;
    public RectTransform rcTransform;
    Rect rc;
    public Rect RC
    {
        get
        {
            rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
            rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
            return rc;
        }
    }

    void Start()
    {
        //inventory = new _1017_Inventory();

        rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
        rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
        rc.xMin = rc.x;
        rc.yMin = rc.y;
        rc.xMin = rc.x + rcTransform.rect.width;
        rc.yMin = rc.y + rcTransform.rect.height;
        rc.width = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;
    }
    public bool isInRect(Vector2 _pos)  
    {
        if (_pos.x >= RC.x &&
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
