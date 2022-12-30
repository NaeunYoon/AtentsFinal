using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_Tank : MonoBehaviour
{
    [SerializeField] private GameObject _canonBallPrefab;
    [SerializeField] private Transform _firePos;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //키를 누름 => 입력버퍼에 키의 정보가 저장됨 => 버퍼에 눌린 키가 있는지 확인함
            //스페이스가 눌리면 캐논볼 프리팹이 만들어짐
            GameObject cannonBall = Instantiate(_canonBallPrefab,_firePos.transform.position,_firePos.transform.rotation);
            cannonBall.transform.SetParent(_firePos.transform);
            /*
             게임오브젝트가 물리 영향을 받으려면 리지드바디 (강체) 가 있어야 한다
             리지드바디가 추가된 순간 물리의 영향을 받게 된다.
             
            질량
            움직일 때 공기의 영향을 받는 정도
            회전할 때 공기의 영향을 받는 정도
            중력

            제약사항
            물리 영향을 받았을 때 어느 위치를 고정시킬건지

            물리의 영향을 받아서 처리하려면? 캐논 볼에 있는 리지드바디를 가져온다

             */

            cannonBall.GetComponent<Rigidbody>().AddForce(_firePos.transform.forward * 1200f, ForceMode.Force);
            //리지드 바디 안의 에드포스 ( 물체에 힘을 주는 함수 ) 사용 ( 어느쪽 방향으로, 얼만큼 줄 건지, 힘의 옵션을 준다) 
            // ForceMode.Force : 지속적인 힘
            // ForceMode.Acceleration : 계속적인 가속을 더하고 질량은 무시
            // ForceMode.Impulse : 질량을 이용해서 충격력을 더한다
            // ForceMode.VelocityChange : 속도를 더하며 질량은 무시한다

            //캐논볼에 붙어있는 애드포스를 이용해서 포탄이 날아가게 함 ( 물리영향 + 중력의영향 = 포물선운동)


        }




    }
}
