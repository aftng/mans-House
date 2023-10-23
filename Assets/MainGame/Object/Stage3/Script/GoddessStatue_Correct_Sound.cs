using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoddessStatue_Correct_Sound : MonoBehaviour
{
    //他スクリプト
    public Object_Sound_rotate Object_Sound_rotate;
    public Sound_Player_Chack Player_Chack;
    private Third_Stage_Gamemaneger third_Stage_Gamemanege;
    private PlayerAction PlayerAction;

    //player決定ボタン
    private bool PushChack;

    //player接触判定
    private bool isplayer;

    //サウンドクリア順番
    [SerializeField]
    private int correctorder;

    [SerializeField]
    private int secondcorrectorder;
    //サウンド選択
    private int Soundrotate;

    //サウンド正解数
    [SerializeField]
    private int ObjectrotateChack;
    void Start()
    {
        PlayerAction = FindObjectOfType<PlayerAction>();
        third_Stage_Gamemanege = FindObjectOfType<Third_Stage_Gamemaneger>();
    }

    void Update()
    {
        //他のスクリプトから変数取得
        Soundrotate = Object_Sound_rotate.SEselect();
        PushChack = PlayerAction.DecisionChack();
        isplayer = Player_Chack.IsPlayerChack();

        //オブジェクトの音の高さの正判定
        if (isplayer && PushChack)
        {
            if (Soundrotate == ObjectrotateChack)
            {
                third_Stage_Gamemanege.TwoOrdertChack(correctorder, secondcorrectorder);
            }
            else
            {
                //オブジェクトの音の高さが違う場合0を返す
                third_Stage_Gamemanege.OrderChack(0);
            }
        }
    }
}