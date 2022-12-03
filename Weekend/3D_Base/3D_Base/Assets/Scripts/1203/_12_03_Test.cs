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
        //������ �ð����� ó���ؾ� �� ��
    }
    private void LateUpdate()
    {
        if (_isLapeUpdateLoop==true)
        {
            Debug.Log("LataUpdate");
        }
        //������Ʈ�� ���� ������ ȣ��ȴ�
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
        //�ý��ۿ� ���� ȣ��Ǵ� �ð� ������ �ٸ���
    }
}
