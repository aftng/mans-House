using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    //���X�N���v�g
    public Object_Sound_rotate Object_Sound_rotate;
    public Sound_Player_Chack Player_Chack;
    private Third_Stage_Gamemaneger third_Stage_Gamemanege;
    private Second_Stage_Gamemaneger Second_Stage_Gamemaneger;
    private Player_grasp Player_grasp;

    //�T�E���h�N���A���ԃJ�E���g
    private int clearcount;

    //player����{�^���J�E���g
    private bool PushChack;

    //player�ڐG����
    private bool isplayer;

    //�T�E���h�N���A����
    private int soundorder;

    //�T�E���h�I��
    private int Soundrotate;

    //�T�E���h����
    private int boreClearrotate = 1;
    void Start()
    {
        Player_grasp = FindObjectOfType<Player_grasp>();
        third_Stage_Gamemanege = FindObjectOfType<Third_Stage_Gamemaneger>();
        Second_Stage_Gamemaneger = FindObjectOfType<Second_Stage_Gamemaneger>();
        soundorder = Second_Stage_Gamemaneger.Orderdoor[5];
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
            if (Soundrotate == boreClearrotate && clearcount == soundorder)
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
