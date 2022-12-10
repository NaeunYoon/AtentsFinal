using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class _12_10_Move : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    GameObject target;

    float speed = 10f;
    void Start()
    {
        target = GameObject.Find("Target");

        Time.timeScale = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //x,y,z ���� �����Ͽ� �̵�
        //var pos= this.transform.position;
        //pos.x += 0.05f;
        //pos.y += 0.05f;
        //pos.z += 0.05f;
        //this.transform.position = pos;

        //Vector �� �̿��ؼ� �̵� (����� ũ�⸦ ������ �ִ� ������)
        //transform.position += new Vector3(0.01f, 0.01f, 0);

        //���̰� 1�� ���� : �������� * ���ǵ� * ��ŸŸ��
        //transform.position += new Vector3(0.01f, 0.01f, 0).normalized
        //    *speed*Time.deltaTime;

        //��ü�� ���������� ��
        //transform.position += Vector3.up *speed* Time.deltaTime;
        //transform.position += Vector3.down * speed * Time.deltaTime;
        //transform.position += Vector3.left * speed * Time.deltaTime;
        //transform.position += Vector3.right * speed * Time.deltaTime;
        //transform.position += Vector3.forward * speed * Time.deltaTime;

        //�����Ǵ� �Լ��� ����ϱ�
        //transform.Translate(Vector3.up);
        //transform.Translate(new Vector3(0, 1, 0));
        //transform.Translate(new Vector3(0.01f, 0.01f, 0).normalized* speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        //�ٸ� ������Ʈ �������� �̵���Ű��

        Vector3 direct = target.transform.position - this.transform.position;
        //�̷��� �ϸ� �� �� ���� ���Ͱ� �������
        //�׷��� �츮�� ���⸸ �ʿ���
        transform.position += direct.normalized * speed * Time.deltaTime;
        

    }


}
