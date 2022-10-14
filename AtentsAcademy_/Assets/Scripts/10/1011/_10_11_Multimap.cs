using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_11_Multimap<Tkey, TValue> //�����غ� ��ӹ��� ������ ����(���ʸ� ǥ��) : �ܺο��� �ڷ����� ��� �� ����
{
    
    public Dictionary<Tkey, List<TValue>> dic;      //������ �߰�

    public _10_11_Multimap()
    {
        dic = new Dictionary<Tkey, List<TValue>>();     //������ �߰�
    }

    public void Add(Tkey key, TValue val)
    {

        List<TValue> list;      //Ű�� ������ ���� �׷��� ���� ��츦 ����
        if(dic.TryGetValue(key, out list))
        {
            dic[key].Add(val);  //Ű�� �����Ѵٸ� ���� ����Ʈ�� ����
        }
        else
        {
            list = new List<TValue>();      //Ű�� �������� �ʴ´ٸ� ����Ʈ�� �����ϰ� ����Ʈ�� �߰��Ѵ�
                                           //�׸��� ����Ʈ�� ��ųʸ��� �����Ѵ�
            list.Add(val);
            dic.Add(key, list);
        }
    }
    public List<TValue>GetData(Tkey key)        //Ű�� �ش�Ǵ� ���� ��ȯ (��ȯ Ÿ���� ����Ʈ��)
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
