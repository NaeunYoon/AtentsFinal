using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool uniqueInstance;
    public static ObjectPool s_instance { get { return uniqueInstance; } }

    [SerializeField] private GameObject poolingOjbectPrefab;
    private Queue<ball> poolingObjectsQueue = new Queue<ball>(); // 순서대로 출력하게 하기 위함

    private void Awake()
    {
        uniqueInstance = this;
    }

    private void Start()
    {
        //Initialize(10); // 처음에 10개 만들어두기
    }

    private ball CreateNewObject()
    {
        var newObj = Instantiate(poolingOjbectPrefab, transform).GetComponent<ball>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectsQueue.Enqueue(CreateNewObject());
        }
    }

    public static ball GetObject()
    {
        // 빌려줄 수 있는 오브젝트가 1개라도 있으면
        if (ObjectPool.s_instance.poolingObjectsQueue.Count > 0)
        {
            var obj = s_instance.poolingObjectsQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = s_instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    // 돌려받을 게임오브젝트 처리 - 돌려받을 때 위치 초기화 해야됨.
    public static void ReturnObject(ball ball)
    {
        ball.transform.SetParent(s_instance.transform);
        ball.gameObject.transform.localPosition = Vector3.up;
        ball.gameObject.SetActive(false);
        s_instance.poolingObjectsQueue.Enqueue(ball);
    }
}
