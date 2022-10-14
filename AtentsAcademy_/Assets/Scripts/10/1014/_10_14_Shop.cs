using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class _10_14_Shop : MonoBehaviour
{
    /*
     상점과같은 아이템을 다루는 방법!
     아이템을 동적으로 추가하고 싶음.
     컨텐츠 영역에 아이템들이 존재하는데...
     아이템을 하나 더 추가...하면 아이템이 아래에 붙어야함
     컨텐츠 영역이 늘어나야함
     
    오...!Contents Size 늘어남;;
    Vertical Fit > prefferred
     
    유아이를 로드해서 어떻게 추가하냐
    어떻게 아이템을 동적으로 추가하냐..
    비어있는 ui를 복사..비활성화

    하나 올려놓고 비활성화하고 그 게임 옵젝을 복사해서 사용
    (프리팹 만드는 것 보다 ..유용)


     */

    /*public GameObject itemSrc;*/  //1. 아이템 원본 (비활성화한거 넣어줌 : 사용안함)

    public ScrollRect scrollRect;   //3

    public _10_14_Item itemRrc;

    //-----------------------------------------------------------손은 눈보다 빠르다
    //public Transform itemParentTransform;
    //private List<_10_14_Item> itemList = new List<_10_14_Item>();
    //private Sprite[] itemSpriteList;

    void Start()
    {
        //비활성화 된 게임인스턴스를 복사했......
        //재밌는거 보여줄까요?
        //GameObject newItem = Instantiate<GameObject>(itemRrc);
        //itemSpriteList = Resources.LoadAll<Sprite>("icon/"); //빠르죠?
        
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
