using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostClear_Chack : MonoBehaviour
{
    private Ghost Ghost;
    public GameObject Obj;
    private bool objectdirection;
    private bool touchChack = false;
    private bool ghostClearChack = false;
    public bool GhostClearChack
    {
        get { return ghostClearChack; }
    }
    void Start()
    {
        this.Ghost = FindObjectOfType<Ghost>();
    }
    
    void Update()
    {
        objectdirection = Ghost.Direction;
        if (objectdirection && touchChack)
        {
            ghostClearChack = true;
        }
        else
        {
            ghostClearChack = false;
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