using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_Tank : MonoBehaviour
{
    [SerializeField] private GameObject _canonBallPrefab;
    [SerializeField] private Transform _firePos;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Ű�� ���� => �Է¹��ۿ� Ű�� ������ ����� => ���ۿ� ���� Ű�� �ִ��� Ȯ����
            //�����̽��� ������ ĳ�� �������� �������
            GameObject cannonBall = Instantiate(_canonBallPrefab,_firePos.transform.position,_firePos.transform.rotation);
            cannonBall.transform.SetParent(_firePos.transform);
            /*
             ���ӿ�����Ʈ�� ���� ������ �������� ������ٵ� (��ü) �� �־�� �Ѵ�
             ������ٵ� �߰��� ���� ������ ������ �ް� �ȴ�.
             
            ����
            ������ �� ������ ������ �޴� ����
            ȸ���� �� ������ ������ �޴� ����
            �߷�

            �������
            ���� ������ �޾��� �� ��� ��ġ�� ������ų����

            ������ ������ �޾Ƽ� ó���Ϸ���? ĳ�� ���� �ִ� ������ٵ� �����´�

             */

            cannonBall.GetComponent<Rigidbody>().AddForce(_firePos.transform.forward * 1200f, ForceMode.Force);
            //������ �ٵ� ���� �������� ( ��ü�� ���� �ִ� �Լ� ) ��� ( ����� ��������, ��ŭ �� ����, ���� �ɼ��� �ش�) 
            // ForceMode.Force : �������� ��
            // ForceMode.Acceleration : ������� ������ ���ϰ� ������ ����
            // ForceMode.Impulse : ������ �̿��ؼ� ��ݷ��� ���Ѵ�
            // ForceMode.VelocityChange : �ӵ��� ���ϸ� ������ �����Ѵ�

            //ĳ���� �پ��ִ� �ֵ������� �̿��ؼ� ��ź�� ���ư��� �� ( �������� + �߷��ǿ��� = �������)


        }




    }
}
