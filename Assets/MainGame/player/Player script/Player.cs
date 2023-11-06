using UnityEngine;

public class Player : MonoBehaviour
{
    public UpChack UpChack;
    public DownChack DownChack;
    public RigthChack RigthChack;
    public LeftChack LeftChack;
    public PlayerAction PlayerAction;
    public Game_Manager Game_Manager;
    public First_Stage_maneger FirstStage;
    public ObjectCarry ObjectCarry;

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

    private Vector2 lastMove;
    private Vector2 AnimateMove;

    private GameObject CarryObject;

    [SerializeField]
    private AudioClip Playerclip;

    //�R���|�[�l���g�擾
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player_speed = moveSpeed;
    }
    void Update()
    {
        //���̃X�N���v�g�ϐ��擾
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();
        HoldChack = PlayerAction.HoldChack();
        playerstop = Game_Manager.PlayerStop;
        //�ړ�����
        playermove.x = Input.GetAxisRaw("Horizontal");
        playermove.y = Input.GetAxisRaw("Vertical");

        //�΂߈ړ��֎~
        if (playermove.x != 0 && playermove.y != 0)
        {
            playermove = Vector2.zero;
        }
        MoveObjectsSpeed();
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
    private void MoveObjectsSpeed()
    {
        //�I�u�W�F�N�g�ړ����̃X�s�[�h
        if (CarryObject != null)
        {
            if ( HoldChack && (isUpChack || isDownChack))
            {
                player_speed = Objectcarryspeed;
                playermove.x = 0;
                ObjectCarry.ObjectMove(playermove, player_speed);
            }
            else if (HoldChack && (isRigthChack || isLeftChack))
            {
                player_speed = Objectcarryspeed;
                playermove.y = 0;
                ObjectCarry.ObjectMove(playermove, player_speed);
            }
            else
            {
                player_speed = moveSpeed;
                ObjectCarry.ObjectMoveStop();
            }
        }
    }
    private void Animate()
    {
        //�I�u�W�F�N�g�ړ�����Player�̌������Œ肷�邽�߂̕ϐ���1��-1�Ō������Ǘ�
        float directionStop = 1;

        if (Mathf.Abs(rb.velocity.x) > 0.5f)
        {
            if (HoldChack && isLeftChack)
            {
                AnimateMove.x = -directionStop;
                lastMove.x = AnimateMove.x;
                lastMove.y = 0;
            }
            else if (HoldChack && isRigthChack)
            {
                AnimateMove.x = directionStop;
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
        else if (Mathf.Abs(rb.velocity.y) > 0.5f)
        {
            if (HoldChack && isUpChack)
            {
                AnimateMove.y = directionStop;
                lastMove.y = AnimateMove.y;
                lastMove.x = 0;
            }
            else if (HoldChack && isDownChack)
            {
                AnimateMove.y = -directionStop;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object" && CarryObject == null)
        {   //�͂߂�I�u�W�F�N�g�̃R���|�[�l���g�擾
            //�t�@�[�X�g�X�e�[�W���N���A����ƃI�u�W�F�N�g�͈ړ��ł��Ȃ�
            if (FirstStage.FirststageClear) { return; }
            CarryObject = collision.gameObject;
            ObjectCarry.GetObject(CarryObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == CarryObject)
        {
            //�͂߂�I�u�W�F�N�g�̃R���|�[�l���g�j��
            ObjectCarry.OutObject();
            CarryObject = null;
        }
    }
}