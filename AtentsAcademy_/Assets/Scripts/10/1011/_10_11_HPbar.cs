using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_11_HPbar : MonoBehaviour
{
    /*
     3초마다 줄어드는 hp bar 구현
     
     */

    public Image bar;
    public float duration;
    private float tmpDuration;
    void Start()
    {
        tmpDuration = duration;
        
    }
    //초기화함수

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
