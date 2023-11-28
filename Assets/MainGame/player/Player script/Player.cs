using UnityEngine;

public class Player : MonoBehaviour
{
    //他のスクリプト取得
    public Gameprogress Gameprogress;
    public ObjectCarry ObjectCarry;
    public Select_question Select_question;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float Objectcarryspeed = 1;

    //プレイヤーの現在スピード
    private float player_speed;
    private Vector2 playermove;

    private bool playerstop = false;

    //アニメーション制御
    private Vector2 lastMove;
    private Vector2 AnimateMove;

    [SerializeField]
    private AudioClip Playerclip;

    //コンポーネント
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
        //他のスクリプト変数取得
        playerstop = Gameprogress.PlayerStop;

        //移動入力
        playermove.x = Input.GetAxisRaw("Horizontal");
        playermove.y = Input.GetAxisRaw("Vertical");

        //斜め移動禁止
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
            //オブジェクト移動時のスピードとオブジェクト移動
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
        //アニメーション
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
            //オブジェクト移動時のアニメーション
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
        //移動時のみサウンドを鳴らす
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
        //問題の出し入れ
        if (Input.GetButtonDown("Question_Open"))
        {
            Select_question.GuestionOpen();
        }
    }
}