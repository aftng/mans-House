using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogClear_Chack : MonoBehaviour
{
    private Dog Dog;
    public GameObject Obj;
    private bool objectdirection;
    private bool touchChack = false;
    private bool dogClearChack = false;
    public bool DogClearChack
    {
        get { return dogClearChack; }
    }
    void Start()
    {
        this.Dog = FindObjectOfType<Dog>();
    }
    void Update()
    {
        objectdirection = Dog.Direction;
        if (objectdirection)
        {
            if (objectdirection && touchChack)
            {
                dogClearChack = true;
            }
            else
            {
                dogClearChack = false;
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
