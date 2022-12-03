using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_03_Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Attack()
    {
        Debug.Log("Attack" + this.name);
    }

    public void Defence()
    {
        Debug.Log("Defence"+this.name);
    }
    public void Run()
    {
        Debug.Log("Run" + this.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
