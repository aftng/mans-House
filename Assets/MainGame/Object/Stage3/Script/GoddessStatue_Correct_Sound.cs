using UnityEngine;

public class GoddessStatue_Correct_Sound : MonoBehaviour
{
    //他スクリプト
    public Object_Sound_rotate Object_Sound_rotate;
    private Third_Stage_Gamemaneger third_Stage_Gamemanege;

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
        third_Stage_Gamemanege = FindObjectOfType<Third_Stage_Gamemaneger>();
    }

    void Update()
    {
        //他のスクリプトから変数取得
        isplayer = Object_Sound_rotate.IsPlayer;

        //オブジェクトの音の高さの正判定
        if (isplayer && Input.GetButtonDown("Objectcatch"))
        {
            Soundrotate = Object_Sound_rotate.SEselect();
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