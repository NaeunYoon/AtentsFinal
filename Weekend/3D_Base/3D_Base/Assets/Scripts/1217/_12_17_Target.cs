using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class _12_17_Target : MonoBehaviour
{
    [SerializeField] public Transform target;

    float yrot = 0f;
    float xroy = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        //오브젝트가 확 쳐다보게 만드는 것.
        this.transform.LookAt(target);

        //오브젝트가 서서히 쳐다보게 만들게 하려면?
        //타겟하고 해당 오브젝트와의 벡터값을 만든다 
        //타겟이 있으면, 타겟위치에서 나의 위치를 뺴면, 타겟 방향으로 향하는 벡터가 생긴다
        //방향벡터를 만들었는데 만약 나의 오브젝트가 다른 쪽을 가리키고 있음
        //룩엣은 다른곳을 보고 있다가 타겟쪽으로 회전하게 하는 것인데
        //확 회전시키는 것이 아니라 서서히 회전시키게 하고 싶음
        //그 세타값만큼을 회전시키는 것이 룩엣 함수가 하는 일인데
        //그러면, 방향벡터를 구한 다음에 해당 포지션에 쿼터니언의 러프를 해준다
        Vector3 dir = target.transform.position - this.transform.position;
        //보간함수를 사용하라는 말
        //내 회전 = 지금 현재 위치의 회전 값에서 타겟의 방향벡터의 회전값을 구해주고, 회전속도를 조절해서 보간한다
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir),Time.deltaTime * 0.8f);
        //start -------------------------------------end
        //this.transform.rotation         Quaternion.LookRotation(dir)
        //0-------------------------------------------1.0
        //0.1 이면 10만큼 와있는거임


        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * 0.03f);
        //rpg 몬스터같은거 만들 떄 따라다니도록 하는 데 사용한다

        //타겟을 중심으로 공전하는 함수
        this.transform.RotateAround(target.transform.position, Vector3.up, 10f * Time.deltaTime);
        //y축을 기준으로 내 오브젝트가 타겟을 주위로 돈다
        //또는 내가 임의로 벡터를 만들어서 할 수도 있음
        //this.transform.RotateAround(target.transform.position, new Vector3(1f,0f,1f), 10f * Time.deltaTime);


    }
}
