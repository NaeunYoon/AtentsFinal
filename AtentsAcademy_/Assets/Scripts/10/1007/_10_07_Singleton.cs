using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 ���ҽ�, �ν��Ͻ�, ���̺� : �� �������� ����

���Ŵ���, ���ӸŴ���, UI �Ŵ��� : ���� �÷�������
 
 
 
 
 */
public class _10_07_Singleton<T> where T : class, new() //���ʸ� ǥ��,
                                                        //singleton : ����ü ���� (�����ϰ� �ϳ��� �ν��Ͻ��� �����ϰ� �Ѵ�)
                                                        //T�� ���������̾���ϰ� �Ű������� ���� �����ڸ� Ȱ���ؾ� �Ѵ�
                                                        //where : T�� �������� : class�� ���������� �ǹ�
                                                        //new() :�Ű������� ���� �����ڸ� �ǹ�
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
