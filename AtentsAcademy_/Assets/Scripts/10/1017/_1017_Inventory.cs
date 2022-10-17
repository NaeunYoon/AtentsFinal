using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


public class _1017_Inventory : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IEndDragHandler
{
    public List<_1017_Slot> slotList;
    public Image selectedImage;
    int selectedSlotIndex;

    private int itemCount =1;
    public Text textCount;
    //public List<Text> textCount;

    void Start()
    {
        textCount = GetComponent<Text>();
        selectedSlotIndex = -1;
        selectedImage.gameObject.SetActive(false);
        itemCount = 1;
        textCount.text = ""+itemCount;

    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i]._icon.sprite != null)
            {
                if (slotList[i].isInRect(_eventData.position))
                {
                    selectedSlotIndex = i;
                    selectedImage.sprite = Resources.Load<Sprite>("Icon/" + slotList[i]._icon.sprite.name);   //���ҽ��̸� (�ε��ؼ� ����)
                    selectedImage.rectTransform.position = _eventData.position;
                    selectedImage.gameObject.SetActive(true);
                   
                }
            }
        }
    }
    public void OnDrag(PointerEventData _eventData)
    {
        if (selectedSlotIndex != -1) //�۾����� ������ ���ٸ�
        {
            selectedImage.rectTransform.position = _eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (selectedSlotIndex == -1) //�۾����� ������ ���ٸ� ����
        {
            return;
        }

        //�������� ���� �������� ��*

        for (int i = 0; i < slotList.Count; i++)  //���� ������ŭ ��������
        {
            if (slotList[i].isInRect(eventData.position))  // ����
            {

           

                if (slotList[i]._icon.sprite == null)
                {    
                    //?
                    slotList[i]._icon.gameObject.SetActive(true);  
                    slotList[i]._icon.sprite = Resources.Load<Sprite>("Icon/" + slotList[selectedSlotIndex]._icon.sprite.name);

                    slotList[selectedSlotIndex]._icon.sprite = null;
                    slotList[selectedSlotIndex]._icon.gameObject.SetActive(false);

                }
                else
                {
                    //������ ä���� ���� ��� �� �������� ��ȯ),,�ε��ؿ�? ��ȯ���ϳ� ��¥������

                    string tmpName = slotList[i]._icon.sprite.name;    //���콺 �� ���� ������ �־��ֱ�
                    slotList[i]._icon.sprite = Resources.Load<Sprite>("Icon/" + slotList[selectedSlotIndex]._icon.sprite.name);
                    //���� �� ó���� ������ ���� �������� �巡�� �� �����ٰ� �ε�����
                    slotList[selectedSlotIndex]._icon.sprite = Resources.Load<Sprite>(tmpName);
              

                }
                selectedImage.sprite = null;
                selectedImage.gameObject.SetActive(false);
                selectedSlotIndex = -1;
                return; //���� �ȿ����� ������ �̷�� ���ٸ�, ...

            }
        }
        //�����ۿ� �ִ� ���
        selectedImage.sprite = null; //�� ����ٴϴ� ������ ���ֱ�
        selectedImage.gameObject.SetActive(false);
        selectedSlotIndex = -1;//????????







        //�� ����ֳ�..���ڱ�...;

        //���� �ۿ��� �������� ���..
    }

    public void OnPointerUp(PointerEventData eventData)
    {


        if(selectedSlotIndex == -1)  //����ִ� ������ ��� �Ʒ��� �ڵ带 �������� �ʾƵ� �ȴ�
        {
            return;
        }

        

        //selectedIcon.gameObject.SetActive(false);


        int tmpIconIndex = -1;

        for (int i = 0; i < slotList.Count; i++)   //���� ��ġ��!
        {
            if (slotList[i].isInRect(eventData.position))
            {
                if(slotList[i]._icon.sprite.name == selectedImage.sprite.name)
                    {
                        Debug.Log("�������̶� ������ �̹����� ����");
                        itemCount++;
                        //textCount.text = itemCount.ToString();
                        textCount.text = " " + itemCount;

                }
                tmpIconIndex = i;
                break;
            }
            
        }

        if (tmpIconIndex != -1 && tmpIconIndex == selectedSlotIndex)    //���� �� ���� Ŭ������ ��   
        {
            selectedImage.sprite = null;
            selectedImage.gameObject.SetActive(false);
            selectedSlotIndex = -1;
        }

        

    }




    void Update()
    {
        
    }
}
