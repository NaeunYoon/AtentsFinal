using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_11_Dictionary : MonoBehaviour
{
    /*
     Dictionary<키의 자료형><값의 자료형> : 키와 값을 한 쌍으로 하는 자료구조(C#)
     키 값은 유일한 것이 특징 ( 키는 중복될 수 없음 ), 값은 하나(?
     딕셔너리를 이용하는 것이 멀티맵이다
     */

    Dictionary<int, int> dic1;  //키 : 정수,
                                //값 : 정수,
                                //변수 : dic1

    Dictionary<float, int> dic2;    //키 : 실수,
                                    //값 : 정수,
                                    //변수 : dic2
    Dictionary<string, string> dic3;    //키 : 문자열,
                                        //값 : 문자열,
                                        //변수 : dic3

    /*
    MultiMap : 키에 해당되는 값이 여러개일 경우
    키값이 유일한 것이 특징. 키 값 하나에 값이 여러개( 유일한 키 하나에 대응하는 값이 여러개일 경우 )
    */

    Dictionary<int,List<int>> multiDict1;    //키는 정수, 값은 리스트
    Dictionary<string, List<string>> multiDict2;    //키는 문자열, 값은 문자열을 저장하는 리스느

    void Start()
    {
        dic1 = new Dictionary<int, int>();      //딕셔너리 사용을 위해서는 할당을 해야함
        dic1.Add(0, 100);       //딕셔너리에 저장
        dic1.Add(1, 102);
        //값을 가져오라면 키에 대항되는 값을 사용
        int findValue;
        if(dic1.TryGetValue(0,out findValue))   //out 키워드는 int 변수를 그대로 전달하는 것을 의미
                                                //(함수 매개변수에서 값복사를 하지 않는다)
        {
            //키에 해당되는 값이 존재할 경우 findValue 변수에 값이 저장
            Debug.Log(findValue);       //100 나옴
        }
        Debug.Log(dic1[1]);

        dic2 = new Dictionary<float, int>();
        dic3= new Dictionary<string, string>();

        dic3.Add("홍", "길동");
        dic3.Add("가나다", "123");
        string findValues;
        if(dic3.TryGetValue("홍", out findValues))
        {
            Debug.Log(findValues);
        }

        int d1 = 100;
        Test1(ref d1);

        int d2;
        Test2(out d2);
    }


    public void Test1(ref int data)     //ref : 할당이 되어있을 때
    {
        Debug.Log(data);
    }

    public void Test2(out int _data)    //out : 할당이 없을 때
    {
        _data = 100;
        Debug.Log(_data);
    }

    void Update()
    {
        
    }
}
