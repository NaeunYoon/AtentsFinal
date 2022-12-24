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
     �浹�ߴ����� üũ�ϴ°Ű� ���� �������� ���� �ʴ´� (����Ѵ�) isTrigger üũ
     isTrigger�� üũ�� ���ϸ� ����� ���Ѵ�
     �̰��� ��� ������ �� ������ �������� �� � ó���� �ϱ� ���ؼ� ����� �� �̴�
     �浹ü�� Ʈ���� ������ �ϴ� ���̶�� isTrigger�� üũ�ؾ� �Ѵ�
     (��Ż�� �̵�) �� �̷���
     */


    private void OnTriggerEnter(Collider other) //�浹�� �Ͼ�� ��
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
