using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _hunet_01 : MonoBehaviour
{   
    //¼±¾ðºÎ
    public float moveSpeed = 2f;
    public float rotateSpeed = 50f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float moveDistanceZ =moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(0, -moveDistanceZ, 0);

        float rotateAngle = rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, rotateAngle);
    }
}
