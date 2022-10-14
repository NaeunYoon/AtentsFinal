using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_11_UI_Manager : MonoBehaviour
{
    public Button uiButton;
    public Animator ani;
    void Start()
    {
        uiButton.onClick.AddListener(OKButtonClickA);
        //uiButton.onClick.RemoveListener(OKButtonClickB);

        //ui¿« ≈©±‚
        Vector2 size1 = uiButton.gameObject.GetComponent<RectTransform>().sizeDelta;
        float width = uiButton.gameObject.GetComponent<RectTransform>().rect.width;
        float height = uiButton.gameObject.GetComponent<RectTransform>().rect.height;

    }

    public void OKButtonClickA()
    {
        Debug.Log("OKButtonClickA");
        uiButton.onClick.RemoveListener(OKButtonClickA);
        uiButton.onClick.AddListener(OKButtonClickB);
        ani.SetTrigger("ButtonScale");
    }
    public void OKButtonClickB()
    {
        Debug.Log("OKButtonClickB");
        uiButton.onClick.RemoveListener(OKButtonClickB);
        uiButton.onClick.AddListener(OKButtonClickA);
        ani.SetTrigger("ButtonNornal");
    }

    void Update()
    {
        
    }
}
