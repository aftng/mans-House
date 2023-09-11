using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFont : MonoBehaviour
{
    //Font�X�s�[�h
    private float Speed = 0.045f;
    
    //�t�H���g�̌��݈ʒu�Ǝ~�܂�ꏊ
    private float FontPosY;
    private float FontstopPos = 0.0f;
    void FixedUpdate()
    {
        FontPosY = this.transform.position.y;
        if ( FontPosY >= FontstopPos)
        {           
           transform.position -= new Vector3(0, 1, 0) * Speed;
        }
        else
        {
            StartCoroutine(SceneChange());
        }
    }
    IEnumerator SceneChange()
    {
        //�V�[���ϊ�����܂�3�b�҂�
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title");
    }
}
