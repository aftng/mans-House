using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseClear_Chack : MonoBehaviour
{
    private Horse Horse;
    public GameObject Obj;
    private bool objectdirection;
    private bool touchChack = false;
    private bool horseClearChack = false;
    public bool HorseClearChack
    {
        get { return horseClearChack; }
    }
    void Start()
    {
        this.Horse = FindObjectOfType<Horse>();
    }
    void Update()
    {
        objectdirection = Horse.Direction;
        if (objectdirection && touchChack)
        {
            horseClearChack = true;
        }
        else
        {
            horseClearChack = false;
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
