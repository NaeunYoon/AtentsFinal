using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

delegate void DoFunc();

public class _10_11_Touch : MonoBehaviour, IPointerDownHandler
{
    public Text uiText;
    private Color sourceColor;
    private Color targetColor;
    public float elapsed;
    private float tmpElapsed;
    DoFunc blinkDo;
    void Start()
    {
        sourceColor = uiText.color;
        targetColor = uiText.color;
        targetColor.a = 0f;
        tmpElapsed = elapsed;
        Invoke("OffColor", 0.4f);
        blinkDo = OnColorWithMe;
    }

    public void OnColor()
    {
        uiText.color = sourceColor;
        if (IsInvoking("OnColor"))
        {
            CancelInvoke("OnColor");
        }
        Invoke("OffColor", 0.4f);

    }
    public void OffColor()
    {
        uiText.color = targetColor;
        if (IsInvoking("OffColor"))
        {
            CancelInvoke("OffColor");
        }
        Invoke("OnColor", 0.4f);
    }

    void OnColorWithMe()
    {
        uiText.color = targetColor;
        tmpElapsed -= Time.deltaTime;
        if (tmpElapsed <= 0)
        {
            blinkDo = OffColorWithMe;
            tmpElapsed = elapsed;
        }
    }

    void OffColorWithMe()
    {
        uiText.color = targetColor;
        tmpElapsed -= Time.deltaTime;
        if (tmpElapsed <= 0)
        {
            blinkDo = OnColorWithMe;
            tmpElapsed = elapsed;
        }
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        Debug.Log("PointerDown À§Ä¡ " + _eventData.position);
    }
    void Update()
    {
        //tmpElapsed -= Time.deltaTime;
        //if(tmpElapsed <= 0)
        //{
        //    uiText.color = sourceColor;
        //    tmpElapsed =elapsed;
        //}
        //else
        //{
        //    uiText.color = targetColor;
        //}
    }
}
