using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoddessStatue_Correct_Sound : MonoBehaviour
{
    //���X�N���v�g
    public Object_Sound_rotate Object_Sound_rotate;
    public Sound_Player_Chack Player_Chack;
    private Third_Stage_Gamemaneger third_Stage_Gamemanege;
    private PlayerAction PlayerAction;

    //player����{�^��
    private bool PushChack;

    //player�ڐG����
    private bool isplayer;

    //�T�E���h�N���A����
    [SerializeField]
    private int correctorder;

    [SerializeField]
    private int secondcorrectorder;
    //�T�E���h�I��
    private int Soundrotate;

    //�T�E���h����
    [SerializeField]
    private int ObjectrotateChack;
    void Start()
    {
        PlayerAction = FindObjectOfType<PlayerAction>();
        third_Stage_Gamemanege = FindObjectOfType<Third_Stage_Gamemaneger>();
    }

    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
        Soundrotate = Object_Sound_rotate.SEselect();
        PushChack = PlayerAction.DecisionChack();
        isplayer = Player_Chack.IsPlayerChack();

        //�I�u�W�F�N�g�̉��̍����̐�����
        if (isplayer && PushChack)
        {
            if (Soundrotate == ObjectrotateChack)
            {
                third_Stage_Gamemanege.TwoOrdertChack(correctorder, secondcorrectorder);
            }
            else
            {
                //�I�u�W�F�N�g�̉��̍������Ⴄ�ꍇ0��Ԃ�
                third_Stage_Gamemanege.OrderChack(0);
            }
        }
    }
}