using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_GetChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //���������󿡼� �ڽĿ�����Ʈ�� ������ ã�� ���
        Transform tr = transform.GetChild(2);
        tr.gameObject.SetActive(false);
        //0��°�ڽ� 1��°�ڽ� 2��°�ڽ� ������ ����. ���� ������ �ڽ���.
        //�θ� ������Ʈ�� �پ� �־�� �Ѵ�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
