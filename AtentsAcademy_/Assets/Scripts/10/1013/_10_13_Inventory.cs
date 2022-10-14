using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class _10_13_Inventory : MonoBehaviour,IPointerDownHandler, IDragHandler,IPointerUpHandler,IEndDragHandler
{

    public List<_10_13_Slot> slotList;     //������Ʈ Ÿ������ ����Ʈ�� ����
    public Image selectedIcon;      //������ ������ �̵��ϴ� ������
    private int selectedSlotIndex;       //������ ������ ����Ʈ �ε���
    private void Awake()
    {
        selectedSlotIndex = -1;
     //slotList = new List<_10_13_Slot>();


    }
    void Start()
    {
        selectedIcon.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        
        //foreach(_10_13_Slot one in slotList)
        for(int i = 0; i< slotList.Count;i++)
        {
            if (slotList[i].uiIcon.sprite != null)
            {
                if (slotList[i].isInRect(_eventData.position))
                {
                    selectedSlotIndex = i;
                    selectedIcon.sprite = Resources.Load<Sprite>("Icon/"+ slotList[i].uiIcon.sprite.name);   //���ҽ��̸� (�ε��ؼ� ����)
                    selectedIcon.rectTransform.position = _eventData.position;
                    selectedIcon.gameObject.SetActive(true);
                    Debug.Log("���ý���"+ slotList[i].gameObject.name);     //������ ����
                }   
            }
        }
    }

    public void OnDrag(PointerEventData _eventData) //�ݺ��� �� �巡�װ� ���⋚���� ���!
    {
        if(selectedSlotIndex != -1) //�۾����� ������ ���ٸ�
        {
            selectedIcon.rectTransform.position = _eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData _eventData)  //�巡�� ���� �� ȣ��
    {
        
        if (selectedSlotIndex == - 1) //�۾����� ������ ���ٸ� ����
        {
            return;
        }

        //�������� ���� �������� ��*

        for (int i = 0; i < slotList.Count; i++)  //���� ������ŭ ��������
        {
            if (slotList[i].isInRect(_eventData.position))  // ������������ ���Կ����̸� ����
            {

                //������ ������� ��� ..?������..������...���̵�...�� ���̵� ������;; �����֤����� ���� ����ͤ�
               
                if (slotList[i].uiIcon.sprite == null) {    //������ ������� �̹����� �ִµ� sprite�� ����
                    //���ο� �������� �ҷ��� ���� �ε��ؼ� ���� (���� �÷����� �������� ������)
                    //?
                    slotList[i].uiIcon.gameObject.SetActive(true);  //�������� �����ϱ�..�ε��ؼ�...���Կ� �־��ְ� Ȱ��ȭ����..��...���µ� ��..
                                                                    //��Ȱ��ȭ �� ���� ���µ� ���� Ȱ��ȭ�������
                    slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[selectedSlotIndex].uiIcon.sprite.name);
                    //���� �巡�� ���� ������ �ִ� ���� = ���� �� ÷�� ������ ���� ������ �̸� ��������
                    slotList[selectedSlotIndex].uiIcon.sprite = null;
                    slotList[selectedSlotIndex].uiIcon.gameObject.SetActive(false);
                    //
                    //selectedIcon.sprite = null;//�־ȴ� �Ȱ�����;;;; �Ȱ�����..
                    //selectedIcon.gameObject.SetActive(false);
                    //selectedSlotIndex = -1; //���ȶ��ϳ�;;
                    //���� �ʹ� �ò�������
                }
                else
                {
                    //������ ä���� ���� ��� �� �������� ��ȯ),,�ε��ؿ�? ��ȯ���ϳ� ��¥������

                    string tmpName = slotList[i].uiIcon.sprite.name;    //���콺 �� ���� ������ �־��ֱ�
                    slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/"+slotList[selectedSlotIndex].uiIcon.sprite.name); 
                    //���� �� ó���� ������ ���� �������� �巡�� �� �����ٰ� �ε�����
                    slotList[selectedSlotIndex].uiIcon.sprite = Resources.Load<Sprite>(tmpName);
                    //���콺 �� ���� ������ ������ �� ó���� Ŭ���Ѱ��� �־��� 
                    //
                    //selectedIcon.sprite = null;
                    //selectedIcon.gameObject.SetActive(false);
                    //selectedSlotIndex = -1;
                    
                }
                selectedIcon.sprite = null;
                selectedIcon.gameObject.SetActive(false);
                selectedSlotIndex = -1;
                return; //���� �ȿ����� ������ �̷�� ���ٸ�, ...
                
            }
        }
        //�����ۿ� �ִ� ���
        selectedIcon.sprite = null; //�� ����ٴϴ� ������ ���ֱ�
        selectedIcon.gameObject.SetActive(false);
        selectedSlotIndex = -1;//????????







        //�� ����ֳ�..���ڱ�...;

        //���� �ۿ��� �������� ���..


    }
    
    public void OnPointerUp(PointerEventData _eventData) // ��� ���Կ��� �´��� ã��
    {
        if(selectedSlotIndex == -1)  //����ִ� ������ ��� �Ʒ��� �ڵ带 �������� �ʾƵ� �ȴ�
        {
            return;
        }

        //selectedIcon.gameObject.SetActive(false);


        int tmpIconIndex = -1;

        for(int i=0; i < slotList.Count; i++)   //���� ��ġ��!
        {
            if (slotList[i].isInRect(_eventData.position))
            {
                tmpIconIndex = i;
                break;
            }
        }

        if(tmpIconIndex != -1 && tmpIconIndex == selectedSlotIndex)    //���� �� ���� Ŭ������ ��   
        {
            selectedIcon.sprite = null;
            selectedIcon.gameObject.SetActive(false);
            selectedSlotIndex = -1;
        }
    }

    void Update()
    {
        
    }
}
