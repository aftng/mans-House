using UnityEngine;

public class Player : MonoBehaviour
{
    //���̃X�N���v�g�擾
    public Gameprogress Gameprogress;
    public ObjectCarry ObjectCarry;
    public Select_question Select_question;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float Objectcarryspeed = 1;

    //�v���C���[�̌��݃X�s�[�h
    private float player_speed;
    private Vector2 playermove;

    private bool playerstop = false;

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
        playerstop = Gameprogress.PlayerStop;

        //�ړ�����
        playermove.x = Input.GetAxisRaw("Horizontal");
        playermove.y = Input.GetAxisRaw("Vertical");

        //�΂߈ړ��֎~
        if (playermove.x != 0 && playermove.y != 0)
        {
            playermove = Vector2.zero;
        }
        QuestionOpen();
        Animate();
        PlayerSound();
        ObjectCarry.HitChack(lastMove);
    }
    void FixedUpdate()
    {
        if (playerstop)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        Objectsoperation();
        rb.velocity = new Vector2(playermove.x, playermove.y).normalized * player_speed;
    }
    private void Objectsoperation()
    {
        if (ObjectCarry.CarryObject != null)
        {
            //�I�u�W�F�N�g�ړ����̃X�s�[�h�ƃI�u�W�F�N�g�ړ�
            if (Input.GetButton("Objectcatch"))
            {
                if (lastMove.y != 0)
                {
                    player_speed = Objectcarryspeed;
                    playermove.x = 0;
                    ObjectCarry.Objectoperation(playermove, player_speed);
                }
                else if (lastMove.x != 0)
                {
                    player_speed = Objectcarryspeed;
                    playermove.y = 0;
                    ObjectCarry.Objectoperation(playermove, player_speed);
                }
            }
        }
        else
        {
            player_speed = moveSpeed;
        }
    }
    private void Animate()
    {
        //�A�j���[�V����
        if (ObjectCarry.CarryObject == null)
        {
            if (Mathf.Abs(rb.velocity.x) > 0.5f)
            {
                AnimateMove = rb.velocity;
                lastMove = new Vector2(AnimateMove.x, 0);
            }
            else if (Mathf.Abs(rb.velocity.y) > 0.5f)
            {
                AnimateMove = rb.velocity;
                lastMove = new Vector2(0, AnimateMove.y);
            }
        }
        else
        {
            //�I�u�W�F�N�g�ړ����̃A�j���[�V����
            AnimateMove = lastMove;
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
        if (Input.GetButtonDown("Question_Open"))
        {
            Select_question.GuestionOpen();
        }
    }
}