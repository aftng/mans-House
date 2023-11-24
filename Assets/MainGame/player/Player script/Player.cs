using UnityEngine;

public class Player : MonoBehaviour
{
    //���̃X�N���v�g�擾
    public UpChack UpChack;
    public DownChack DownChack;
    public RigthChack RigthChack;
    public LeftChack LeftChack;
    public PlayerAction PlayerAction;
    public Gameprogress Gameprogress;
    public ObjectCarry ObjectCarry;
    public Select_question Select_question;

    //�㉺���E�ڐG����
    private bool isUpChack;
    private bool isDownChack;
    private bool isRigthChack;
    private bool isLeftChack;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float Objectcarryspeed = 1;

    //�v���C���[�̌��݃X�s�[�h
    private float player_speed;
    private Vector2 playermove;

    private bool playerstop = false;
    private bool HoldChack;
    private bool question_openCheck;

    //�A�j���[�V��������
    private Vector2 lastMove;
    private Vector2 AnimateMove;

    [SerializeField]
    private AudioClip Playerclip;

    //�R���|�[�l���g
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player_speed = moveSpeed;
        Cursor.visible = false;
    }
    void Update()
    {
        //���̃X�N���v�g�ϐ��擾
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();
        HoldChack = PlayerAction.HoldChack();
        playerstop = Gameprogress.PlayerStop;

        //�ړ�����
        playermove.x = Input.GetAxisRaw("Horizontal");
        playermove.y = Input.GetAxisRaw("Vertical");
        
        //�΂߈ړ��֎~
        if (playermove.x != 0 && playermove.y != 0)
        {
            playermove = Vector2.zero;
        }         
        Objectsoperation();  
        QuestionOpen();
        Animate();
        PlayerSound();
    }
    void FixedUpdate()
    {
        if (playerstop)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity = new Vector2(playermove.x, playermove.y).normalized * player_speed;
        AnimateMove = rb.velocity;
    }
    private void Objectsoperation()
    {
        if (ObjectCarry.CarryObject != null)
        {
            //�I�u�W�F�N�g��]
            ObjectCarry.ObjectRotate();
            //�I�u�W�F�N�g�ړ����̃X�s�[�h�ƃI�u�W�F�N�g�ړ�
            if ( HoldChack && (isUpChack || isDownChack))
            {
                player_speed = Objectcarryspeed;
                playermove.x = 0;
                ObjectCarry.Objectoperation(playermove, player_speed);
            }
            else if (HoldChack && (isRigthChack || isLeftChack))
            {
                player_speed = Objectcarryspeed;
                playermove.y = 0;
                ObjectCarry.Objectoperation(playermove, player_speed);
            }
            else
            {
                player_speed = moveSpeed;
                ObjectCarry.ObjectMoveStop();
            }
        }
        else
        {
            player_speed = moveSpeed;
        }
    }
    private void Animate()
    {
        //�I�u�W�F�N�g�ړ�����Player�̌������Œ肷��
        if (Mathf.Abs(rb.velocity.x) > 0.5f)
        {
            if (HoldChack && isLeftChack)
            {
                AnimateMove = Vector2.left;
                lastMove = new Vector2(AnimateMove.x, 0);
            }
            else if (HoldChack && isRigthChack)
            {
                AnimateMove = Vector2.right;
                lastMove = new Vector2 (AnimateMove.x,0);
            }
            else
            {
                AnimateMove.x = rb.velocity.x;
                lastMove = new Vector2(rb.velocity.x, 0);
            }
        }
        else if (Mathf.Abs(rb.velocity.y) > 0.5f)
        {
            if (HoldChack && isUpChack)
            {
                AnimateMove = Vector2.up; ;
                lastMove = new Vector2(0, AnimateMove.y);
            }
            else if (HoldChack && isDownChack)
            {
                AnimateMove = Vector2.down;
                lastMove = new Vector2(0, AnimateMove.y);
            }
            else
            {
                AnimateMove.y = rb.velocity.y;
                lastMove = new Vector2(0, AnimateMove.y);
            }
        }
        animator.SetFloat("Dir_X", AnimateMove.x);
        animator.SetFloat("Dir_Y", AnimateMove.y);
        animator.SetFloat("LastMove_X", lastMove.x);
        animator.SetFloat("LastMove_Y", lastMove.y);
        animator.SetFloat("Input", rb.velocity.magnitude);
    }
    private void PlayerSound()
    {
        //�ړ����̂݃T�E���h��炷
        if (rb.velocity.magnitude != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(Playerclip);
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
    private void QuestionOpen()
    {
        //���̏o������
        question_openCheck = PlayerAction.Question_OpenChack();
        if(question_openCheck)
        {
            Select_question.GuestionOpen();
        }
    }
}