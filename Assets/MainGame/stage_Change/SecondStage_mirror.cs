using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStage_mirror : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraMan;
    //フェードアウト
    private Fade_Out Fade_Out;
    //プレイヤー移動位置
    private float Playerposition = 29.4f;
    //ステージチェンジチェック
    private bool changeCheck = false;
    public bool ChangeCheck
    {
        get { return changeCheck; }
    }
    //カメラ移動位置

    private Game_Manager Game_Manager;
    private float cameraposition;
    void Start()
    {
        Fade_Out = FindAnyObjectByType<Fade_Out>();
        Game_Manager = FindObjectOfType<Game_Manager>();
        cameraposition = Game_Manager.Cameraposition[1];
    }
    void Update()
    { 
        if (changeCheck)
        {
            changeCheck = false;
            Fade_Out.Fade_out();
            StartCoroutine(StageChange());
        }
    }
    IEnumerator StageChange()
    {
        //フェードアウトするまで1秒待つ
        yield return new WaitForSeconds(1);
        //プレイヤー座標変更
        {
            Vector3 PlayerPos = player.transform.position;
            player.transform.position = new Vector3(
                PlayerPos.x, Playerposition, PlayerPos.z);
        }
        //カメラ座標変更
        {
            Vector3 CamerarPos = cameraMan.transform.position;
            cameraMan.transform.position = new Vector3(
               CamerarPos.x, cameraposition, CamerarPos.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player)
        {
            changeCheck = true;
        }
    }
}
