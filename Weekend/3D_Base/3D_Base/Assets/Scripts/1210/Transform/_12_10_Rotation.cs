using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_10_Rotation : MonoBehaviour
{
    private float x_rotation = 50f;
    private float y_rotation = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���ε��� ȣ������Ű�� ������ �̶�� ������ �߻��Ѵ�
        //���� ���ʹϾ��� ����ؼ� xyz�� �Ѳ����� ȸ����Ų��
        //
        //�ѹ� ȸ��
        //this.transform.rotation = Quaternion.Euler(30f, 60f, 30f);

        //��� ȸ��
        x_rotation += 10.0f * Time.deltaTime;
        y_rotation += 10.0f * Time.deltaTime;
        //this.transform.rotation = Quaternion.Euler(x_rotation, 60f, 30f);
        //this.transform.rotation = Quaternion.Euler(30f, y_rotation, 30f);
        this.transform.rotation = Quaternion.Euler(x_rotation, y_rotation, 30f);
    }
}
