using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _blockImage;

    public SpriteRenderer blockImage    //프로퍼티 생성
    {
        get { return _blockImage; }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
