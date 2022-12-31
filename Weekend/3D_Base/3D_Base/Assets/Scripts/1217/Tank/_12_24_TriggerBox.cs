using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_TriggerBox : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubes;
    [SerializeField] private GameObject _dropStone;
    [SerializeField] private Camera _mainCam;
    //카메라 위치 변경
    private Vector3 _originCamPos = new Vector3(-0.8f,20.1f,8.4f);
    private Vector3 _originCamRot = new Vector3(95f,0f,0f);
    private Vector3 _hitCamPos = new Vector3(12f,2.5f,8.2f);
    private Vector3 _hitCamRot = new Vector3(-2.6f,-98f,-0.1f);
    private float _time;
    private bool _drop = false;
    void Start()
    {
        /*
         isTrigger를 체크하면 물체가 서로 반발력을 갖지 않고 통과한다
         그러나 통과했는지를 체크하기 위해서 사용한다
         
         */
    }

    void Update()
    {
        if(_drop)
        {   //3초동안 머무르면 돌이 떨어진다
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
        //박스에 부딪혔을 때
        Debug.Log("OnTriggerEnter");
        //큐브 배열에 있는 것들을 보여지게 한다
        foreach (var item in _cubes)
        {
            item.gameObject.SetActive(true);
        }

        _mainCam.GetComponent<Transform>().position = _hitCamPos;
        _mainCam.GetComponent<Transform>().rotation = Quaternion.Euler(_hitCamRot);
    }
    private void OnTriggerStay(Collider other)
    {
        //박스에 겹쳐져 있을 때
        Debug.Log("OnTriggerStay");
    }
    private void OnTriggerExit(Collider other)
    {
        _drop = false;
        //박스와의 충돌이 끝났을 때
        Debug.Log("OnTriggerExit");
        //물리 영향을 받아야 하기 때문에 dropstone에 rigidbody 를 추가하고
        //중력의 영향을 받지 않게 한다
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
