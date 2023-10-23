using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Object_rotate Object_rotate;
    public Object Tile;

    //オブジェクト回転
    private int Objectrotatecorrect = 2;
    private int Objectrotate;

    private bool touchChack = false;
    private bool clearChack = false;

    //接触判定用
    public bool ObjectClearChack()
    {
        //他のスクリプトから変数取得
        Objectrotate = Object_rotate.Objectrotate;
        //オブジェクト正判定
        if (Objectrotate == Objectrotatecorrect && touchChack)
        {
            clearChack = true;
        }
        else
        {
            clearChack = false;
        }
        return clearChack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Tile)
        {
            touchChack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Tile)
        {
            touchChack = false;
        }
    }
}