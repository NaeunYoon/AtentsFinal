using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate int Do(int _a);                              //��ȯ������ int�̰� �Ű������� �ִ� ��������Ʈ ����
public delegate void DoN();                                   //��ȯ������ ���� �Ű����������� ��������Ʈ ����
public delegate void DoV();

public class _09_08_Ramda : MonoBehaviour
{
    /*
     ���ٽ�(Lamda) 
    => �����ڴ� ���ٽ��� ǥ���� �� ���
    => �����ڸ� �������� ������ �Ű������� �ǹ�, �������� ���̳� �� ����� �ǹ�
    ����޼ҵ�� ����ϰ� ���ȴ� (�Լ� �̸��� ���� �Լ�)
    �� ����(�����θ� ����)�� �� ����(�߰�ȣ�� ��������)�� �����ȴ�
    �� ���ٴ� ����� ��ȯ���������� �� ���ٴ� ���� ������ ����ؾ߸� ��ȯ�� �ȴ�
    ���ٸ� ����� ���� �ڷ��� ������ ���� �ʴ´� (int, float..)

                            �Ű������� ���� �� ����. x�� ��� =>���� �ȵ�. ��ȯŸ���� void �� ������ �Ұ���
                            () => x*x;

    �Ű������� �ִ� �� ����
    (x) => x*x;

    �Ű������� ���� �� ����
    ()=>{};

                            �Ű������� �ִ� �� ����
                            (x)=>{};
     
     
     */

    Do doSomething;         //2.��������Ʈ�� ������� ����(�Ű������� �����̸� ��ȯ������ ������ �Լ� ����)
    DoN doSomethingN;
    DoV doSomethingV;
    void Start()
    {
        //���ٽ��� �̿��Ͽ� �Լ��� �����ϰ� ����

        doSomething = (o) => o * o;     //�Ű������� ���ؼ� ��ȯ�ϴ� �Լ��� doSomething. �� ���ٴ� ��ȯ�Ѵ� Do �� ������� doSomething
        //doSomething�� ���ٽ����� ������ �Լ��� ������ ����
        int result = doSomething(4);
        Debug.Log("��� = "+result);

        /*doSomethingN = () => 2 * 2;*/     //��� * ����� ��ȯ�Ѵٴ� ��. ��ȯŸ���� void �̱� ������ ������ �ȵ�
                                            //��������Ʈ ������ void ���� int �� �ٲ���� ��


        doSomethingV = () => Debug.Log("123");      //��ȯŸ���� void �̱� ������ ���� ����

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


        List<int> list = new List<int>();                   //����Ʈ ���ٽ�
        for(int i = 0; i < 10; i++)
        {
            list.Add(i);
        }
        list.Find(o => o.Equals(99));                       //99��� ���� ���ο� �ִ���
        list.Find(o => o==99);                              //���� �ǹ� (�� ����)
                                                            //Find �Լ��� ��ȯ������ ����
        var tmp = list.Find(o => o == 99);                  //�� ������ �����Ͱ� ����� ����Ʈ���� ���ϴ� �����͸� ��ã���� ��쿡 0 ����
                                                            //���� 0�� ����Ʈ�� �ִ� �����Ͷ�� ������ �� ���� ( �ִ��� ������ )
        Debug.Log(tmp);

        int? temp = list.Find(o => o == 99);                //nullable �������� �ص� 0���� ����
        if (temp.HasValue)
        {
            Debug.Log(temp);
            Debug.Log(temp.Value);
        }
        else
        {
            Debug.Log("������ ����");
        }

        int? findData = FindData(list, 99);
        if (findData.HasValue)
        {
            Debug.Log(findData);
            Debug.Log(findData.Value);
        }
        else
        {
            Debug.Log("������ ����");
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


    public void Test1(Do _dosomething) //��������Ʈ�� ����
    {
       int result =  _dosomething(2);
        Debug.Log(result);
    }
    public void Test2(Do _dosomething, int _arg) //��������Ʈ�� ����
    {
        int result = _dosomething(_arg);
        Debug.Log(result);
    }


    void Update()
    {
        
    }
}
