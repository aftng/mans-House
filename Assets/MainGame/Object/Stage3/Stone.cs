using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    //他スクリプト
    public Object_Sound_rotate Object_Sound_rotate;
    public Sound_Player_Chack Player_Chack;
    private Third_Stage_Gamemaneger third_Stage_Gamemanege;
    private Second_Stage_Gamemaneger Second_Stage_Gamemaneger;
    private Player_grasp Player_grasp;

    //サウンドクリア順番カウント
    private int clearcount;

    //player決定ボタンカウント
    private bool PushChack;

    //player接触判定
    private bool isplayer;

    //サウンドクリア順番
    private int soundorder;

    //サウンド選択
    private int Soundrotate;

    //サウンド正解数
    private int stoneClearrotate = 4;
    void Start()
    {
        this.Player_grasp = FindObjectOfType<Player_grasp>();
        this.third_Stage_Gamemanege = FindObjectOfType<Third_Stage_Gamemaneger>();
        this.Second_Stage_Gamemaneger = FindObjectOfType<Second_Stage_Gamemaneger>();
        soundorder = Second_Stage_Gamemaneger.Orderdoor[2];
    }

    void Update()
    {
        //他のスクリプトから変数取得
        Soundrotate = Object_Sound_rotate.SEselect();
        PushChack = Player_grasp.Push;
        isplayer = Player_Chack.IsPlayerChack();
        clearcount =  third_Stage_Gamemanege.Clearcount;

        //オブジェクト正判定
        if (isplayer　&& PushChack)
        {
            if (Soundrotate == stoneClearrotate && clearcount == soundorder)
            {
                clearcount++;
            }
            else
            {
                clearcount = 0;
            }
        }
        third_Stage_Gamemanege.Clearcount = clearcount;
    }
}
