using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_FindGameObjectsWithTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�������� �±�� ������Ʈ���� �Ѳ����� �׼��� ���ϰ� �� ��
        //������ �±׸� ������ �ִ� ��� ������Ʈ�� ã�Ƽ� ������Ʈ �迭�� �����մϴ�
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var item in objs)
        {
            item.gameObject.SetActive(false);
            //Destroy(item.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
