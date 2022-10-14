using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_04_Obj_Pooling : MonoBehaviour
{
    /*
     ������Ʈ Ǯ�� ��� : ���ӿ�����Ʈ�� �����ϰ� ������ �� �߻��ϴ� ������带 ���̴� ���
                          �ѹ� ������ ���� ������Ʈ�� �����ϱ� ���� Ǯ�� �̿��Ѵ�

     �����ϱ� ���� ��� : ���� ��� ��Ȱ��ȭ�� �̿��Ͽ� Ǯ�� �����ϰ�, 
                            �����ؾ� �� ���� ������Ʈ�� Ǯ���� �˻��Ͽ� Ȱ��ȭ���� ���
                            ���� ��� ��Ȱ��ȭ, ���� �� Ȱ��ȭ, Ȱ��ȭ �� ���� ������Ʈ�� ���� ��� ����

     �ʿ��� ���� : ������ ���� ������Ʈ�� ������ �ڷᱸ�� (List)
                   List<GameObject> moblist;
                   �׷��� ���Ϳ� ������Ʈ Ǯ�� ����� �����ϰ��� �Ѵٸ� ������Ʈ �������� ����Ʈ�� �����ؾ� �Ѵ�
                   (GetComponent �Լ��� ������� �ʱ� ����) => List<Monster> moblist;
     
     
     */

    List<Monster> moblist;                              //1. ��ũ��Ʈ Ÿ���� �����ϵ��� ������
    //Ȱ��ȭ �� ���ӿ�����Ʈ�� �����ϴ� ����Ʈ
    //��Ȱ��ȭ �� ���� ������Ʈ�� �����ϴ� ����Ʈ�� ���ÿ� ����Ͽ� ����/���� �� ���� ����

    private void Awake()
    {
        moblist = new List<Monster>();                  //2. �ʱ�ȭ
    }
    void Start()
    {
        string name = string.Empty;
        for(int i = 0; i < 10; i++)
        {
            name = "Meshtint Free Knight_" + i.ToString();
            Monster monstrtScript = CreateMonster(name);
            //ȭ�鿡 �����ϴ� ���� ������Ʈ �̸��� �����ϱ� ������ �ٲ��ش�
            monstrtScript.gameObject.name = "Meshtint Free Knight_" + i.ToString();
            //������ ������ �̸��� ��ġ�� ����
            monstrtScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
        
    }

    public Monster CreateMonster(string _name)                      //3. ���� ���� �Լ�
    {
        Monster monsterScript = moblist.Find(o => (/*o.gameObject.name.Equals(_name)&& */o.gameObject.activeSelf==false));  
        //��Ȱ��ȭ �� ������Ʈ�� �����ϸ� ������ �����ͼ� Ȱ��ȭ
        //����Ʈ���� �����ϰ��� �ϴ� ���ӿ�����Ʈ�� �̸��� ������ ���ӿ�����Ʈ �˻� && ��Ȱ��ȭ �� ���ӿ�����Ʈ�� �˻�

        if(monsterScript != null)   //ã���� �ϴ�(����� �� �ִ�) ���Ͱ� ������ ���� -> ����Ʈ���� �˻��� ������Ʈ�� ���� (Ȱ��ȭ)
        {
            monsterScript.gameObject.SetActive(true); 
            return monsterScript;
        }
        else                       //���� ��������� �ϴ� ���, ���ҽ��Ŵ��� Ŭ������ ����Ͽ� �ʿ��� ���ҽ� �ε�
        {
            int pos = name.IndexOf("_");
            string rcName = name.Substring(0,_name.Length - (_name.Length- pos));

           GameObject rcMonster= Resources.Load<GameObject>(rcName);
           GameObject monsterObj = Instantiate<GameObject>(rcMonster);      //�ε��� ���ҽ��� �ν��Ͻÿ���Ʈ
            Monster newMonsScr = monsterObj.AddComponent<Monster>();        //������ ������Ʈ�� ��ũ��Ʈ �߰�
            moblist.Add(newMonsScr);                                        //����Ʈ�� ����
            return newMonsScr;                                              //���� ������ ��ũ��Ʈ ��ȯ
        }
    }
    public void DisableMonster(string _name)     //�̸��� �Ű������� ���޹޾Ƽ� �� �̸��� ���͸� �˻�, ȭ�鿡 Ȱ��ȭ�� ���¿��� �Ѵ�
    {
        Monster monsterScript = moblist.Find(o => (o.gameObject.name.Equals(_name) && o.gameObject.activeSelf == true));

        if(monsterScript != null)
        {
                 monsterScript.gameObject.SetActive(false);      //��Ȱ��ȭ
        }
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    
        {
            string name = "Meshtint Free Knight_" + Random.Range(0, 10).ToString();
            DisableMonster(name);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            string name = "Meshtint Free Knight_" + Random.Range(0, 10).ToString();
            Monster monstrtScript = CreateMonster("Meshtint Free Knight");
            monstrtScript.gameObject.name = "Monster";
            monstrtScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
    }
}
