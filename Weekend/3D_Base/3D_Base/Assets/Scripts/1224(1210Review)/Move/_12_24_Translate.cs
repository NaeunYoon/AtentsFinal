using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Translate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate 함수를 사용
        //transform.Translate(new Vector3(0.01f, 0.01f, 0.01f));
        transform.Translate(new Vector3(0.01f, 0.01f, 0.01f).normalized * 10f * Time.deltaTime);
    }
}
