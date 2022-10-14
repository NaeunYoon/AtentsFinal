using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/**
 * 오브젝트 풀링이 2021버전에 정식기능으로 채택됨.
 */
public class ball : MonoBehaviour
{
    private Vector3 ballDir;
    private IObjectPool<ball> managedPool;
    
    public void SetManagedPool(IObjectPool<ball> pool)
    {
        managedPool = pool;
    }

    public void Shooter(Vector3 dir)
    {
        ballDir = dir;
        Invoke("DestoryBall", 5);
    }

    private void DestoryBall()
    {
        //Destroy(gameObject);
        //ObjectPool.ReturnObject(this);
        managedPool.Release(this);
    }

    private void Update()
    {
        transform.Translate(ballDir * Time.deltaTime);
    }
}
