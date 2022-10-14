using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_30_UIUX : MonoBehaviour
{
    /*
     기획서에 포함시켜야 할 내용

    게임플레이의 특징을 고려한 제작의 방향성을 명시
    전체 게임화면의 구성 및 흐름
    화면 각각이 형상화된 이미지와 설명
    실제 게임 구동환경에 적용한 화면 이미지 제작

    라인랜더러를 이용한....(?
     

    1. 큐브의 정면으로 향해 발사되는 ray를 이용하여 타켓지점을 저장
    2. 레일의 끝에서 4초마다 한번씩 게임오브젝트 capsule을 생성하고 플레이어(큐브) 방향으로 이동하는 몬스터를 생성
       몬스터를 생성하는 것은?
       몬스터에게는 스크립트가 필요할까요?
       몬스터를 움직이게 하는 것은?
    3. 큐브의 라인이 몬스터와 부딪혔을 경우 몬스터는 삭제된다

    => 문제의 핵심은 라인의 움직임과 레이캐스트에서 사용하는 레이와의 움직임이 같아야함

            몬스터를 등장시키는 게임오브젝트가 필요
     
     */

    //라인랜더러를 알고 있어야 함
    public LineRenderer lineRenderer;
    Vector3 end;    //끝점
    Vector3 targetPos; //목표지점
    float moveSpeed;
    void Start()
    {
        lineRenderer.SetPosition(0,transform.position); //라인랜더러의 시작점이 내 위치가 됨
        end = transform.position;
        /*targetPos = new Vector3(transform.position.x, transform.position.y,10f);*/    //z축으로 10만큼 이동
        moveSpeed = 6f;
        FindTargetPosition();

    }

   
    void Update()
    {
        FindTargetPosition();
        DrawLine();
        FindInterSectionPosition();
        end = Vector3.MoveTowards(end, targetPos, Time.deltaTime * moveSpeed);
        lineRenderer.SetPosition(1,end);
    }

    void FindTargetPosition()       //타겟과 부딪혔을 때
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position,transform.forward,out hitInfo, Mathf.Infinity))
        {
            targetPos = hitInfo.point;      //교차점을 타겟포지션에 저장함
            Debug.Log(targetPos);
        }
    }

    void DrawLine()
    {
        Debug.DrawRay(transform.position, transform.forward,Color.blue);
    }

    void FindInterSectionPosition()
    {
        Vector3 dir = end - transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position,dir.normalized,out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.CompareTag("Monster"))
            {
                GameObject.Destroy(hitInfo.collider.gameObject);

            }
            targetPos = hitInfo.point;
            lineRenderer.SetPosition(0, transform.position);
        }

    }
}
