using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 리소스, 인스턴스, 테이블 : 씬 전역에서 관리

씬매니저, 게임매니저, UI 매니저 : 씬에 올려져야함
 
 
 
 
 */
public class _10_07_Singleton<T> where T : class, new() //제너릭 표현,
                                                        //singleton : 단일체 패턴 (유일하게 하나의 인스턴스만 생성하게 한다)
                                                        //T는 참조형식이어야하고 매개변수가 없는 생성자를 활용해야 한다
                                                        //where : T의 제약조건 : class는 참조형식을 의미
                                                        //new() :매개변수가 없는 생성자를 의미
{
    private static T inst;
    public static T instance
    {
        get
        {
            if(inst == null)
            {
                inst = new T();
            }    
            return inst;
        }
    }

    public _10_07_Singleton()
    {

    }
}
