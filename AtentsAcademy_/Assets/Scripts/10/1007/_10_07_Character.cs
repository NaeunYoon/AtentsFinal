using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CHARACTER
{
    public string name;
    public byte classType;      //�Ŭ����
}
public struct MONSTER
{
    public string name;
    public eBelong eBelong;
    public byte type;      //�Ŭ����
}
public enum eBelong
{
    NONE = 0, COUNTRY1, COUNTRY2, COUNTRY3
}
public interface Iskill
{
    public void oneSkill();
    public void twoSkill();
    public void threeSkill();


}

public class _10_07_Character<T> : MonoBehaviour,Iskill       //��ų�� �÷��̾�Ը� �ʿ��ϴٸ� �÷��̾ �������̽��� ���
                                                              //������ �÷��̾�� ���� �� �� ��ų�� �ֱ� ������ ����� ������
{//���ʸ� ������ ����ؼ� �÷��̾� ���� ǥ�� (Ŭ���� ����)

    public T data { get; set; }     //T������ ����� �� ������ �� ����(�ڷ���), ���������ϰ� ������Ƽ�� ����, ��ӹ޾Ƶ� ������� ������

 



    void Start()
    {
        
    }
    virtual public void oneSkill()  //virtual �߰� �� �ڽĿ��� �������̵� (������) �� �� ����. ���� �÷��̾�� ��������
    {

    }
    virtual public void twoSkill()
    {

    }
    virtual public void threeSkill()
    {

    }

    void Update()
    {
        
    }
}
/*
 
 �������̽��� �ݵ�� �����ؾ��ϴ� �Լ����� ������ �ڷ���
 ������ �ڷ������� interface ����
 �Լ� ���� �ϰ� ���Ǵ� ���Ѵ�
 �������̽��� ��ü�� ������ �� ���� �������̽� �̸��� i�� �����Ѵ�
 �������̽��� �����ϴ� Ŭ���������� �Լ��� �ݵ�� ����
 �������̽��� ����̶�� ���ϰ� �����Ѵٰ� �Ѵ�
 �������̽��� ����� �ƴϱ� ������ ���̾ �������̽��� ��Ӱ��� ������� �����Ѵ� (���߻�������ȵǴ� ���� c#������
 �������̽��� ����� �ƴϱ� ������ �������� ����ص� ��� ����)
 �������̽��� ��ӹ��� Ŭ������ �Լ��� ������ �����ؾ��Ѵ�
 �߻�Ŭ���� ������ ���� �� ������ �������̽��� �Լ��θ� �����ȴ�
 �÷��̾� ���� �� ��ų�� ����, ��ų�� ������ �����ϴٸ� �θ� �������̽� ����
 
 */