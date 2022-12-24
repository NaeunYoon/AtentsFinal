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
        if (Input.GetMouseButtonDown(0))    //���콺 ��ư�� ��������
        {
            Debug.Log("Mouse Right Button Down");
            //���콺�� ��ġ�ϰ� �ִ� ���� ��ġ��
            //���콺�� Ŭ���Ǵ� ���� ��ũ�� ��ǥ���̴�.
            //���ϴ��� 0,0 �̰� �� ����� 1920,1080 �̴�
            Debug.Log(Input.mousePosition);

            //��ũ������Ʈ�� ���� ���� �������� ������ ��ȯ���ִ� �Լ�
            //z���� ����. ��ũ�� �����󿡼��� 2D�̱� ������..
            Vector3 pos = Input.mousePosition;
            pos.z = 10.0f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            Debug.Log("worldPos"+worldPos);

            //������ ���
            //obj.GetComponent<Transform>().position = worldPos;

            
            //obj.transform.position = worldPos;


            obj.GetComponent<_12_24_MouseMoveSlow>().SetPosition(worldPos);


        }
    }
}
