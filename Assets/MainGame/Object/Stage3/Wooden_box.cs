using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wooden_box: MonoBehaviour
{
    //���X�N���v�g
    public Object_Sound_rotate Object_Sound_rotate;
    public Sound_Player_Chack Player_Chack;
    private Third_Stage_Gamemaneger third_Stage_Gamemanege;
    private Second_Stage_Gamemaneger Second_Stage_Gamemaneger;
    private Player_grasp Player_grasp;

    //�T�E���h�N���A���ԃJ�E���g
    private int clearcount;

    //player����{�^��
    private bool PushChack;

    //player�ڐG����
    private bool isplayer;

    //�T�E���h�N���A����
    private int soundorder;

    //�T�E���h�I��
    private int Soundrotate;

    //�T�E���h����
    private int wood_boxClearrotate = 1;
    void Start()
    {
        this.Player_grasp = FindObjectOfType<Player_grasp>();
        this.third_Stage_Gamemanege = FindObjectOfType<Third_Stage_Gamemaneger>();
        this.Second_Stage_Gamemaneger = FindObjectOfType<Second_Stage_Gamemaneger>();
        soundorder = Second_Stage_Gamemaneger.Orderdoor[1];
    }

    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
        Soundrotate = Object_Sound_rotate.SEselect();
        PushChack = Player_grasp.Push;
        isplayer = Player_Chack.IsPlayerChack();
        clearcount = third_Stage_Gamemanege.Clearcount;

        //�I�u�W�F�N�g������
        if (isplayer && PushChack)
        {
            if (Soundrotate == wood_boxClearrotate && clearcount == soundorder)
            {
                clearcount++;
            }
            else
            {
                clearcount = 0;
            }
        }
        third_Stage_Gamemanege.Clearcount = clearcount;
    }
}
