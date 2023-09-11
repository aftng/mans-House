using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleClear_Chack : MonoBehaviour
{
    public Turtle Turtle;
    public GameObject Obj;
    private bool objectdirection = false;
    private bool touchChack = false;
    public bool TurtleClearChack = false;
    void Update()
    {
        objectdirection = Turtle.direction;
        if (  objectdirection && touchChack)
        {
            TurtleClearChack = true;
        }
        else
        {
            TurtleClearChack = false;
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
