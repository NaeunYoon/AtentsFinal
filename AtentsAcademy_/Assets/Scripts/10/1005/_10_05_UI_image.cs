using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_05_UI_image : MonoBehaviour
{

    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount -=Time.deltaTime * 0.1f;
    }
}
