using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _12_03_Message_03 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Move()
    {
        var pos = this.GetComponent<Transform>().position;
        pos.x += 0.05f;
        this.GetComponent<Transform>().position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
