using UnityEngine;

public class Ending_player : MonoBehaviour
{
    //プレイヤー移動
    private float Playerspeed = 5.0f;
    private float Playermove = -1.0f;
   
    //アニメーション
    private Vector2 lastMove;
    private Vector2 Move;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        //移動             
        rb.velocity = new Vector2(rb.velocity.x, Playermove).normalized * Playerspeed;
        Move = rb.velocity;
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
}
