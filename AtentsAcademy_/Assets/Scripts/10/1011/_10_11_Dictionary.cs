using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_11_Dictionary : MonoBehaviour
{
    /*
     Dictionary<Ű�� �ڷ���><���� �ڷ���> : Ű�� ���� �� ������ �ϴ� �ڷᱸ��(C#)
     Ű ���� ������ ���� Ư¡ ( Ű�� �ߺ��� �� ���� ), ���� �ϳ�(?
     ��ųʸ��� �̿��ϴ� ���� ��Ƽ���̴�
     */

    Dictionary<int, int> dic1;  //Ű : ����,
                                //�� : ����,
                                //���� : dic1

    Dictionary<float, int> dic2;    //Ű : �Ǽ�,
                                    //�� : ����,
                                    //���� : dic2
    Dictionary<string, string> dic3;    //Ű : ���ڿ�,
                                        //�� : ���ڿ�,
                                        //���� : dic3

    /*
    MultiMap : Ű�� �ش�Ǵ� ���� �������� ���
    Ű���� ������ ���� Ư¡. Ű �� �ϳ��� ���� ������( ������ Ű �ϳ��� �����ϴ� ���� �������� ��� )
    */

    Dictionary<int,List<int>> multiDict1;    //Ű�� ����, ���� ����Ʈ
    Dictionary<string, List<string>> multiDict2;    //Ű�� ���ڿ�, ���� ���ڿ��� �����ϴ� ������

    void Start()
    {
        dic1 = new Dictionary<int, int>();      //��ųʸ� ����� ���ؼ��� �Ҵ��� �ؾ���
        dic1.Add(0, 100);       //��ųʸ��� ����
        dic1.Add(1, 102);
        //���� ��������� Ű�� ���׵Ǵ� ���� ���
        int findValue;
        if(dic1.TryGetValue(0,out findValue))   //out Ű����� int ������ �״�� �����ϴ� ���� �ǹ�
                                                //(�Լ� �Ű��������� �����縦 ���� �ʴ´�)
        {
            //Ű�� �ش�Ǵ� ���� ������ ��� findValue ������ ���� ����
            Debug.Log(findValue);       //100 ����
        }
        Debug.Log(dic1[1]);

        dic2 = new Dictionary<float, int>();
        dic3= new Dictionary<string, string>();

        dic3.Add("ȫ", "�浿");
        dic3.Add("������", "123");
        string findValues;
        if(dic3.TryGetValue("ȫ", out findValues))
        {
            Debug.Log(findValues);
        }

        int d1 = 100;
        Test1(ref d1);

        int d2;
        Test2(out d2);
    }


    public void Test1(ref int data)     //ref : �Ҵ��� �Ǿ����� ��
    {
        Debug.Log(data);
    }

    public void Test2(out int _data)    //out : �Ҵ��� ���� ��
    {
        _data = 100;
        Debug.Log(_data);
    }

    void Update()
    {
        
    }
}
