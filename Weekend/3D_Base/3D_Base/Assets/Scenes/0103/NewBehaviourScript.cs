using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        GameObject monster1 = GameObject.Find("Cube");
        GameObject monster2 = GameObject.Find("Cube");
        GameObject monster3 = GameObject.Find("Cube (1)");
        GameObject monster4 = GameObject.Find("Cube");

        monster1.name = "Naeun";
        Debug.Log(monster1.name);
        Debug.Log(monster2.name);
        Debug.Log(monster3.name);
        Debug.Log(monster4.name);
    }
    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }
    private void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
    }
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }
    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
    }
    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
    }
    void Update()
    {
        
    }
}
