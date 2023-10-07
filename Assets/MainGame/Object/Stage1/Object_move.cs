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
    public Player_Chack Player_Chack;
    private First_Stage_maneger First_Stage;
    private Player_grasp Player_grasp;
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
        //���̃X�N���v�g����ϐ��擾
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
        //Rigidbody����
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