using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAlpha : MonoBehaviour
{   //����Ʈ �� �� ����
    List<GameObject> Alphalist = new List<GameObject>(); //���İ� ����� ����Ʈ
    List<GameObject> Recoverlist = new List<GameObject>();  //���İ� ����� ����Ʈ���� ������� �����ؾ��ϴ� ����Ʈ
    public GameObject player;
    void Start()
    {

    }
    // obj�� ���ĸ���Ʈ�� ���ԵǾ� �ִ��� �˻�
    public GameObject FindAlphalist(GameObject obj)
    {
        GameObject findObj = Alphalist.Find(o => (o.name == obj.name));
        return findObj;
    }
    public void AddAlplalist(GameObject obj)
    {
        GameObject alphaObj = FindAlphalist(obj);
        if (alphaObj == null)
        {
            Alphalist.Add(obj);
            Color col = obj.GetComponent<MeshRenderer>().material.color;
            col.a = 0.2f;
            obj.GetComponent<MeshRenderer>().material.color = col;
        }
    }
    private void LateUpdate()
    {
        Vector3 origin = Camera.main.transform.position;    //ī�޶󿡼� ĳ���͸� ���� ���̸� �߻���
        Vector3 dir = player.transform.position - Camera.main.transform.position;
        RaycastHit[] hits = Physics.RaycastAll(origin, dir.normalized); //�迭�� ����ȴ�
        if (hits.Length == 0)       //�ƹ��͵� �浹�� ���� ���¿��� ���ĸ� ����ġ�� ���� ���´�
                                    //(ī�޶� �ƹ��͵� ������ ���� ���� ����)
                                    
        {
            for (int i = 0; i < Alphalist.Count; i++)
            {
                Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                col.a = 1f;         //�����÷� ����
                Alphalist[i].GetComponent<MeshRenderer>().material.color = col;
            }
            Alphalist.Clear();
            return;//������� �������ְ� �������ش�
        }
        // ������ �浹�� ���ӿ�����Ʈ ��ü�� ����Ʈ�� ���� (���İ��� ����)
        for (int i = 0; i < hits.Length; i++)
        {
            AddAlplalist(hits[i].collider.gameObject);  //���İ��� ������ ���� ������Ʈ���� ����
        }
        // ��������
        // ���ĸ���Ʈ���� �������� ���

        //���߷����� ������ ����ĳ��Ʈ�� ���� �浹�� ������Ʈ�� �迭�� �ְ�, ����Ʈ�� ����
        //���� ����Ʈ�� �ִ� ���� ������Ʈ�� ���ؼ� ���� ���� �͸� ã��
        //���� ����Ʈ�� �����ִٴ� �ǹ̴�, �浹�� ���� ���� �����̱� ������ �����Ѵ�
        for (int i = 0; i < Alphalist.Count; i++)
        {
            GameObject tmp = null;
            for (int j = 0; j < hits.Length; j++)
            {
                try
                {
                    if (Alphalist[i].name == hits[j].collider.gameObject.name)
                    {
                        tmp = hits[j].collider.gameObject;
                    }
                }//���ĸ���Ʈ���� �������� �� �߰�
                catch (System.IndexOutOfRangeException )
                {
                    Debug.Log("i index = " + i);
                    Debug.Log("j index = " + j);
                }
            }

            if (tmp == null)
            {
                GameObject recoverObj = Recoverlist.Find(o => (o.name == Alphalist[i].name));   //Recoverlist�� ����
                if (recoverObj != null)
                    continue;

                Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                col.a = 1f;
                Alphalist[i].GetComponent<MeshRenderer>().material.color = col;
                //                Alphalist.Remove(Alphalist[i]);
                //                break;
                Recoverlist.Add(Alphalist[i]);
            }
        }
        // Recoverlist�� �ִ� ������Ʈ�� Alphalist���� ����
        int size = Recoverlist.Count;
        for (int i = 0; i < size; i++)
        {
            try
            {
                GameObject findObj = Alphalist.Find(o => (o.name == Recoverlist[i].name));
                if (findObj != null)
                {
                    Alphalist.Remove(findObj);
                }
            }
            catch (System.ArgumentOutOfRangeException )
            {
                Debug.Log("i index = " + i);
            }
        }
        Recoverlist.Clear();
    }
}

