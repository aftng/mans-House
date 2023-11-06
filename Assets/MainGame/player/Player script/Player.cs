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

    //プレイヤーの現在スピード
    private float player_speed;
    private Vector2 playermove;

    private bool playerstop = false;
    private bool HoldChack;

    private Vector2 lastMove;
    private Vector2 AnimateMove;

    private GameObject CarryObject;

    [SerializeField]
    private AudioClip Playerclip;

    //コンポーネント取得
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
        //他のスクリプト変数取得
        isUpChack = UpChack.IsUpChack();
        isRigthChack = RigthChack.IsRigthChack();
        isLeftChack = LeftChack.IsLeftChack();
        isDownChack = DownChack.IsDownChack();
        HoldChack = PlayerAction.HoldChack();
        playerstop = Game_Manager.PlayerStop;
        //移動入力
        playermove.x = Input.GetAxisRaw("Horizontal");
        playermove.y = Input.GetAxisRaw("Vertical");

        //斜め移動禁止
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
        //オブジェクト移動時のスピード
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
        //オブジェクト移動時のPlayerの向きを固定するための変数を1か-1で向きを管理
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object" && CarryObject == null)
        {   //掴めるオブジェクトのコンポーネント取得
            //ファーストステージをクリアするとオブジェクトは移動できない
            if (FirstStage.FirststageClear) { return; }
            CarryObject = collision.gameObject;
            ObjectCarry.GetObject(CarryObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == CarryObject)
        {
            //掴めるオブジェクトのコンポーネント破棄
            ObjectCarry.OutObject();
            CarryObject = null;
        }
    }
}