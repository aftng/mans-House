using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdClear_Chack : MonoBehaviour
{
    private Bird Bird;
    public GameObject Obj;
    private bool objectdirection;
    private bool touchChack = false;
    private bool birdCrearChack = false;
    public bool BirdClearChack
    {
        get { return birdCrearChack; }
    }
    void Start()
    {
        this.Bird = FindObjectOfType<Bird>();
    }
    void Update()
    {
        objectdirection = Bird.Direction;
        if (objectdirection && touchChack) 
        {
            birdCrearChack = true;
        }
        else
        {
            birdCrearChack = false;
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
