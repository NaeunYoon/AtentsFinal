using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_TriggerBox : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubes;
    [SerializeField] private GameObject _dropStone;
    [SerializeField] private Camera _mainCam;
    //ī�޶� ��ġ ����
    private Vector3 _originCamPos = new Vector3(-0.8f,20.1f,8.4f);
    private Vector3 _originCamRot = new Vector3(95f,0f,0f);
    private Vector3 _hitCamPos = new Vector3(12f,2.5f,8.2f);
    private Vector3 _hitCamRot = new Vector3(-2.6f,-98f,-0.1f);
    private float _time;
    private bool _drop = false;
    void Start()
    {
        /*
         isTrigger�� üũ�ϸ� ��ü�� ���� �ݹ߷��� ���� �ʰ� ����Ѵ�
         �׷��� ����ߴ����� üũ�ϱ� ���ؼ� ����Ѵ�
         
         */
    }

    void Update()
    {
        if(_drop)
        {   //3�ʵ��� �ӹ����� ���� ��������
            _time += Time.deltaTime;
            if(_time > 3f)
            {
                DropStone();
                _drop = false;
                _time = 0f;
            }
        }
    }
    #region Trigger
    private void OnTriggerEnter(Collider other)
    {
        _drop=true;
        _time = 0f;
        //�ڽ��� �ε����� ��
        Debug.Log("OnTriggerEnter");
        //ť�� �迭�� �ִ� �͵��� �������� �Ѵ�
        foreach (var item in _cubes)
        {
            item.gameObject.SetActive(true);
        }

        _mainCam.GetComponent<Transform>().position = _hitCamPos;
        _mainCam.GetComponent<Transform>().rotation = Quaternion.Euler(_hitCamRot);
    }
    private void OnTriggerStay(Collider other)
    {
        //�ڽ��� ������ ���� ��
        Debug.Log("OnTriggerStay");
    }
    private void OnTriggerExit(Collider other)
    {
        _drop = false;
        //�ڽ����� �浹�� ������ ��
        Debug.Log("OnTriggerExit");
        //���� ������ �޾ƾ� �ϱ� ������ dropstone�� rigidbody �� �߰��ϰ�
        //�߷��� ������ ���� �ʰ� �Ѵ�
        _dropStone.GetComponent<Rigidbody>().useGravity=true;
        _dropStone.GetComponent<Rigidbody>().AddForce(-transform.up*1000f,ForceMode.Force);

        _mainCam.GetComponent<Transform>().position = _originCamPos;
        _mainCam.GetComponent<Transform>().rotation = Quaternion.Euler(_originCamRot);
    }
    #endregion

    void DropStone()
    {
        _dropStone.GetComponent<Rigidbody>().useGravity = true;
        _dropStone.GetComponent<Rigidbody>().AddForce(-transform.up * 1000f, ForceMode.Force);

    }

}
