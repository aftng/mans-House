using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Sound_rotate : MonoBehaviour
{
    //���̃X�N���v�g
    public Sound_Player_Chack Player_Chack;
    private PlayerAction PlayerAction;
    //�v���C���ڐG����
    private bool isplayer = false;

    //�v���C������̃L�[����
    private bool leftkey = false;
    private bool rightkey = false;
    private bool PushChack;
    //���[�v�̍Œ�l
    private int rotateminimum = -1;

    //�I�[�f�B�I
    private AudioSource audioSource;
    private int soundrotate;

    [SerializeField]
    AudioClip[] clip;
   
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerAction = FindObjectOfType<PlayerAction>();
        soundrotate = 0;
    }
    void Update()
    {
        isplayer = Player_Chack.IsPlayerChack();
        rightkey = PlayerAction.RotateRightChack();
        leftkey = PlayerAction.RotateLeftChack();
        PushChack = PlayerAction.DecisionChack();

        //�ڐG����
        if (isplayer)
        {
            //�v���C���[����̓���
            if (rightkey)
            {
                soundrotate++;
            }
            if (leftkey)
            {
                soundrotate--;
            }
            SErotate();
            SEselect();
        }
        else
        {
            soundrotate = 0;
        }
    }

    private void SErotate()
    {
        //�T�E���h���[�v
        if (soundrotate >= clip.Length)
        {
            soundrotate = rotateminimum + 1;
        }
        if (soundrotate <= rotateminimum)
        {
            soundrotate = clip.Length - 1;
        }
        if (rightkey || leftkey)
        {
            audioSource.PlayOneShot(clip[soundrotate]);
        }
    }

    public int SEselect()
    {
        //�ڐG����
        if (isplayer && PushChack)
        {           
           audioSource.PlayOneShot(clip[soundrotate]);
        }
        return soundrotate;
    }
}