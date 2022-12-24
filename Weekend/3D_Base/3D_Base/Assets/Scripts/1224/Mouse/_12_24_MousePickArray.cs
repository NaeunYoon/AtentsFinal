using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class _12_24_MousePickArray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*
         �����ɽ�Ʈ�� ó���� �΋H�� �ֵ��� ã�� ���̰�,
        ������ �΋H�� �ֵ� ��θ� ã�� �ʹٸ�?
         
         */
        RaycastHit[] hits;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray);

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
