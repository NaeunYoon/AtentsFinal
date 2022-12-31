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
            //마우스의 좌표계는 스크린 좌표계 이다.
            //좌 하단은 0,0,0, 이고 우상단은 스크린의 크기이다
            //z 값은 0이다.

            //ScreenToWorldPoint : 스크린에서 누른 점이 월드 공간상에서 어떤 위치인지 알아야 한다
                                   //스크린에서의 점을 월드 공간상의 좌표로 변환하는 함수

            Vector3 screenPos = Input.mousePosition;    //스크린 좌표계로 한 좌표값
            screenPos.z = 10f;   //z를 0으로 하면 잘 안나오기 때문에 임의로 값을 준다
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);   //스크린 포인트를 월드 포인트로 변환한다
            Debug.Log("WorldPos "+worldPos);    //출력

            //월드 공간상의 좌표를 스크린 좌표로 바꾸는 함수도 있다
            Vector3 worldToScreen = Camera.main.WorldToScreenPoint(worldPos);
            Debug.Log("WorldToScreen " + worldToScreen);

            //월드 포인트로 변환된 스크린 포인트의 위치로 이동하는 코드
            //_moveObject.GetComponent<Transform>().position = worldPos;
            //=> 화면을 클릭하면 오브젝트가 클릭한 위치로 이동한다
            //=> 너무 바로 이동하니까 큐브에 달린 스크립트를 가져와서 함수로 단위벡터를 구한 뒤 천천히 움직이게 한다.
            _moveObject.GetComponent<_12_24_CubeExample>().SetPosition(worldPos);
        }
    }

    void Destroy()
    {
        //카메라에서 월드로 향하는 직선을 그리고, 직선과 교차하는 평면을 가진 오브젝트를 찾아낸다
        //스크린에 찍은 점을 광선으로 만든다 ( 스크린좌표계의 점을 광선으로 만든다)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //광선을 쏘기 시작한다 ( 직선광선과 광선과 교체한 오브젝트틑 전달한다, 충돌된 정보를 돌려준다)
        //광선을 넣고 부딫힌 물체의 정보를 가져온다
        //보통 rpg 캐릭터 이동에 사용된다
        if (Physics.Raycast(ray, out hitInfo))
        {
            //어느 위치에 부딪혔는지 정보를 출력한다
            Debug.Log("HitInfo " + hitInfo.point);
            //충돌된 물체의 이름을 출력한다
            Debug.Log("HitInfo " + hitInfo.collider.name);
            //광선과 교차한 오브젝트를 파괴한다
            Destroy(hitInfo.collider.gameObject);
        }
    }

    void Ray ()
    {
        //카메라에서 월드로 향하는 직선을 그리고, 직선과 교차하는 평면을 가진 오브젝트를 찾아낸다
        //스크린에 찍은 점을 광선으로 만든다 ( 스크린좌표계의 점을 광선으로 만든다)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //광선을 쏘기 시작한다 ( 직선광선과 광선과 교체한 오브젝트틑 전달한다, 충돌된 정보를 돌려준다)
        //광선을 넣고 부딫힌 물체의 정보를 가져온다
        //보통 rpg 캐릭터 이동에 사용된다
        if(Physics.Raycast(ray, out hitInfo))
        {
            //어느 위치에 부딪혔는지 정보를 출력한다
            Debug.Log("HitInfo " + hitInfo.point);
            //충돌된 물체의 이름을 출력한다
            Debug.Log("HitInfo " + hitInfo.collider.name);
            //충돌된 곳으로 이동한다 ( 공중은 충돌되지 않기 때문에 충돌이 가능한 곳으로 이동한다)
            //공중에 충돌할 수 있는 물체가 있다면 그 쪽으로 향한다.
            _moveObject.GetComponent<_12_24_CubeExample>().SetPosition(hitInfo.point);
        }
    }

    void RaycastHitArray()
    {
        //교차된 애들 다 찾고 싶을 때 RaycastAll 을 쓰고 여러개기 때문에 배열을 만들어 배열을 돌려준다
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
        //교차된 애들 다 찾고 싶을 때 RaycastAll 을 쓰고 여러개기 때문에 배열을 만들어 배열을 돌려준다
        RaycastHit[] hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hitInfo = Physics.RaycastAll(ray);
        for (int i = 0; i < hitInfo.Length; i++)
        {
            Debug.Log(hitInfo[i].collider.gameObject.name);
            //만약 특정 게임오브젝트만 변화를 주고 싶다면 태그나 레이어 처리를 한다
            if (hitInfo[i].collider.gameObject.tag.Contains("Player"))
            {
                //특정 태그를 가진 부딪힌 오브젝트의 트렌스폼을 가져와 벡터값에 저장한 뒤
                Vector3 pos = hitInfo[i].collider.gameObject.GetComponent<Transform>().transform.position;
                //y의 값을 1만큼 증가시킨다
                pos.y += 1f;
                //증가시킨 값을 오브젝트의 위치값에 대입한다 (대입하지 않으면 올라가지 않음)
                hitInfo[i].collider.gameObject.GetComponent<Transform>().transform.position = pos;
            }
        }
    }

    void LayerMask()
    {
        //RaycastHit[] hits;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ///*
        // 해당 문자열로 저장된 LayerMask 즉, int 크기의 비트를 가져오게 된다.
        // 이처럼 함수를 사용해 편하게 레이어 이름으로 지정한 문자열로 비트를 가져올 수 있다
        // */
        //LayerMask mask = LayerMask.GetMask("Floor") | LayerMask.GetMask("Player");

        //hits = Physics.RaycastAll(ray, 100f, mask);   //마스크 비트에 있는 애만 영향을 받는다

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
