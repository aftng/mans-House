using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogClear_Chack : MonoBehaviour
{
    public dog dog;
    public GameObject Obj;
    public bool DogClearChack = false;
    private bool objectdirection = false;
    private bool touchChack = false;
    void Update()
    {
        objectdirection = dog.direction;
        if (objectdirection)
        {
            if (objectdirection && touchChack)
            {
                DogClearChack = true;
            }
            else
            {
                DogClearChack = false;
            }
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
