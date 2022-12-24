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
        //업데이트에서 키 입력이 있었는지 계속 확인--1
        //GetKey();
        //GetKeyDown();
        //GetKeyUp();
        //transform.Translate(new Vector3(_moveX, 0, _moveZ).normalized * 0.04f);
        //_moveX = 0.0f;
        //_moveZ = 0.0f;

        //==================================================

        /*유니티 이벤트 함수를 사용하여 이동--2*/
        //수평변환과 수직변환
        float moveSpeed = speed * Time.deltaTime;
        float rotSpeed = rot * Time.deltaTime;
        float front = Input.GetAxis("Vertical");
        float ang = Input.GetAxis("Horizontal");
        //-면 후진, +면 전진이 될 것
        transform.Translate(Vector3.forward * front * moveSpeed);
        transform.Rotate(Vector3.up * ang * rotSpeed);

        //===============================================
        //Input.GetAxisRaw : 정제되지 않은 값을 반환한다


    }
    /*
    GetKey : 계속 누르고 있어도 반응을 한다. 
    GetKeyDown : 키가 눌렸을 때만 처리하고 싶을 때 사용
    GetKeyUp : 키보드를 떼었을 때 반응
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
