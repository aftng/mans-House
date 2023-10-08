using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    //フェードアウト
    private Fade_Out Fade_Out;
    //ステージクリアチェック
    private bool stageChange = false;
    void Start()
    {
        Fade_Out = FindAnyObjectByType<Fade_Out>();
    }
    void Update()
    {
        if (stageChange)
        {
            stageChange = false;
            Fade_Out.Fade_out();
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
