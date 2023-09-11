using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_grasp : MonoBehaviour
{
    //�㉺���E�̐ڐG����
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
    //�͂�
    private bool holdChack = false;

    //���̃X�N���v�g�ɑ���p��Set Get
    public bool Hold
    {
        get { return holdChack; }
    }
    void Update()
    {
        //�ڐG����
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();
        if (isUpChack || isDownChack || isLeftChack || isRigthChack)
        {
            //�z�[���h����
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
            //�^�b�v����
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
