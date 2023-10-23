using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Chack : MonoBehaviour
{
    //他のオブジェクト取得
    //同じスクリプトを使いまわしてるので配列で管理
    public Player_Chack[] playerChack;
    private bool[] Chack = new bool[5];

    public bool PlayerChack = false;
    private bool isPlayerChack = false;
    private bool isPlayerChackEnter, isPlayerChackExit;

    public bool IsPlayerChack()
    {
        for(int i= 0; i < playerChack.Length; ++i)
        {
            Chack[i] = playerChack[i].PlayerChack;
        }
        //自分が接触している時は他のオブジェクトに接触判定をさせないようにする
        if (!PlayerChack && !Chack[0] && !Chack[1] && !Chack[2] && !Chack[3] && !Chack[4])
        {
            if (isPlayerChackEnter)
            {
                isPlayerChack = true;
                PlayerChack = true;
            }
        }
        if (PlayerChack)
        {
            if (isPlayerChackExit)
            {
                PlayerChack = false;
                isPlayerChack = false;
            }
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
