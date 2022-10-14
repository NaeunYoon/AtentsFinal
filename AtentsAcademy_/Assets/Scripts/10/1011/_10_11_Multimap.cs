using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_11_Multimap<Tkey, TValue> //모노비해비어를 상속받을 이유가 없음(제너릭 표현) : 외부에서 자료형을 사용 시 결정
{
    
    public Dictionary<Tkey, List<TValue>> dic;      //데이터 추가

    public _10_11_Multimap()
    {
        dic = new Dictionary<Tkey, List<TValue>>();     //생성자 추가
    }

    public void Add(Tkey key, TValue val)
    {

        List<TValue> list;      //키가 존재할 경우와 그렇지 않은 경우를 구분
        if(dic.TryGetValue(key, out list))
        {
            dic[key].Add(val);  //키가 존재한다면 값이 리스트에 저장
        }
        else
        {
            list = new List<TValue>();      //키가 존재하지 않는다면 리스트를 생성하고 리스트에 추가한다
                                           //그리고 리스트를 딕셔너리에 저장한다
            list.Add(val);
            dic.Add(key, list);
        }
    }
    public List<TValue>GetData(Tkey key)        //키에 해당되는 값을 반환 (반환 타입이 리스트임)
    {
        List<TValue> list;
        if(dic.TryGetValue(key, out list))
        {
            return list;
        }
        else
        {
            return null;
        }
    }
}
