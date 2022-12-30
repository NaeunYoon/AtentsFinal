using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_DynamicCreateObject : MonoBehaviour
{
    /*
     동적으로 만들다 = 실행중에 생성한다
     
     */
    [SerializeField] private GameObject _preFab;
    //열 개의 탱크를 보관하기 위한 배열을 만듬
    private GameObject[] _tank = new GameObject[10];
    void Start()
    {
        CreateObject();
    }

    void CreateObject()
    {
        for (int i = 0; i < 10; i++)
        {
            //유니티 랜덤값 설정할 때 쓰는 함수
            float xpos = UnityEngine.Random.Range(-5.0f, 5.0f);
            float zpos = UnityEngine.Random.Range(-5.0f, 5.0f);

            _tank[i] = Instantiate(_preFab, new Vector3(xpos, 0, zpos), Quaternion.Euler(0f, 90f, 0f));
            //                동적으로 만들 게임오브젝트,생성위치,생성회전값

            _tank[i].name = $"Tank_{i}";


            //이렇게 하나하나 재설정 할 수 있다.

            //_tank[i] = GameObject.Instantiate<GameObject>(_preFab);
            //_tank[i].transform.position = new Vector3(xpos, 0, zpos);
            //_tank[i].transform.rotation = Quaternion.Euler(0f,90f,0f);
        }
    }

    void Update()
    {
        
    }
}
