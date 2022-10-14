using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_11_HPbar : MonoBehaviour
{
    /*
     3�ʸ��� �پ��� hp bar ����
     
     */

    public Image bar;
    public float duration;
    private float tmpDuration;
    void Start()
    {
        tmpDuration = duration;
        
    }
    //�ʱ�ȭ�Լ�

    public void Initialized()
    {
        bar.fillAmount = 1;
        tmpDuration = duration;
    }

    public void ChangeSprite(string _name)
    {
      Sprite spr =  Resources.Load<Sprite>(_name);
      bar.sprite = spr;

    }

    void Update()
    {
        tmpDuration -= Time.deltaTime;
        bar.fillAmount = tmpDuration/duration;
    }
}
