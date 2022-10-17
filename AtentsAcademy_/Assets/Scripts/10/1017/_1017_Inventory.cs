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
                    selectedImage.sprite = Resources.Load<Sprite>("Icon/" + slotList[i]._icon.sprite.name);   //리소스이름 (로드해서 대입)
                    selectedImage.rectTransform.position = _eventData.position;
                    selectedImage.gameObject.SetActive(true);
                   
                }
            }
        }
    }
    public void OnDrag(PointerEventData _eventData)
    {
        if (selectedSlotIndex != -1) //작업중인 슬롯이 없다면
        {
            selectedImage.rectTransform.position = _eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (selectedSlotIndex == -1) //작업중인 슬롯이 없다면 리턴
        {
            return;
        }

        //내려놓는 곳의 아이템을 비교*

        for (int i = 0; i < slotList.Count; i++)  //슬롯 갯수만큼 돌려봤음
        {
            if (slotList[i].isInRect(eventData.position))  // 내려
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
                    //슬롯이 채워져 있을 경우 두 아이템을 교환),,로드해요? 교환안하네 개짜ㅏ증나

                    string tmpName = slotList[i]._icon.sprite.name;    //마우스 뗀 곳의 아이콘 넣어주기
                    slotList[i]._icon.sprite = Resources.Load<Sprite>("Icon/" + slotList[selectedSlotIndex]._icon.sprite.name);
                    //내가 맨 처음에 선택한 슬롯 아이콘을 드래드 뗀 곳에다가 로드해줌
                    slotList[selectedSlotIndex]._icon.sprite = Resources.Load<Sprite>(tmpName);
              

                }
                selectedImage.sprite = null;
                selectedImage.gameObject.SetActive(false);
                selectedSlotIndex = -1;
                return; //영역 안에서의 행위가 이루어 졌다면, ...

            }
        }
        //영역밖에 있는 경우
        selectedImage.sprite = null; //나 따라다니는 아이콘 없애기
        selectedImage.gameObject.SetActive(false);
        selectedSlotIndex = -1;//????????







        //왜 비어있냐..갑자기...;

        //영역 밖에서 내려놓은 경우..
    }

    public void OnPointerUp(PointerEventData eventData)
    {


        if(selectedSlotIndex == -1)  //비어있는 슬롯일 경우 아래의 코드를 실행하지 않아도 된다
        {
            return;
        }

        

        //selectedIcon.gameObject.SetActive(false);


        int tmpIconIndex = -1;

        for (int i = 0; i < slotList.Count; i++)   //슬롯 위치임!
        {
            if (slotList[i].isInRect(eventData.position))
            {
                if(slotList[i]._icon.sprite.name == selectedImage.sprite.name)
                    {
                        Debug.Log("아이콘이랑 선택한 이미지가 같음");
                        itemCount++;
                        //textCount.text = itemCount.ToString();
                        textCount.text = " " + itemCount;

                }
                tmpIconIndex = i;
                break;
            }
            
        }

        if (tmpIconIndex != -1 && tmpIconIndex == selectedSlotIndex)    //내가 내 슬롯 클릭했을 때   
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
