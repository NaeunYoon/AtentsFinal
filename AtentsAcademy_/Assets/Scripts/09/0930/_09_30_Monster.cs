using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_30_Monster : MonoBehaviour
{
    public Vector3 END { get; set; }
    public int barrackIndex { get; set; }
    public float moveSpeed { get; set; }

    public int barrakIndex { get; set; }


    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,END,moveSpeed*Time.deltaTime);
    }
}
