using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Game_Manager : MonoBehaviour
{
    //�J�����ʒu
    //State�ŏ���������Ƒ��̃X�N���v�g��State�ŕϐ����󂯓n���Ȃ�
    private float[] cameraposition = {0, 25.6f, 51.2f};
    public float[] Cameraposition
    {
        get { return cameraposition; }
    }
    //�v���C���[�X�g�b�v
    private bool playerStop;
    public bool PlayerStop
    {
        get { return playerStop; }
        set { playerStop = value; }
    }
}
