using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class _10_13_Inventory : MonoBehaviour,IPointerDownHandler, IDragHandler,IPointerUpHandler,IEndDragHandler
{

    public List<_10_13_Slot> slotList;     //컴포넌트 타입으로 리스트에 보관
    public Image selectedIcon;      //선택한 슬롯의 이동하는 아이콘
    private int selectedSlotIndex;       //선택한 슬롯의 리스트 인덱스
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
                    selectedIcon.sprite = Resources.Load<Sprite>("Icon/"+ slotList[i].uiIcon.sprite.name);   //리소스이름 (로드해서 대입)
                    selectedIcon.rectTransform.position = _eventData.position;
                    selectedIcon.gameObject.SetActive(true);
                    Debug.Log("선택슬롯"+ slotList[i].gameObject.name);     //선택한 슬롯
                }   
            }
        }
    }

    public void OnDrag(PointerEventData _eventData) //반복함 내 드래그가 멈출떄까지 계속!
    {
        if(selectedSlotIndex != -1) //작업중인 슬롯이 없다면
        {
            selectedIcon.rectTransform.position = _eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData _eventData)  //드래그 종료 시 호출
    {
        
        if (selectedSlotIndex == - 1) //작업중인 슬롯이 없다면 리턴
        {
            return;
        }

        //내려놓는 곳의 아이템을 비교*

        for (int i = 0; i < slotList.Count; i++)  //슬롯 갯수만큼 돌려봤음
        {
            if (slotList[i].isInRect(_eventData.position))  // 내려놓은곳이 슬롯영역이면 실행
            {

                //슬롯이 비어있을 경우 ..?아이템..고유한...아이디...엥 아이디가 뭔데요;; 집에있ㄴㄴ데 집에 가고싶ㄷ
               
                if (slotList[i].uiIcon.sprite == null) {    //아이콘 비어있음 이미지가 있는데 sprite가 없음
                    //새로운 아이콘을 불러올 때는 로드해서 대입 (씬에 올려진거 복사하지 말라함)
                    //?
                    slotList[i].uiIcon.gameObject.SetActive(true);  //아이콘이 없으니까..로드해서...슬롯에 넣어주고 활성화해줌..왜...없는데 왜..
                                                                    //비활성화 한 적도 없는데 오ㅐ 활성화해줘야함
                    slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[selectedSlotIndex].uiIcon.sprite.name);
                    //내가 드래그 끝난 시점에 있는 슬롯 = 내가 맨 첨에 선택한 슬롯 아이템 이름 가져와줌
                    slotList[selectedSlotIndex].uiIcon.sprite = null;
                    slotList[selectedSlotIndex].uiIcon.gameObject.SetActive(false);
                    //
                    //selectedIcon.sprite = null;//왜안대 똑같은데;;;; 똑같은데..
                    //selectedIcon.gameObject.SetActive(false);
                    //selectedSlotIndex = -1; //개똑똑하네;;
                    //쌤이 너무 시끄러워요
                }
                else
                {
                    //슬롯이 채워져 있을 경우 두 아이템을 교환),,로드해요? 교환안하네 개짜ㅏ증나

                    string tmpName = slotList[i].uiIcon.sprite.name;    //마우스 뗀 곳의 아이콘 넣어주기
                    slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/"+slotList[selectedSlotIndex].uiIcon.sprite.name); 
                    //내가 맨 처음에 선택한 슬롯 아이콘을 드래드 뗀 곳에다가 로드해줌
                    slotList[selectedSlotIndex].uiIcon.sprite = Resources.Load<Sprite>(tmpName);
                    //마우스 뗀 곳의 아이콘 변수를 맨 처음에 클릭한곳에 넣어줌 
                    //
                    //selectedIcon.sprite = null;
                    //selectedIcon.gameObject.SetActive(false);
                    //selectedSlotIndex = -1;
                    
                }
                selectedIcon.sprite = null;
                selectedIcon.gameObject.SetActive(false);
                selectedSlotIndex = -1;
                return; //영역 안에서의 행위가 이루어 졌다면, ...
                
            }
        }
        //영역밖에 있는 경우
        selectedIcon.sprite = null; //나 따라다니는 아이콘 없애기
        selectedIcon.gameObject.SetActive(false);
        selectedSlotIndex = -1;//????????







        //왜 비어있냐..갑자기...;

        //영역 밖에서 내려놓은 경우..


    }
    
    public void OnPointerUp(PointerEventData _eventData) // 어느 슬롯에서 뗏는지 찾기
    {
        if(selectedSlotIndex == -1)  //비어있는 슬롯일 경우 아래의 코드를 실행하지 않아도 된다
        {
            return;
        }

        //selectedIcon.gameObject.SetActive(false);


        int tmpIconIndex = -1;

        for(int i=0; i < slotList.Count; i++)   //슬롯 위치임!
        {
            if (slotList[i].isInRect(_eventData.position))
            {
                tmpIconIndex = i;
                break;
            }
        }

        if(tmpIconIndex != -1 && tmpIconIndex == selectedSlotIndex)    //내가 내 슬롯 클릭했을 때   
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
