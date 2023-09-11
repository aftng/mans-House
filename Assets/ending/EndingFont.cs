using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFont : MonoBehaviour
{
    //Fontスピード
    private float Speed = 0.045f;
    
    //フォントの現在位置と止まる場所
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
        //シーン変換するまで3秒待つ
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title");
    }
}
