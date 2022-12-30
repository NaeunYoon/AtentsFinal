using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_DynamicCreateObject : MonoBehaviour
{
    /*
     �������� ����� = �����߿� �����Ѵ�
     
     */
    [SerializeField] private GameObject _preFab;
    //�� ���� ��ũ�� �����ϱ� ���� �迭�� ����
    private GameObject[] _tank = new GameObject[10];
    void Start()
    {
        CreateObject();
    }

    void CreateObject()
    {
        for (int i = 0; i < 10; i++)
        {
            //����Ƽ ������ ������ �� ���� �Լ�
            float xpos = UnityEngine.Random.Range(-5.0f, 5.0f);
            float zpos = UnityEngine.Random.Range(-5.0f, 5.0f);

            _tank[i] = Instantiate(_preFab, new Vector3(xpos, 0, zpos), Quaternion.Euler(0f, 90f, 0f));
            //                �������� ���� ���ӿ�����Ʈ,������ġ,����ȸ����

            _tank[i].name = $"Tank_{i}";


            //�̷��� �ϳ��ϳ� �缳�� �� �� �ִ�.

            //_tank[i] = GameObject.Instantiate<GameObject>(_preFab);
            //_tank[i].transform.position = new Vector3(xpos, 0, zpos);
            //_tank[i].transform.rotation = Quaternion.Euler(0f,90f,0f);
        }
    }

    void Update()
    {
        
    }
}
