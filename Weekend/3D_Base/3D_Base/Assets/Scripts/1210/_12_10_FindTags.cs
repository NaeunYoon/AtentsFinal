using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_FindTags : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Scene�� Monster ��� �±׸� ���� ������Ʈ���� ã�Ƽ� �ı� 
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var item in objs)
        {
            Destroy(item.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
