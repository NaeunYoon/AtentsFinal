using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class _12_24_MouseButtonDown : MonoBehaviour
{
    [SerializeField] private GameObject _moveObject;

    void Start()
    {
        
    }

    void Update()
    {
        //GetMouseButtonDown();
        //Destroy();
        //Ray();
        //RaycastHitArray();
        //Tag();
        LayerMask();
    }

    void GetMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MpuseRightButtonDown");
            Debug.Log("ScreenPos "+Input.mousePosition);
            //���콺�� ��ǥ��� ��ũ�� ��ǥ�� �̴�.
            //�� �ϴ��� 0,0,0, �̰� ������ ��ũ���� ũ���̴�
            //z ���� 0�̴�.

            //ScreenToWorldPoint : ��ũ������ ���� ���� ���� �����󿡼� � ��ġ���� �˾ƾ� �Ѵ�
                                   //��ũ�������� ���� ���� �������� ��ǥ�� ��ȯ�ϴ� �Լ�

            Vector3 screenPos = Input.mousePosition;    //��ũ�� ��ǥ��� �� ��ǥ��
            screenPos.z = 10f;   //z�� 0���� �ϸ� �� �ȳ����� ������ ���Ƿ� ���� �ش�
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);   //��ũ�� ����Ʈ�� ���� ����Ʈ�� ��ȯ�Ѵ�
            Debug.Log("WorldPos "+worldPos);    //���

            //���� �������� ��ǥ�� ��ũ�� ��ǥ�� �ٲٴ� �Լ��� �ִ�
            Vector3 worldToScreen = Camera.main.WorldToScreenPoint(worldPos);
            Debug.Log("WorldToScreen " + worldToScreen);

            //���� ����Ʈ�� ��ȯ�� ��ũ�� ����Ʈ�� ��ġ�� �̵��ϴ� �ڵ�
            //_moveObject.GetComponent<Transform>().position = worldPos;
            //=> ȭ���� Ŭ���ϸ� ������Ʈ�� Ŭ���� ��ġ�� �̵��Ѵ�
            //=> �ʹ� �ٷ� �̵��ϴϱ� ť�꿡 �޸� ��ũ��Ʈ�� �����ͼ� �Լ��� �������͸� ���� �� õõ�� �����̰� �Ѵ�.
            _moveObject.GetComponent<_12_24_CubeExample>().SetPosition(worldPos);
        }
    }

    void Destroy()
    {
        //ī�޶󿡼� ����� ���ϴ� ������ �׸���, ������ �����ϴ� ����� ���� ������Ʈ�� ã�Ƴ���
        //��ũ���� ���� ���� �������� ����� ( ��ũ����ǥ���� ���� �������� �����)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //������ ��� �����Ѵ� ( ���������� ������ ��ü�� ������Ʈ�z �����Ѵ�, �浹�� ������ �����ش�)
        //������ �ְ� �΋H�� ��ü�� ������ �����´�
        //���� rpg ĳ���� �̵��� ���ȴ�
        if (Physics.Raycast(ray, out hitInfo))
        {
            //��� ��ġ�� �ε������� ������ ����Ѵ�
            Debug.Log("HitInfo " + hitInfo.point);
            //�浹�� ��ü�� �̸��� ����Ѵ�
            Debug.Log("HitInfo " + hitInfo.collider.name);
            //������ ������ ������Ʈ�� �ı��Ѵ�
            Destroy(hitInfo.collider.gameObject);
        }
    }

    void Ray ()
    {
        //ī�޶󿡼� ����� ���ϴ� ������ �׸���, ������ �����ϴ� ����� ���� ������Ʈ�� ã�Ƴ���
        //��ũ���� ���� ���� �������� ����� ( ��ũ����ǥ���� ���� �������� �����)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //������ ��� �����Ѵ� ( ���������� ������ ��ü�� ������Ʈ�z �����Ѵ�, �浹�� ������ �����ش�)
        //������ �ְ� �΋H�� ��ü�� ������ �����´�
        //���� rpg ĳ���� �̵��� ���ȴ�
        if(Physics.Raycast(ray, out hitInfo))
        {
            //��� ��ġ�� �ε������� ������ ����Ѵ�
            Debug.Log("HitInfo " + hitInfo.point);
            //�浹�� ��ü�� �̸��� ����Ѵ�
            Debug.Log("HitInfo " + hitInfo.collider.name);
            //�浹�� ������ �̵��Ѵ� ( ������ �浹���� �ʱ� ������ �浹�� ������ ������ �̵��Ѵ�)
            //���߿� �浹�� �� �ִ� ��ü�� �ִٸ� �� ������ ���Ѵ�.
            _moveObject.GetComponent<_12_24_CubeExample>().SetPosition(hitInfo.point);
        }
    }

    void RaycastHitArray()
    {
        //������ �ֵ� �� ã�� ���� �� RaycastAll �� ���� �������� ������ �迭�� ����� �迭�� �����ش�
        RaycastHit[] hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hitInfo = Physics.RaycastAll(ray);
        for (int i = 0; i < hitInfo.Length; i++)
        {
            Debug.Log(hitInfo[i].collider.gameObject.name);
        }
    }

    void Tag()
    {
        //������ �ֵ� �� ã�� ���� �� RaycastAll �� ���� �������� ������ �迭�� ����� �迭�� �����ش�
        RaycastHit[] hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hitInfo = Physics.RaycastAll(ray);
        for (int i = 0; i < hitInfo.Length; i++)
        {
            Debug.Log(hitInfo[i].collider.gameObject.name);
            //���� Ư�� ���ӿ�����Ʈ�� ��ȭ�� �ְ� �ʹٸ� �±׳� ���̾� ó���� �Ѵ�
            if (hitInfo[i].collider.gameObject.tag.Contains("Player"))
            {
                //Ư�� �±׸� ���� �ε��� ������Ʈ�� Ʈ�������� ������ ���Ͱ��� ������ ��
                Vector3 pos = hitInfo[i].collider.gameObject.GetComponent<Transform>().transform.position;
                //y�� ���� 1��ŭ ������Ų��
                pos.y += 1f;
                //������Ų ���� ������Ʈ�� ��ġ���� �����Ѵ� (�������� ������ �ö��� ����)
                hitInfo[i].collider.gameObject.GetComponent<Transform>().transform.position = pos;
            }
        }
    }

    void LayerMask()
    {
        //RaycastHit[] hits;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ///*
        // �ش� ���ڿ��� ����� LayerMask ��, int ũ���� ��Ʈ�� �������� �ȴ�.
        // ��ó�� �Լ��� ����� ���ϰ� ���̾� �̸����� ������ ���ڿ��� ��Ʈ�� ������ �� �ִ�
        // */
        //LayerMask mask = LayerMask.GetMask("Floor") | LayerMask.GetMask("Player");

        //hits = Physics.RaycastAll(ray, 100f, mask);   //����ũ ��Ʈ�� �ִ� �ָ� ������ �޴´�

        //for (int i = 0; i < hits.Length; i++)
        //{
        //    Debug.Log(hits[i].collider.gameObject.name);
        //    if (hits[i].collider.gameObject.tag.Contains("Player"))
        //    {
        //        Vector2 pos = hits[i].collider.gameObject.GetComponent<Transform>().position;
        //        pos.y += 1.0f;
        //        hits[i].collider.gameObject.GetComponent<Transform>().position = pos;
        //    }
        //}

    }
}
