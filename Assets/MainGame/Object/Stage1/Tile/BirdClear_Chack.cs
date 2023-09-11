using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdClear_Chack : MonoBehaviour
{
    public Bird Bird;
    public GameObject Obj;
    private bool objectdirection = false;
    private bool touchChack = false;
    public bool BirdCrear = false;
    void Update()
    {
        objectdirection = Bird.direction;
        if (objectdirection && touchChack) 
        {
            BirdCrear = true;
        }
        else
        {
            BirdCrear = false;
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
