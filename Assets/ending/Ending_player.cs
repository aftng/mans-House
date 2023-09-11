using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_player : MonoBehaviour
{
    //プレイヤー移動
    private float playerspeed = 5.0f;
    private float playermove = -1.0f;
   
    //アニメーション
    private Vector2 lastMove;
    private Vector2 Move;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        //移動             
        rb.velocity = new Vector2(rb.velocity.x, playermove).normalized * playerspeed;
        Move = rb.velocity;
        Animate();
    }
    private void Animate()
    {
        //アニメーション
        if (Mathf.Abs(rb.velocity.x) > 0.5f)
        {
            Move.x = rb.velocity.x;
            lastMove.x = rb.velocity.x;
            lastMove.y = 0;
        }
        if (Mathf.Abs(rb.velocity.y) > 0.5f)
        {
            Move.y = rb.velocity.y;
            lastMove.y = rb.velocity.y;
            lastMove.x = 0;
        }

        animator.SetFloat("Dir_X", Move.x);
        animator.SetFloat("Dir_Y", Move.y);
        animator.SetFloat("LastMove_X", lastMove.x);
        animator.SetFloat("LastMove_Y", lastMove.y);
        animator.SetFloat("Input", rb.velocity.magnitude);
    }
}
