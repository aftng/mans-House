using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    public Player_Chack Player_Chack;
    private First_Stage_maneger First_Stage;
    private Player_rotate Player_rotate;
    //オブジェクト回転
    public int objectrotate = 0;
    //オブジェクト回転絵取得
    [SerializeField]
    Sprite[] objectSprite;

    //コンポーネント取得
    private SpriteRenderer sr;

    //プレイヤからのキー入力
    private bool leftkey = false;
    private bool rightkey = false;

    //回転回数
    private int rotateminimum = -1;
   
    //プレイヤ接触判定
    private bool isplayer = false;

    //クリア判定
    private bool Clear;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        this.First_Stage = FindObjectOfType<First_Stage_maneger>();
        this.Player_rotate = FindObjectOfType<Player_rotate>();
        sr.sprite = objectSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        //他のスクリプトから変数取得
        isplayer = Player_Chack.IsPlayerChack();
        Clear = First_Stage.FirststageClear;
        rightkey = Player_rotate.Rightkey;
        leftkey = Player_rotate.Leftkey;
        if (!Clear)
        {  
            if (isplayer)
            {
                //プレイヤーからの入力
                if(rightkey)
                {
                    objectrotate++;
                }
                if(leftkey)
                {
                    objectrotate--;
                }
            }
            objrotate();
        }
    }

    private void objrotate()
    {
        //オブジェクト回転
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
