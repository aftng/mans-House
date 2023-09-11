using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseClear_Chack : MonoBehaviour
{
    public Horse Horse;
    public GameObject Obj;
    private bool objectdirection = false;
    private bool touchChack = false;
    public bool HorseClearChack = false;
    void Update()
    {
        objectdirection = Horse.direction;
        if (objectdirection && touchChack)
        {
            HorseClearChack = true;
        }
        else
        {
            HorseClearChack = false;
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
