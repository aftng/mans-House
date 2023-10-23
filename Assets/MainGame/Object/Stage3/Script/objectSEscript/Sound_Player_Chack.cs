using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Player_Chack : MonoBehaviour
{
    //プレイヤーチェック
    private bool isPlayerChack = false;
    private bool isPlayerChackEnter, isPlayerChackExit;
  
    public bool IsPlayerChack()
    {
           if (isPlayerChackEnter)
           {
                isPlayerChack = true;
           }    
            if (isPlayerChackExit)
            {
                isPlayerChack = false;
            }
        isPlayerChackEnter = false;
        isPlayerChackExit = false;
        return isPlayerChack;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerChackEnter = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerChackExit = true;
        }
    }
}
