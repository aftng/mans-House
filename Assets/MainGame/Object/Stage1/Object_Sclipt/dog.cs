using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Object_rotate Object_rotate;
    //オブジェクト回転
    private int Objectrotate;
    private int Objectrotatecorrect = 2;
    private bool direction = false;
    public bool Direction
    {
        get { return direction; }
    }
    void Update()
    {
        //他のスクリプトから変数取得
        Objectrotate = Object_rotate.Objectrotate;

        //オブジェクト正判定
        if (Objectrotate == Objectrotatecorrect)
        {
            direction = true;
        }
        else
        {
            direction = false;
        }
    }
}
