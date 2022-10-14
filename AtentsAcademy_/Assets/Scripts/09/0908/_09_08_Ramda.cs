using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate int Do(int _a);                              //반환형식이 int이고 매개변수가 있는 델리게이트 선언
public delegate void DoN();                                   //반환형식이 없고 매개변수가없는 델리게이트 선언
public delegate void DoV();

public class _09_08_Ramda : MonoBehaviour
{
    /*
     람다식(Lamda) 
    => 연산자는 람다식을 표현할 때 사용
    => 연산자를 기준으로 왼쪽은 매개변수를 의미, 오른쪽은 식이나 문 블록을 의미
    무명메소드와 비슷하게 사용된다 (함수 이름이 없는 함수)
    식 람다(식으로만 구성)와 문 람다(중괄호로 구분지음)로 구성된다
    식 람다는 결과를 반환시켜주지만 문 람다는 리턴 구문을 사용해야만 반환이 된다
    람다를 사용할 떄는 자료형 선언을 하지 않는다 (int, float..)

                            매개변수가 없는 식 람다. x는 상수 =>성립 안됨. 반환타입이 void 라 리턴이 불가능
                            () => x*x;

    매개변수가 있는 식 람다
    (x) => x*x;

    매개변수가 없는 문 람다
    ()=>{};

                            매개변수가 있는 문 람다
                            (x)=>{};
     
     
     */

    Do doSomething;         //2.델리게이트형 멤버변수 선언(매개변수가 정수이며 반환형식이 정수인 함수 대입)
    DoN doSomethingN;
    DoV doSomethingV;
    void Start()
    {
        //람다식을 이용하여 함수를 정의하고 대입

        doSomething = (o) => o * o;     //매개변수를 곱해서 반환하는 함수가 doSomething. 식 람다는 반환한다 Do 형 멤버변수 doSomething
        //doSomething은 람다식으로 정의한 함수의 구문을 실행
        int result = doSomething(4);
        Debug.Log("결과 = "+result);

        /*doSomethingN = () => 2 * 2;*/     //상수 * 상수를 반환한다는 뜻. 반환타입이 void 이기 때문에 대입이 안됨
                                            //델리게이트 선언을 void 에서 int 로 바꿔줘야 함


        doSomethingV = () => Debug.Log("123");      //반환타입이 void 이기 때문에 실행 가능

        doSomething = (x) => 
        {
            int result = x * x+100;
            return result;
        
        
        };
        result = doSomething(2);
        Debug.Log(result);


        Test1(doSomething = (x) =>
        {
            int result = x * x + 100;
            return result;
        });

        Test2(doSomething,2);


        List<int> list = new List<int>();                   //리스트 람다식
        for(int i = 0; i < 10; i++)
        {
            list.Add(i);
        }
        list.Find(o => o.Equals(99));                       //99라는 값이 내부에 있는지
        list.Find(o => o==99);                              //같은 의미 (식 람다)
                                                            //Find 함수의 반환형식은 정수
        var tmp = list.Find(o => o == 99);                  //값 형식의 데이터가 저장된 리스트에서 원하는 데이터를 못찾았을 경우에 0 리턴
                                                            //만약 0이 리스트에 있는 데이터라면 구분할 수 없음 ( 있는지 없는지 )
        Debug.Log(tmp);

        int? temp = list.Find(o => o == 99);                //nullable 형식으로 해도 0으로 나옴
        if (temp.HasValue)
        {
            Debug.Log(temp);
            Debug.Log(temp.Value);
        }
        else
        {
            Debug.Log("데이터 없음");
        }

        int? findData = FindData(list, 99);
        if (findData.HasValue)
        {
            Debug.Log(findData);
            Debug.Log(findData.Value);
        }
        else
        {
            Debug.Log("데이터 없음");
        }
    }


    public int? FindData(List<int> _list, int _findData)
    {
        foreach(int one in _list)
        {
            if(one.Equals(_findData))
            {
                return one;
            }
        }return null;
    }


    public void Test1(Do _dosomething) //델리게이트가 전달
    {
       int result =  _dosomething(2);
        Debug.Log(result);
    }
    public void Test2(Do _dosomething, int _arg) //델리게이트가 전달
    {
        int result = _dosomething(_arg);
        Debug.Log(result);
    }


    void Update()
    {
        
    }
}
