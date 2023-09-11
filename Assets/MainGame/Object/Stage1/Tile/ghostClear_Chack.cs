using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostClear_Chack : MonoBehaviour
{
    public ghost ghost;
    public GameObject Obj;
    private bool objectdirection = false;
    private bool touchChack = false;
    public bool GhostClearChack = false;

    void Update()
    {
        objectdirection = ghost.direction;
        if (objectdirection && touchChack)
        {
            GhostClearChack = true;
        }
        else
        {
            GhostClearChack = false;
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