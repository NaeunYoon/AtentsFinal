using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Mouse : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //마우스 버튼이 눌렸으면
        {
            Debug.Log("Mouse Right Button Down");
            //마우스가 위치하고 있는 곳의 위치값
            //마우스가 클릭되는 곳은 스크린 좌표계이다.
            //좌하단이 0,0 이고 우 상단이 1920,1080 이다
            Debug.Log(Input.mousePosition);

            //스크린포인트의 점을 월드 공간상의 점으로 변환해주는 함수
            //z값은 없다. 스크린 공간상에서는 2D이기 때문에..
            Vector3 pos = Input.mousePosition;
            pos.z = 10.0f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            Debug.Log("worldPos"+worldPos);

            //정석인 방법
            //obj.GetComponent<Transform>().position = worldPos;

            
            //obj.transform.position = worldPos;


            obj.GetComponent<_12_24_MouseMoveSlow>().SetPosition(worldPos);


        }
    }
}
