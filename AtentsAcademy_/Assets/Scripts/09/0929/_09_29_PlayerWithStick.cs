using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_29_PlayerWithStick : MonoBehaviour
{
    float moveSpeed;
    void Start()
    {
        moveSpeed = 2f;
    }

    
    void Update()
    {
        //_09_29_Stick.instance.dir

        Vector3 tmp = transform.position;
        tmp.x = tmp.x += _09_29_Stick.instance.dir.normalized.x*Time.deltaTime*moveSpeed;
        tmp.y = tmp.y += _09_29_Stick.instance.dir.normalized.y * Time.deltaTime * moveSpeed;
        tmp.z = tmp.z += _09_29_Stick.instance.dir.normalized.z * Time.deltaTime * moveSpeed;
        transform.position = tmp;
    }
}
