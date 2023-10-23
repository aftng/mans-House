using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Object_move : MonoBehaviour
{
    //���̃X�N���v�g�擾
    private UpChack UpChack;
    private DownChack DownChack;
    private RigthChack RigthChack;
    private LeftChack LeftChack;
    public Player_Chack PlayerChack;
    private First_Stage_maneger FirstStage;
    private PlayerAction PlayerAction;
    private Player player;

    //�㉺���E�ڐG����
    private bool isUpChack;
    private bool isDownChack;
    private bool isRigthChack;
    private bool isLeftChack;

    //�v���C���[�͂ݔ���
    private bool holdChack;
    //�v���C���[�ڐG����
    private bool Isplayer;
    //�v���C���[
    private Vector2 playermove;
    //�X�e�[�W�P�N���A����
    private bool First_StageClear;
    //�I�u�W�F�N�g�X�s�[�h
    private float objectSpeed = 1.0f;
    public float ObjectSpeed
    {
        get { return objectSpeed; }
    }
    private Vector2 Objectmove;
    
    //�I�[�f�B�I  
    [SerializeField]
    AudioClip clip;

    //�R���|�[�l���g�擾
    private AudioSource audioSource;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        FirstStage = FindObjectOfType<First_Stage_maneger>();
        PlayerAction = FindObjectOfType<PlayerAction>();
        player = FindObjectOfType<Player>();
        UpChack = FindObjectOfType<UpChack>();
        DownChack = FindObjectOfType<DownChack>();
        RigthChack = FindObjectOfType<RigthChack>();
        LeftChack = FindObjectOfType<LeftChack>();
    }

    // Update is called once per frame
    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
        First_StageClear = FirstStage.FirststageClear;

        //�X�e�[�W���N���A������@�\��~
        if (First_StageClear) 
        {
            rb.bodyType = RigidbodyType2D.Static;
            return; 
        }

        //���̃X�N���v�g����ϐ��擾
        Isplayer = PlayerChack.IsPlayerChack();
        holdChack = PlayerAction.HoldChack();
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();
        playermove = player.Playermove;

        Rigidbody();
        ObjectMove();
    }

    void FixedUpdate()
    {
        //�΂߈ړ��֎~
        if (Objectmove.x != 0 && Objectmove.y != 0)
        {
            Objectmove.x = 0;
            Objectmove.y = 0;
        }
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            rb.velocity = new Vector2(Objectmove.x, Objectmove.y).normalized * objectSpeed;
        }
        PlayFootstepSound();
    }
    private void ObjectMove()
    {
        if(rb.bodyType == RigidbodyType2D.Static) { return; }
        if (isUpChack || isDownChack)
        {
            Objectmove.y = playermove.y;
            Objectmove.x = 0;
        }
        else if (isLeftChack || isRigthChack)
        {
            Objectmove.x = playermove.x;
            Objectmove.y =0;
        }
    }
    private void Rigidbody()
    {
        //Rigidbody����
        if (holdChack && Isplayer)
        {     
            if(isUpChack||isDownChack||isLeftChack||isRigthChack)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }   
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    private void PlayFootstepSound()
    {
        //�I�[�f�B�I
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