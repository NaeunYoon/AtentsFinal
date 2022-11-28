using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

//����ȭ : �߻��� �ڷ����� ���尡���ϵ��� �������ִ� �۾�
[Serializable]
public class _11_25_Mob 
{

    [SerializeField] int index; //��������� serializefiled ����ؾ���
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
