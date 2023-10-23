using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    //���̃X�N���v�g�擾
    public UpChack UpChack;
    public DownChack DownChack;
    public RigthChack RigthChack;
    public LeftChack LeftChack;

    private Game_Manager Game_Manager;
    private Object_move Object_move;
    private PlayerAction PlayerAction;

    //�㉺���E�̐ڐG����
    private bool isUpChack;
    private bool isDownChack;
    private bool isRigthChack;
    private bool isLeftChack;

    //�v���C���[�X�g�b�v
    private bool playerstop = false;

    //player�ړ�
    [SerializeField]
    private float moveSpeed;
    private float player_speed;
    private Vector2 playermove;
    public Vector2 Playermove
    {
        get { return playermove; }
    }
    //�I�u�W�F�N�g�X�s�[�h
    private float Objectspeed;

    //�A�j���[�V����
    private Vector2 lastMove;

    private Vector2 AnimateMove;
    //�I�[�f�B�I
    [SerializeField]
   private AudioClip clip;

    //�v���C���[�͂ݔ���
    private bool HoldChack;

    //�R���|�[�l���g�擾
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Animator animator;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        PlayerAction = FindObjectOfType<PlayerAction>();
        Game_Manager = FindObjectOfType<Game_Manager>();
        Object_move = FindObjectOfType<Object_move>(); 
        player_speed = moveSpeed;
        Objectspeed = Object_move.ObjectSpeed;
    }
    void Update()
    {
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();

        playermove.x = Input.GetAxisRaw("Horizontal");
        playermove.y = Input.GetAxisRaw("Vertical");

        HoldChack = PlayerAction.HoldChack();

        playerstop = Game_Manager.PlayerStop;
        PlayerMove();  
    }
    void FixedUpdate()
    {
        if (!playerstop)
        {
            //�΂߈ړ��֎~
            if (playermove.x != 0 && playermove.y != 0)
            {
                playermove.x = 0;
                playermove.y = 0;
            }

            rb.velocity = new Vector2(playermove.x, playermove.y).normalized * player_speed;
            AnimateMove = rb.velocity;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        PlayerFootstepSound();
        Animate();
    }
    private void PlayerMove()
    {
        if (isUpChack || isDownChack)
        {
            if (playermove.y != 0)
            {
                player_speed = Objectspeed;
                playermove.x = 0;
            }
            else
            {
                player_speed = moveSpeed;
            }
        }
        else if (isRigthChack || isLeftChack)
        {
            if (playermove.x != 0)
            {
                player_speed = Objectspeed;
                playermove.y = 0;
            }
            else
            {
                player_speed = moveSpeed;
            }
        }
        else
        {
            player_speed = moveSpeed;
        }
    }
    private void Animate()
    {
        //�I�u�W�F�N�g��͂񂾎���Player�̌������Œ肷�邽�߂̕ϐ�
        //1��-1�Ō������Ǘ�
        float MoveStop = 1;

        if (Mathf.Abs(rb.velocity.x) > 0.5f)
        {
            if (HoldChack && isLeftChack)
            {
                AnimateMove.x = -MoveStop;
                lastMove.x = AnimateMove.x;
                lastMove.y = 0;
            }
            else if (HoldChack && isRigthChack)
            {
                AnimateMove.x = MoveStop;
                lastMove.x = AnimateMove.x;
                lastMove.y = 0;
            }
            else
            {
                AnimateMove.x = rb.velocity.x;
                lastMove.x = rb.velocity.x;
                lastMove.y = 0;
            }
        }
        else if(Mathf.Abs(rb.velocity.y) > 0.5f)
        {
            if (HoldChack && isUpChack)
            {
                AnimateMove.y = MoveStop;
                lastMove.y = AnimateMove.y;
                lastMove.x = 0;
            }
            else if (HoldChack && isDownChack)
            {
                AnimateMove.y = -MoveStop;
                lastMove.y = AnimateMove.y;
                lastMove.x = 0;
            }
            else
            {
                AnimateMove.y = rb.velocity.y;
                lastMove.y = rb.velocity.y;
                lastMove.x = 0;
            }
        } 
        
        animator.SetFloat("Dir_X", AnimateMove.x);
        animator.SetFloat("Dir_Y", AnimateMove.y);
        animator.SetFloat("LastMove_X", lastMove.x);
        animator.SetFloat("LastMove_Y", lastMove.y);
        animator.SetFloat("Input", rb.velocity.magnitude);
    }
    private void PlayerFootstepSound()
    {
        //�ړ����̂݃T�E���h��炷
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