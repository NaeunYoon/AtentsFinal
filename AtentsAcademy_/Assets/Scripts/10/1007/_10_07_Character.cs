using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CHARACTER
{
    public string name;
    public byte classType;      //어떤클래스
}
public struct MONSTER
{
    public string name;
    public eBelong eBelong;
    public byte type;      //어떤클래스
}
public enum eBelong
{
    NONE = 0, COUNTRY1, COUNTRY2, COUNTRY3
}
public interface Iskill
{
    public void oneSkill();
    public void twoSkill();
    public void threeSkill();


}

public class _10_07_Character<T> : MonoBehaviour,Iskill       //스킬이 플레이어에게만 필요하다면 플레이어가 인터페이스를 상속
                                                              //하지만 플레이어와 몬스터 둘 다 스킬이 있기 떄문에 여기다 구현함
{//제너릭 변수를 사용해서 플레이어 직업 표현 (클래스 원형)

    public T data { get; set; }     //T정보는 사용할 때 결정할 수 있음(자료형), 수정가능하게 프로퍼티로 만듬, 상속받아도 상관없음 공개라서

 



    void Start()
    {
        
    }
    virtual public void oneSkill()  //virtual 추가 시 자식에서 오버라이드 (재정의) 할 수 있음. 나는 플레이어에서 재정의함
    {

    }
    virtual public void twoSkill()
    {

    }
    virtual public void threeSkill()
    {

    }

    void Update()
    {
        
    }
}
/*
 
 인터페이스는 반드시 구현해야하는 함수만을 선언한 자료형
 참조형 자료형으로 interface 선언
 함수 선언만 하고 정의는 안한다
 인터페이스는 객체를 생성할 수 없고 인터페이스 이름은 i로 시작한다
 인터페이스를 구현하는 클래스에서는 함수를 반드시 정의
 인터페이스는 상속이라고 안하고 구현한다고 한다
 인터페이스는 상속이 아니기 때문에 연이어서 인터페이스를 상속같은 방법으로 구현한다 (다중상속지원안되는 것이 c#이지만
 인터페이스는 상속이 아니기 때문에 여러개를 사용해도 상관 없다)
 인터페이스를 상속받은 클래스는 함수를 무조건 구현해야한다
 추상클래스 변수를 받을 수 있지만 인터페이스는 함수로만 구현된다
 플레이어 몬스터 다 스킬이 있음, 스킬의 개수도 동일하다면 부모에 인터페이스 선언
 
 */