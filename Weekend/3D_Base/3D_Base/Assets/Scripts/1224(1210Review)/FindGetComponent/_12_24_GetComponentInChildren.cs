using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _12_24_GetComponentInChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������������ �ڽ� ������Ʈ�� ������Ʈ�� ������ ��
        _12_24_Slime slime = this.gameObject.GetComponentInChildren<_12_24_Slime>();
        slime.Attack();
        //�� ó���� ã�� �� �ϳ� ����

        _12_24_Slime [] slimes = this.gameObject.GetComponentsInChildren<_12_24_Slime>();
        foreach (var item in slimes)
        {
            item.Attack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
