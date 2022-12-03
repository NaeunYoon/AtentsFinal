using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class _12_03_Test : MonoBehaviour
{

    [SerializeField] private bool _isUpdateLoop = false;
    [SerializeField] private bool _isLapeUpdateLoop = false;
    [SerializeField] private bool _isFixedUpdateLoop = false;

    private void Awake()
    {
        Debug.Log("Awake");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    void Start()
    {
        Debug.Log("Start");
        Debug.LogWarning("Start Warning");
        Debug.LogError("Start Error");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDistroy");
    }
    private void FixedUpdate()
    {
        if (_isFixedUpdateLoop == true)
        {
            Debug.Log("FixedUpdate");

        }
        //일정한 시간마다 처리해야 할 때
    }
    private void LateUpdate()
    {
        if (_isLapeUpdateLoop==true)
        {
            Debug.Log("LataUpdate");
        }
        //업데이트가 끝난 다음에 호출된다
    }

    private void OnApplicationQuit()
    {
        Debug.Log("ApplicationQuit");
    }
    void Update()
    {
        if(_isUpdateLoop == true)
        {
            Debug.Log("Update");
        }
        //시스템에 따라 호출되는 시간 간격이 다르다
    }
}
