using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

//직렬화 : 추상의 자료형을 저장가능하도록 변경해주는 작업
[Serializable]
public class _11_25_Mob 
{

    [SerializeField] int index; //멤버변수에 serializefiled 사용해야함
    [SerializeField] string name;

    public int INDEX
    {
        get { return index; }
        set { index = value; }
    }

    public string NAME
    {
        get { return name; }
        set { name = value; }
    }
    
    public _11_25_Mob()
    {

    }

    public _11_25_Mob(int _index, string _name)
    {
        index = _index;
        name = _name;   
    }

    //[Serializable]

    public class Serialization<T>
    {
        [SerializeField] List<T> _t;

        public List<T> ToList() { return _t; }
        public Serialization(List<T> _tmp)
        {
            _t = _tmp;
        }
    }
}
