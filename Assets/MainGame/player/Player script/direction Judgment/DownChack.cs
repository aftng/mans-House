using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownChack : MonoBehaviour
{
    private string DownChackTag = "Object";
    private bool isDownChack = false;
    private bool isDownChackEnter, isDownChackExit;
    public bool IsDownChack()
    {   
        //ê⁄êGîªíË
        if (isDownChackEnter)
        {
            isDownChack = true;
        }
        else if (isDownChackExit)
        {
            isDownChack = false;
        }

        isDownChackEnter = false;
        isDownChackExit = false;
        return isDownChack;
    }  
    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.tag == DownChackTag)
        {
            isDownChackEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == DownChackTag)
        {
            isDownChackExit = true;
        }
    }
}
