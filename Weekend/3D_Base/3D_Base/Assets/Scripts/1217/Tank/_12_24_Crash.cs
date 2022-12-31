using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Crash : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #region Collider
    private void OnCollisionEnter(Collision collision)
    {
        //충돌했을 떄
        Debug.Log("OnCollisionEnter " + this.gameObject.name + " " + collision.collider.gameObject.name);
        
    }
    private void OnCollisionStay(Collision collision)
    {
        //충돌상태일 때
        Debug.Log("OnCollisionStay " + this.gameObject.name + " " + collision.collider.gameObject.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        //충돌하고 떨어질 때
        Debug.Log("OnCollisionExit " + this.gameObject.name +" " + collision.collider.gameObject.name);
    }
    #endregion
}
