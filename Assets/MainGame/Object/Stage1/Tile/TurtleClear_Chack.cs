using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleClear_Chack : MonoBehaviour
{
    private Turtle Turtle;
    public GameObject Obj;
    private bool objectdirection;
    private bool touchChack = false;
    private bool turtleClearChack = false;
    public bool TurtleClearChack
    {
        get { return turtleClearChack; }
    }
    void Start()
    {
        this.Turtle = FindObjectOfType<Turtle>();
    }
    void Update()
    {
        objectdirection = Turtle.Direction;
        if (  objectdirection && touchChack)
        {
            turtleClearChack = true;
        }
        else
        {
            turtleClearChack = false;
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
