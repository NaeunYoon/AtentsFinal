using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_30_Barrack : MonoBehaviour
{
    //몇 초 마다 몬스터를 생성

    public float elapsed;
    public int barrackIndex;

    void Start()
    {
        
    }

    
    void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed > 4f)
        {
            elapsed -= 4f;
            GameObject creatMob = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            _09_30_Monster monsterComponent = creatMob.AddComponent<_09_30_Monster>();
            monsterComponent.END = new Vector3(transform.position.x, transform.position.y, 4f);
            monsterComponent.barrackIndex = barrackIndex;
            monsterComponent.moveSpeed = 1.5f;
            monsterComponent.tag = "Monster";
            monsterComponent.transform.position = transform.position;
        }
    }
}
