using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_TargetObjectMove : MonoBehaviour
{
    /*
     A���� B�� ���ϰ� �ʹٸ� B�� ���ϴ� ���͸� ����� �ȴ�
     B����A�� ���� �ȴ�. �� ���� �������� �����̰� �ϸ� �ȴ�.
     */

    //���1
    //Find ��ɾ�� ã�´�
    GameObject targetObject;

    //���2
    //�����ؼ� ã�´�
    [SerializeField] private GameObject _TargetObject;


    void Start()
    {
        //���1 find�� ���� ���� �������� ���� ������Ʈ��
        targetObject = GameObject.Find("TargetObject");


    }

    void Update()
    {
        //TargetObject �������� �̵���Ű��(1)
        //Vector3 direct = targetObject.transform.position - this.transform.position;
       // transform.position += direct.normalized * 10f * Time.deltaTime;

        //TargetObject �������� �̵���Ű��(2)
        Vector3 direct = _TargetObject.transform.position - this.transform.position;
        transform.position += direct.normalized * 10f * Time.deltaTime;
    }
}
