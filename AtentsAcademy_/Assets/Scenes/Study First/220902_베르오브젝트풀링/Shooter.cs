using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/**
 * 1. 마우스로 평면을 클릭하면, 해당 평면의 방향으로 ball을 발사한다.
 */
public class Shooter : MonoBehaviour
{
    public GameObject ball; //프리팹 ball

    private Vector3 ballDir;
    private Rigidbody ballRigidbody;

    private IObjectPool<ball> ballPool;

    private void Awake()
    {
        ballPool = new ObjectPool<ball>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, maxSize:20);  //이렇게 사용하는게 2021기능. 여기에 파라미터 모두 채워줘야된다.
    }
    private void Update()
    {
        // 눌러서 방향 정하게 하기
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            LayerMask layerMask = 1 << 7;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity ,layerMask))
            {
                ballDir = hitInfo.point.normalized;

                //ballRigidbody = Instantiate(ball, ballDir + Vector3.up, Quaternion.identity).GetComponent<Rigidbody>();   //오브젝트풀링으로 변경
                //var ball = ObjectPool.GetObject();  // 기존 Queue를 사용한 오브젝트 풀링
                //ballRigidbody = ball.GetComponent<Rigidbody>(); // 오브젝트 풀링 할 때 여기의 제어도 ball에게 모두 맡겨야된다.
                //ballRigidbody.velocity = ballDir;

                var ball = ballPool.Get();
                ball.transform.position = transform.position + ballDir;
                ball.Shooter(ballDir);
            }
        }
    }

    // 오브젝트 풀링 넣을 때 생성해야되는 인자
    //1. 생성해서 오브젝트 풀 지정(ball이 나중에 어디로 돌아올지 풀링객체 지정)
    private ball CreateBullet()
    {
        ball bullet = Instantiate(ball).GetComponent<ball>();
        bullet.SetManagedPool(ballPool);
        return bullet;
    }

    private void OnGetBullet(ball bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(ball bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(ball bullet)
    {
        Destroy(bullet.gameObject);
    }
}
