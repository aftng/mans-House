using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masked_ManClear_Chack : MonoBehaviour
{
    public masked_Man maskedMan;
    public GameObject Obj;
    private bool objectdirection = false;
    private bool touchChack = false;
    public bool masked_ManClearChack = false;
 
    void Update()
    {
        objectdirection = maskedMan.direction;
       
        if (touchChack && objectdirection)
        {
            masked_ManClearChack = true;
        }
        else
        {
            masked_ManClearChack = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == Obj)
        {
            touchChack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Obj)
        {
            touchChack = false;
        }
    }
}

