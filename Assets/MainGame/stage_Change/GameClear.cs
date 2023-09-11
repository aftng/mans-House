using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    //フェードアウト
    public Fade_Out Fade;
    //ステージクリアチェック
    private bool stageChange = false;
    void Update()
    {
        if (stageChange)
        {
            stageChange = false;
            Fade.Fade_out();
            StartCoroutine(StageChange());
        }
    }
    IEnumerator StageChange()
    {
        //フェードアウトするまで1.5秒待つ
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("ending");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stageChange = true;
        }
    }
}
