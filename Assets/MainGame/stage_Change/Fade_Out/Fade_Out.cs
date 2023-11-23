using System.Collections;
using UnityEngine;

public class Fade_Out : MonoBehaviour
{
    private Animator animator;
    //�A�j���[�V��������
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
        //�Ă΂ꂽ��A�j���[�V�����Đ�
        animator.SetTrigger("stagechange");
        //�A�j���[�V�������I�������Piayer�𓮂�����悤�ɂ���
        yield return new WaitForSeconds(AnimatorTime);
          Gameprogress.PlayerStop = false;
    }
}