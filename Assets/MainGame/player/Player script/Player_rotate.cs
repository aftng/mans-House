using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_rotate : MonoBehaviour
{   
    //入力判定
　　private bool leftkey = false;
    private bool rightkey = false;

    public bool Rightkey
    {
       get { return rightkey; }
       set{ rightkey = value; }
    }
    public bool Leftkey
    {        
        get { return leftkey; }
        set { leftkey = value; }
    }
    void Update()
    {
        //キー入力
        if (Input.GetKeyDown("z"))
        {
            Leftkey = true;
        }
        else
        {
            Leftkey = false;
        }
        if (Input.GetKeyDown("x"))
        {
            Rightkey = true;
        }
        else
        {
            Rightkey = false;
        }
    }
}


