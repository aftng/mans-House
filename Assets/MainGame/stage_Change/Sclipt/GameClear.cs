using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    //�t�F�[�h�A�E�g
    private Fade_Out Fade_Out;
    void Start()
    {
        Fade_Out = FindAnyObjectByType<Fade_Out>();
    }
    IEnumerator StageChange()
    {
        //�t�F�[�h�A�E�g����܂�1.5�b�҂�
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("ending");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Fade_Out.Fade_out();
            StartCoroutine(StageChange());
        }
    }
}
