using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_Transform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ���� �����󿡼� �ڽĿ�����Ʈ�� �̸����� ã�� ��.
        Transform tr = transform.Find("Cube (3)");
        tr.gameObject.SetActive(false);

        //���������󿡼� �ڽĿ�����Ʈ�� ������ ã�� ���
        Transform tr2 = transform.GetChild(0);
        tr2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
