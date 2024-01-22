using UnityEngine;

public class Opning_player : MonoBehaviour
{
    private float player_speed = 5;
    private float playermove  =1;

    //アニメーション
    private Vector2 lastMove;
    private Vector2 Move;
    private Animator animator;
    private Rigidbody2D rb;
    //オーディオ
    private AudioSource audioSource;

    [SerializeField]
    AudioClip clip;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x ,playermove).normalized * player_speed;
        Move = rb.velocity;
        PlayFootstepSound();
        Animate();
    }
    private void Animate()
    {
        //アニメーション
        Move.y = rb.velocity.y;
        lastMove.y = rb.velocity.y;
        lastMove.x = 0;

        animator.SetFloat("Dir_X", Move.x);
        animator.SetFloat("Dir_Y", Move.y);
        animator.SetFloat("LastMove_X", lastMove.x);
        animator.SetFloat("LastMove_Y", lastMove.y);
        animator.SetFloat("Input", rb.velocity.magnitude);
    }
    private void PlayFootstepSound()
    {
        //オーディオ
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