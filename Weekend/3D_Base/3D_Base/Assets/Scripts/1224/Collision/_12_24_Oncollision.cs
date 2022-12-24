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
    /*���� �� �ݶ��̴� ������Ʈ�� �߰� �Ǿ�� �ϰ�,
     �� ���� ������ٵ� �־�� �Ѵ�.*/
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
