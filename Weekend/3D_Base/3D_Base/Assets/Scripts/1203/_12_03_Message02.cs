using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_03_Message02 : MonoBehaviour
{

    void Start()
    {
        
    }
    public void Eat()
    {
        Debug.Log("Eat " + this.name + "(�θ�)");
    }

    void Update()
    {
        //SendMessage("Eat");       //���� ������Ʈ �ٸ� ������Ʈ�� ���� ��
        /*BroadcastMessage("Move");*/   //�ڽ� ������Ʈ�� �ϰ������� �޼��� ����
        /*BroadcastMessage("Eat",SendMessageOptions.RequireReceiver);*/ // ���� ��
        SendMessageUpwards("Eat");   //�θ����� ����
    }
}
