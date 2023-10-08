using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstStage_door : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraMan;
    //フェードアウト
    private Fade_Out Fade_Out;

    //プレイヤー移動位置
    private float Playerposition = 21.5f;
    //ステージチェンジチェック
    private bool stageChange = false;
   //ステージクリア判定
    private First_Stage_maneger First_Stage;
    private bool Clear;
    //カメラ移動位置
    private Game_Manager Game_Manager;
    private float cameraposition;
    private void Start()
    {
        Fade_Out = FindAnyObjectByType<Fade_Out>();
        First_Stage = FindObjectOfType<First_Stage_maneger>();
        Game_Manager = FindObjectOfType<Game_Manager>();
        cameraposition = Game_Manager.Cameraposition[1];
    }
    void Update()
    {
        //ファーストステージをクリアしているか
        Clear = First_Stage.FirststageClear;
        if (stageChange && Clear)
        {        
            stageChange = false;
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
            stageChange = true;
        }
    }
}

