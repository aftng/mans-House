using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Fade_Out : MonoBehaviour
{
    private Animator animator;
    private bool playerstop = false;
    //�A�j���[�V��������
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
        //�Ă΂ꂽ��A�j���[�V�����Đ�
        animator.SetTrigger("stagechange");
        //�A�j���[�V�������I�������Piayer�𓮂�����悤�ɂ���
        yield return new WaitForSeconds(AnimatorTime);
        playerstop = false;
        Game_Manager.PlayerStop = playerstop;
    }
}