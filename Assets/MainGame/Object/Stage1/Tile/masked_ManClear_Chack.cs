using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masked_ManClear_Chack : MonoBehaviour
{
    private Masked_Man MaskedMan;
    public GameObject Obj;
    private bool objectdirection;
    private bool touchChack = false;
    private bool masked_ManClearChack = false;
    public bool Masked_ManClearChack
    {
        get { return masked_ManClearChack; }
    }
    void Start()
    {
        this.MaskedMan = FindObjectOfType<Masked_Man>();
    }
    void Update()
    {
        objectdirection = MaskedMan.Direction;
       
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

