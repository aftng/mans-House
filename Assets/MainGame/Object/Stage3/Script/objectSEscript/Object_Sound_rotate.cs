using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Sound_rotate : MonoBehaviour
{
    //他のスクリプト
    public Sound_Player_Chack Player_Chack;
    private PlayerAction PlayerAction;
    //プレイヤ接触判定
    private bool isplayer = false;

    //プレイヤからのキー入力
    private bool leftkey = false;
    private bool rightkey = false;
    private bool PushChack;
    //ループの最低値
    private int rotateminimum = -1;

    //オーディオ
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

        //接触判定
        if (isplayer)
        {
            //プレイヤーからの入力
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
        //サウンドループ
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
        //接触判定
        if (isplayer && PushChack)
        {           
           audioSource.PlayOneShot(clip[soundrotate]);
        }
        return soundrotate;
    }
}