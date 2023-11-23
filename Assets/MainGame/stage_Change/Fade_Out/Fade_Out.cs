using System.Collections;
using UnityEngine;

public class Fade_Out : MonoBehaviour
{
    private Animator animator;
    //アニメーション時間
    private float AnimatorTime = 2.5f;
    public Gameprogress Gameprogress;
    void Start()
    {
         animator = GetComponent<Animator>();
    }
    public void Fade_out()
    {
        Gameprogress.PlayerStop = true;
        StartCoroutine(Fade_outTime());              
    }
    IEnumerator Fade_outTime()
    {
        //呼ばれたらアニメーション再生
        animator.SetTrigger("stagechange");
        //アニメーションが終わったらPiayerを動かせるようにする
        yield return new WaitForSeconds(AnimatorTime);
          Gameprogress.PlayerStop = false;
    }
}