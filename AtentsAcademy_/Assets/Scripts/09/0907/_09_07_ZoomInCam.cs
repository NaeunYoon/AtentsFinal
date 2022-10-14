using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_07_ZoomInCam : MonoBehaviour
{

    float scrollWheel;
    float t;
    float a;
    float b;

    void Start()
    {
        t = 0f;
        a = Camera.main.fieldOfView;
        b = Camera.main.fieldOfView;
    }

    
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        float s = Input.GetAxis("Mouse ScrollWheel");
        if(s != 0)
        {
            scrollWheel = s;
            a = Camera.main.fieldOfView;
            b = a + scrollWheel * 50f;
            t = 0;

        }
        float curFov = Mathf.Lerp(a, b, t);
        t += 8f * Time.deltaTime;
        Camera.main.fieldOfView = curFov;
    }
}
