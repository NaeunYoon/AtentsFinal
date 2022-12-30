using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_CannonBall : MonoBehaviour
{

    private float _rot = 0f;

    private Vector3 _start;
    private Vector3 _end;

    void Start()
    {
        _start = _end = transform.position;
    }

    void Update()
    {

        //리지드바디를 사용하므로서 임의로 중력값을 부여하던 것을 주석처리 함


        ////로컬 포워드 ( 앞쪽)으로 날아가게 한다
        //this.transform.position += this.transform.forward * 10f * Time.deltaTime;
        ////원형이라 회전하지 않아도 되지만 안맞춰두면 어느 방향이 앞쪽인지 모르기 때문에 회전을 시킴


        //_end = this.transform.position;
        ////어느정도 직선으로 날아가다가 중력 영향을 받게 함
        ////magnitude : 백터의 크기(길이) end의 벡터 크기와 start의 벡터 크기의 차가 4 이상이 나면 그 때부터 중력의 영향을 받아라
        //if((_end.magnitude - _start.magnitude) > 4f)
        //{
        //    //볼이 중력의 영향을 받기 때문에 천천히 아래로 떨어지게 한다 ( 지면 방향으로 내려가게)
        //    _rot += 10f * Time.deltaTime;
        //    //초당 10씩 움직이게 한다
        //    this.transform.rotation = Quaternion.Euler(_rot, 0f, 0f);
        //}

        if(this.transform.position.y <= 0.0f)   //포탄이 지면에 닿으면 포탄을 삭제 처리한다.
        {
            Destroy(this.gameObject,3f);
        }



    }
}
