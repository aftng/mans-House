using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    public Player_Chack PlayerChack;
    private First_Stage_maneger FirstStage;
    private PlayerAction PlayerAction;
    //オブジェクト回転
    private int objectrotate = 0;
    public int Objectrotate
    {
        get { return objectrotate; }
    }
    //オブジェクト回転絵取得
    [SerializeField]
    Sprite[] objectSprite;

    //コンポーネント取得
    private SpriteRenderer sr;

    //プレイヤからのキー入力
    private bool leftkey;
    private bool rightkey;

    //回転回数
    private int rotateminimum = -1;
   
    //プレイヤ接触判定
    private bool isplayer;

    //クリア判定
    private bool StageClear;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        FirstStage = FindObjectOfType<First_Stage_maneger>();
        PlayerAction = FindObjectOfType<PlayerAction>();
        sr.sprite = objectSprite[0];
    }

    void Update()
    {     
        StageClear = FirstStage.FirststageClear;

        //ステージをクリアしたら機能停止
        if (StageClear) { return; }

        //他のスクリプトから変数取得
        isplayer = PlayerChack.IsPlayerChack();
        rightkey = PlayerAction.RotateRightChack();
        leftkey = PlayerAction.RotateLeftChack();
        PLayerkeyChack();
    }
    private void PLayerkeyChack()
    {
        if (isplayer)
        {
            //プレイヤーからの入力
            if (rightkey == true)
            {
                objectrotate++;
            }
            if (leftkey)
            {
                objectrotate--;
            }
            Objrotate();
        }
    }
    private void Objrotate()
    {
        //オブジェクト回転ループ
        if (objectrotate >= objectSprite.Length)
        {
            //objectrotateが3以上になったら0にする
            objectrotate = rotateminimum + 1;
        }
        if (objectrotate <= rotateminimum)
        {
            //objectrotateが-1以下になったら3にする
            objectrotate = objectSprite.Length - 1;
        }
        sr.sprite = objectSprite[objectrotate];
    }
}
