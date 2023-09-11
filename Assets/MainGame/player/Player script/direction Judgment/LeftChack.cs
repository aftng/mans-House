using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftChack : MonoBehaviour
{
    private string LeftChackTag = "Object";
    private bool isLeftChack = false;
    private bool isLeftChackEnter, isLeftChackExit;
                
    public bool IsLeftChack()
    {
        //ê⁄êGîªíË
        if (isLeftChackEnter)
        {
            isLeftChack = true;
        }
        else if (isLeftChackExit)
        {
            isLeftChack = false;
        }

        isLeftChackEnter = false;
        isLeftChackExit = false;
        return isLeftChack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == LeftChackTag)
        {
            isLeftChackEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == LeftChackTag)
        {
            isLeftChackExit = true;
        }
    }
}
