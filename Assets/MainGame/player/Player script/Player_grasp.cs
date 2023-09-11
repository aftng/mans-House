using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_grasp : MonoBehaviour
{
    //上下左右の接触判定
    public UpChack UpChack;
    public DownChack DownChack;
    public RigthChack RigthChack;
    public LeftChack LeftChack;

    private bool isUpChack = false;
    private bool isDownChack = false;
    private bool isRigthChack = false;
    private bool isLeftChack = false;

    private bool PushChack = false;
    public bool Push
    {
        get { return PushChack; }
    }
    //掴み
    private bool holdChack = false;

    //他のスクリプトに送る用のSet Get
    public bool Hold
    {
        get { return holdChack; }
    }
    void Update()
    {
        //接触判定
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();
        if (isUpChack || isDownChack || isLeftChack || isRigthChack)
        {
            //ホールド判定
            if (Input.GetKey("c"))
            {
                holdChack = true;
            }
            else
            {
                holdChack = false;
            }
        }
        else
        {        
            //タップ判定
            if (Input.GetKeyDown("c"))
            {
                PushChack = true;
            }
            else
            {
                PushChack = false;
            }
        }
    }
}
