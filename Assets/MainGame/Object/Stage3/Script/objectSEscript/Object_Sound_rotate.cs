using UnityEngine;

public class Object_Sound_rotate : MonoBehaviour
{
    //���̃X�N���v�g
    private PlayerAction PlayerAction;
    //�v���C���ڐG����
    private bool isplayer = false;
    public bool IsPlayer { get { return isplayer; } }
    //�v���C������̃L�[����
    private bool leftkey = false;
    private bool rightkey = false;
    //���[�v�̍Œ�l
    private int rotateminimum = -1;

    //�I�[�f�B�I
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
        //�ڐG����
        if (isplayer)      
        {
            rightkey = PlayerAction.RotateRightChack();
            leftkey = PlayerAction.RotateLeftChack();
            //�v���C���[����̓���
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
        //�T�E���h���[�v
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