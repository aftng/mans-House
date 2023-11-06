using UnityEngine;

public class Object_Sound_rotate : MonoBehaviour
{
    //他のスクリプト
    private PlayerAction PlayerAction;
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
        PlayerAction = FindObjectOfType<PlayerAction>();
        soundrotate = 0;
    }
    void Update()
    {
        rightkey = PlayerAction.RotateRightChack();
        leftkey = PlayerAction.RotateLeftChack();
        PushChack = PlayerAction.DecisionChack();

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
        //サウンドループ
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
        if (isplayer && PushChack)
        {           
           audioSource.PlayOneShot(clip[soundrotate]);
        }
        return soundrotate;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = false;
        }
    }
}