using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masked_Man : MonoBehaviour
{
    public Object_rotate Object_rotate;
    //オブジェクト回転
    public bool direction;
    private int Objectrotate;
    private int Objectrotatecorrect = 3;

    void Update()
    {
        //他のスクリプトから変数取得
        Objectrotate = Object_rotate.objectrotate;

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
