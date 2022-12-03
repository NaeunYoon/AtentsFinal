using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_03_SendMessage : MonoBehaviour
{

    [SerializeField] private GameObject _obj;
    void Start()
    {
        _obj.SendMessage("Eat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
