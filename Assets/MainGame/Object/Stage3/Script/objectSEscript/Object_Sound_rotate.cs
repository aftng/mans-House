using UnityEngine;

public class Object_Sound_rotate : MonoBehaviour
{
    //他のスクリプト
    private PlayerAction PlayerAction;
    //プレイヤ接触判定
    private bool isplayer = false;
    public bool IsPlayer { get { return isplayer; } }
    //プレイヤからのキー入力
    private bool leftkey = false;
    private bool rightkey = false;
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
        soundrotate = 0;
    }
    void Update()
    {
        //接触判定
        if (isplayer)      
        {
            rightkey = PlayerAction.RotateRightChack();
            leftkey = PlayerAction.RotateLeftChack();
            //プレイヤーからの入力
            if (rightkey)
            {
                soundrotate++;
                SErotate();
            }
            if (leftkey)
            {
                soundrotate--;
                SErotate();
            }
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
        audioSource.PlayOneShot(clip[soundrotate]);
    }

    public int SEselect()
    {                
        audioSource.PlayOneShot(clip[soundrotate]);
        return soundrotate;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = true;
            PlayerAction = collision.gameObject.GetComponent<PlayerAction>();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = false;
            PlayerAction = null;
        }
    }
}