using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class _10_14_Shop : MonoBehaviour
{
    /*
     ���������� �������� �ٷ�� ���!
     �������� �������� �߰��ϰ� ����.
     ������ ������ �����۵��� �����ϴµ�...
     �������� �ϳ� �� �߰�...�ϸ� �������� �Ʒ��� �پ����
     ������ ������ �þ����
     
    ��...!Contents Size �þ;;
    Vertical Fit > prefferred
     
    �����̸� �ε��ؼ� ��� �߰��ϳ�
    ��� �������� �������� �߰��ϳ�..
    ����ִ� ui�� ����..��Ȱ��ȭ

    �ϳ� �÷����� ��Ȱ��ȭ�ϰ� �� ���� ������ �����ؼ� ���
    (������ ����� �� ���� ..����)


     */

    /*public GameObject itemSrc;*/  //1. ������ ���� (��Ȱ��ȭ�Ѱ� �־��� : ������)

    public ScrollRect scrollRect;   //3

    public _10_14_Item itemRrc;

    //-----------------------------------------------------------���� ������ ������
    //public Transform itemParentTransform;
    //private List<_10_14_Item> itemList = new List<_10_14_Item>();
    //private Sprite[] itemSpriteList;

    void Start()
    {
        //��Ȱ��ȭ �� �����ν��Ͻ��� ������......
        //��մ°� �����ٱ��?
        //GameObject newItem = Instantiate<GameObject>(itemRrc);
        //itemSpriteList = Resources.LoadAll<Sprite>("icon/"); //������?
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
             GameObject newItem = Instantiate<GameObject>(itemRrc.gameObject); //2.
             newItem.SetActive(true);//4
             newItem.transform.SetParent(scrollRect.content);

        }
    }
}
