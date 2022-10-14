using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class _10_07_Player : _10_07_Character<CHARACTER>
{   //플레이어의 직업이 여러 개 있을 수 있음
    
    void Start()
    {
        
    }
    override public void oneSkill()  //virtual 추가 시 자식에서 오버라이드 (재정의) 할 수 있음/ 부모클래스를 다시 정의함
                                     //오버로드와 오버라이드는 다름
    {

    }
    override public void twoSkill()
    {

    }
    override public void threeSkill()
    {

    }

    void Update()
    {
        
    }
}
