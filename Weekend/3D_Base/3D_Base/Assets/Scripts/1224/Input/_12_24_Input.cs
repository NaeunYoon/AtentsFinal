using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Input : MonoBehaviour
{

    private float _moveZ = 0.0f;
    private float _moveX = 0.0f;
    float speed = 5f;
    float rot = 100f;
    void Start()
    {
        
    }

    void Update()
    {
        //������Ʈ���� Ű �Է��� �־����� ��� Ȯ��--1
        //GetKey();
        //GetKeyDown();
        //GetKeyUp();
        //transform.Translate(new Vector3(_moveX, 0, _moveZ).normalized * 0.04f);
        //_moveX = 0.0f;
        //_moveZ = 0.0f;

        //==================================================

        /*����Ƽ �̺�Ʈ �Լ��� ����Ͽ� �̵�--2*/
        //����ȯ�� ������ȯ
        float moveSpeed = speed * Time.deltaTime;
        float rotSpeed = rot * Time.deltaTime;
        float front = Input.GetAxis("Vertical");
        float ang = Input.GetAxis("Horizontal");
        //-�� ����, +�� ������ �� ��
        transform.Translate(Vector3.forward * front * moveSpeed);
        transform.Rotate(Vector3.up * ang * rotSpeed);

        //===============================================
        //Input.GetAxisRaw : �������� ���� ���� ��ȯ�Ѵ�


    }
    /*
    GetKey : ��� ������ �־ ������ �Ѵ�. 
    GetKeyDown : Ű�� ������ ���� ó���ϰ� ���� �� ���
    GetKeyUp : Ű���带 ������ �� ����
    */

    public void GetKey()
    {

        if(Input.GetKey(KeyCode.UpArrow))
        {
            _moveZ += 0.05f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _moveZ -= 0.05f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _moveX -= 0.05f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _moveX += 0.05f;
        }

    }

    public void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _moveZ += 0.05f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _moveZ -= 0.05f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _moveX -= 0.05f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _moveX += 0.05f;
        }
    }

    public void GetKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _moveZ += 0.05f;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _moveZ -= 0.05f;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _moveX -= 0.05f;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _moveX += 0.05f;
        }
    }
}
