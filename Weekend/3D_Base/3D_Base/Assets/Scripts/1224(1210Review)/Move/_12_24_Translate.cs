using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class _12_24_Translate : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate �Լ��� ���
        //transform.Translate(new Vector3(0.01f, 0.01f, 0.01f));
        //transform.Translate(new Vector3(0.01f, 0.01f, 0.01f).normalized * 10f * Time.deltaTime);
        //transform.Translate(Vector3.forward*10f*Time.deltaTime);    //��������(�������� forward)
        //transform.Translate(Vector3.forward * 10f * Time.deltaTime,Space.World);//������ �̵�
        //transform.Translate(Vector3.forward * 10f * Time.deltaTime, Space.Self); //������
        transform.position += transform.forward * 10f * Time.deltaTime;     //������ǥ������ �̵�
    }
}
