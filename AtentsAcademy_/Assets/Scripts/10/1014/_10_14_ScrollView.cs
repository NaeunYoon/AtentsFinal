using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_14_ScrollView : MonoBehaviour
{
    /*
     ��ũ�Ѻ��� ������ �ϴ� ������Ʈ : ScrollRect ;���� ���� �����ó�;

     ������ ��ġ�� �����Ϸ��� �̹����� rectTransform�� ��������
     
     
     */

    public ScrollRect scrollRect;

    void Start()
    {
        scrollRect.normalizedPosition = new Vector2(1,1); //�̰� �ֱ��ϴ°ǵ�...
    }

    
    void Update()
    {
       //Vector2 tmp = scrollRect.normalizedPosition;  //scrollRect.normalizedPosition�� ���ؼ� ��ũ���� ��ġ�� ����� �� �ִ�..
       // tmp.x += Time.deltaTime*0.1f;
       // scrollRect.normalizedPosition = tmp;
    }
}
