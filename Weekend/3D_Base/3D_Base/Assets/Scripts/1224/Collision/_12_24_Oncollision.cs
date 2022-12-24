using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Oncollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    /*두쪽 다 콜라이더 컴포넌트가 추가 되어야 하고,
     한 쪽은 리지드바디가 있어야 한다.*/
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter /" +  this.gameObject.name +" / "+ collision.collider.gameObject.name);

        if (collision.collider.tag.Contains("Player"))
        {
            Destroy(collision.collider.gameObject); 

        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay /" + this.gameObject.name + " / " + collision.collider.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit /" + this.gameObject.name + " / " + collision.collider.gameObject.name);
    }

}
