using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_03_GetComponentTest : MonoBehaviour
{
    // 전역으로 사용할 경우에는 클래스 안에서 선언해주고 awake에서 초기화해준다

    private _12_03_Attack _attack;


    //만약에 한 오브젝트에 똑같은 스크립트가 많다면??
    //여러개니까 배열로 받아야 한다.
    private _12_03_Attack[]  _attacks;

    private void Awake()
    {
        _attack = GetComponent<_12_03_Attack>();    //가장 위에있는 하나만 가져온다

        _attacks = GetComponents<_12_03_Attack>(); //같은 오브젝트 안에 있는 같은 컴포넌트들을 모두 가져온다
        foreach(var attack in _attacks)
        {
            Debug.Log("----------------------");
            attack.Attack();
            attack.Defence();
            attack.Run();
        }

    }
    void Start()
    {
        //1번 방법
        var attack = this.GetComponent<_12_03_Attack>();
        
        _12_03_Attack attack2 = this.GetComponent<_12_03_Attack>();

        /*
         겟 컴포넌트가 어택 컴포넌트를 갖고옴
        이미 오브젝트에 a컴포넌트가 있고, 다른 컴포넌트(b)에서 a컴포넌트를 불러와서 사용한다.
        같은 오브젝트 상의 컴포넌트를 불러올 떄 사용한다 (빈번하게 사용함)
         */

        attack.Attack();
        attack.Defence();
        attack.Run();

        //2번방법 이렇게 사용할 수 있음
        this.GetComponent<_12_03_Attack>().Attack();
        this.GetComponent<_12_03_Attack>().Defence();
        this.GetComponent<_12_03_Attack>().Run();

        //3번방법 : 함수 안에서만 사용하는게 아니라면, 멤버필드로 선언해서 사용한다 ( 다른 함수에서 사용 가능) 
        _attack.Attack();
        _attack.Run();
        _attack.Defence();


        /*getComponent는 무거운 함수라서 빈번하게 호출할 경우에는 1번처럼 쓴다
         가끔 호출하는 경우에는 2번방법을 사용한다.
         멤버필드로 사용할 경우에는 3번 방법을 사용한다.
         */
    }

    // Update is called once per frame
    void Update()
    {
        _attack.Attack();
        
    }
}
