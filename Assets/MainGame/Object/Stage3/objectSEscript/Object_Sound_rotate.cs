using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Sound_rotate : MonoBehaviour
{
    //他のスクリプト
    public Sound_Player_Chack Player_Chack;
    private Player_rotate Player_rotate;
    private Player_grasp Player_grasp;
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
        this.Player_rotate = FindObjectOfType<Player_rotate>();
        this.Player_grasp = FindObjectOfType<Player_grasp>();
        soundrotate = 0;
    }
    void Update()
    {
        isplayer = Player_Chack.IsPlayerChack();
        rightkey = Player_rotate.Rightkey;
        leftkey = Player_rotate.Leftkey;
        PushChack = Player_grasp.Push;

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
        if (isplayer)
        {
            if (PushChack)
            {
                audioSource.PlayOneShot(clip[soundrotate]);
            }
        }
        return soundrotate;
    }
}