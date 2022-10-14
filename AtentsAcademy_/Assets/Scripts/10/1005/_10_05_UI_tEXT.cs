using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class _10_05_UI_tEXT : MonoBehaviour
{
    // Start is called before the first frame update

    Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
        uiText.text = "½ºÄÚ¾î";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
