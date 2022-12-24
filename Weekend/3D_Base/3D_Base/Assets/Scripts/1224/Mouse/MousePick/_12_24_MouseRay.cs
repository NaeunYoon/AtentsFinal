using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _12_24_MouseRay : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    void Start()
    {
        
    }

    void Update()
    {
        //���콺�� ���� ��ũ�� ��ǥ�踦 �������� ����� �ش�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //�� ������ �����ϴ� ������ ã�´�
        RaycastHit hitInfo;
        //������ ������ ����
        //������� ������ �ְ�, �΋H�� ��ü�� ���� ������ �ִ´�
        if(Physics.Raycast(ray,out hitInfo))
        {
            Debug.Log("HitPoint = "+ hitInfo.point);
            //�������� ��ġ�� ã�Ƽ� �̵�
            obj.GetComponent<_12_24_MouseMoveSlow>().SetPosition(hitInfo.point);
            Debug.Log(hitInfo.collider.gameObject.name);
            //�������� �ݶ��̴��� ����
            //Destroy(hitInfo.collider.gameObject);
        }
    }
}
