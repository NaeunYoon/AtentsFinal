using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_OnTrigger : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private GameObject _DropStone;
    [SerializeField] private GameObject[] _Cubes;

    private Vector3 _OriginCameraPos = new Vector3(0.0f, 1.0f, -10.0f);
    private Vector3 _OriginCameraRot = new Vector3(0.0f, 0.0f, 0.0f);

    private Vector3 _DropCameraPos = new Vector3(0.0f, 22.5f, 3.7f);
    private Vector3 _DropCameraRot = new Vector3(90.0f, 0.0f, 0.0f);


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /*
     충돌했는지만 체크하는거고 서로 물리량은 갖지 않는다 (통과한다) isTrigger 체크
     isTrigger를 체크를 안하면 통과를 못한다
     이것의 사용 이유는 이 영역을 지나갔을 때 어떤 처리를 하기 위해서 만드는 것 이다
     충돌체가 트리거 역할을 하는 것이라면 isTrigger를 체크해야 한다
     (포탈로 이동) 뭐 이런거
     */


    private void OnTriggerEnter(Collider other) //충돌이 일어났을 때
    {
        Debug.Log("OnTriggerEnter");

        foreach (var obj in _Cubes)
        {
            obj.SetActive(true);
        }
        _mainCamera.GetComponent<Transform>().position = _DropCameraPos;
        _mainCamera.GetComponent<Transform>().rotation = Quaternion.Euler(_DropCameraRot);


    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");


    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");

        _DropStone.GetComponent<Rigidbody>().useGravity = true;
        _DropStone.GetComponent<Rigidbody>().AddForce(-transform.up * 1000.0f, ForceMode.Force);

        _mainCamera.GetComponent<Transform>().position = _OriginCameraPos;
        _mainCamera.GetComponent<Transform>().rotation = Quaternion.Euler(_OriginCameraRot);


    }

}
