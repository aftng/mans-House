using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Fade_Out : MonoBehaviour
{
    private Animator animator;
    private bool playerstop = false;
    //アニメーション時間
    private float AnimatorTime = 2.5f;
    private Game_Manager Game_Manager;
    
    void Start()
    {
         animator = GetComponent<Animator>();
        Game_Manager = FindObjectOfType<Game_Manager>();  
    }
    public void Fade_out()
    {
        playerstop = true;
        Game_Manager.PlayerStop = playerstop;
        StartCoroutine(Fade_outTime());              
    }
    IEnumerator Fade_outTime()
    {
        //呼ばれたらアニメーション再生
        animator.SetTrigger("stagechange");
        //アニメーションが終わったらPiayerを動かせるようにする
        yield return new WaitForSeconds(AnimatorTime);
        playerstop = false;
        Game_Manager.PlayerStop = playerstop;
    }
}