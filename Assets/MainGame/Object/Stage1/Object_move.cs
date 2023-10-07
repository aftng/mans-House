using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Object_move : MonoBehaviour
{
    //他のスクリプト取得
    private UpChack UpChack;
    private DownChack DownChack;
    private RigthChack RigthChack;
    private LeftChack LeftChack;
    public Player_Chack Player_Chack;
    private First_Stage_maneger First_Stage;
    private Player_grasp Player_grasp;
    private Player player;

    //上下左右接触判定
    private bool isUpChack;
    private bool isDownChack;
    private bool isRigthChack;
    private bool isLeftChack;

    //プレイヤー掴み判定
    private bool holdChack;
    //プレイヤー接触判定
    private bool Isplayer;
    //プレイヤー
    private Vector2 playermove;
    //ステージ１クリア判定
    private bool First_StageClear;
    //オブジェクトスピード
    private float objectSpeed = 1.0f;
    public float ObjectSpeed
    {
        get { return objectSpeed; }
    }
    private Vector2 Objectmove;
    
    //オーディオ
   
    [SerializeField]
    AudioClip clip;
    //コンポーネント取得
    private AudioSource audioSource;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        this.First_Stage = FindObjectOfType<First_Stage_maneger>();
        this.Player_grasp = FindObjectOfType<Player_grasp>();
        this.player = FindObjectOfType<Player>();
        this.UpChack = FindObjectOfType<UpChack>();
        this.DownChack = FindObjectOfType<DownChack>();
        this.RigthChack = FindObjectOfType<RigthChack>();
        this.LeftChack = FindObjectOfType<LeftChack>();
    }

    // Update is called once per frame
    void Update()
    {
        //他のスクリプトから変数取得
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();
        Isplayer = Player_Chack.IsPlayerChack();
        playermove = player.Playermove;
        First_StageClear = First_Stage.FirststageClear;
        holdChack = Player_grasp.Hold;
     
        Rigidbody();
        ObjectMove();
    }

    void FixedUpdate()
    {
        //斜め移動禁止
        if (Objectmove.x != 0 && Objectmove.y != 0)
        {
            Objectmove.x = 0;
            Objectmove.y = 0;
        }

        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {           
            rb.velocity = new Vector2(Objectmove.x, Objectmove.y).normalized * objectSpeed;
        }
    }
    private void ObjectMove()
    {
        if (First_StageClear){ return; }

        if (Isplayer && holdChack)
        {
            if (isUpChack || isDownChack)
            {
                Objectmove.y = playermove.y;
            }
            else if (isLeftChack || isRigthChack)
            {
                Objectmove.x = playermove.x;
            }
        }
        else
        {
            Objectmove.x = 0;
            Objectmove.y = 0;
        }
        PlayFootstepSound();
    }
    private void Rigidbody()
    {
        //Rigidbody操作
        if (!First_StageClear && holdChack && Isplayer)
        {
            if(isUpChack || isDownChack || isLeftChack || isRigthChack)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    private void PlayFootstepSound()
    {
        //オーディオ
        if (rb.velocity.magnitude != 0)
        {          
           if (!audioSource.isPlaying)
           {
               audioSource.PlayOneShot(clip);
           }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}