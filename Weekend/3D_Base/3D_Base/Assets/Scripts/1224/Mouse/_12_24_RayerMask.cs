using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_RayerMask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        LayerMask mask = LayerMask.GetMask("Floor")|LayerMask.GetMask("Player");

        hits = Physics.RaycastAll(ray,100f,mask);   //마스크 비트에 있는 애만 영향을 받는다

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject.name);
            if (hits[i].collider.gameObject.tag.Contains("Player"))
            {
                Vector2 pos = hits[i].collider.gameObject.GetComponent<Transform>().position;
                pos.y += 1.0f;
                hits[i].collider.gameObject.GetComponent<Transform>().position = pos;
            }
        }
    }
}
