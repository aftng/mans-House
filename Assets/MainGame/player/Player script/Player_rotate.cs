using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_rotate : MonoBehaviour
{   
    //���͔���
�@�@private bool leftkey = false;
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
        //�L�[����
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


