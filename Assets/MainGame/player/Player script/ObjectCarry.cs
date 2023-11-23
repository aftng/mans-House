using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public PlayerAction PlayerAction;
    public First_Stage_maneger FirstStage;
    private Object_rotate Object_rotate;
    private GameObject carryObject;
    public GameObject CarryObject{ get { return carryObject; } }
    //プレイヤからのキー入力
    private bool leftkey;
    private bool rightkey;

    //オブジェクト回転絵番号
    private int ObjectrotateNo;
    private Vector2 ObjectMove;

    [SerializeField]
    private AudioClip Objectclip;

    //コンポーネント取得
    private Rigidbody2D CarryObjectrb;
    private AudioSource CarryObjectAS;
    public void Objectoperation(Vector2 PlayerMove, float ObjectSpeed)
    {
        //ファーストステージをクリアするとオブジェクトを操作出来ない
        if (FirstStage.FirststageClear)
        {
            //機能停止
            carryObject = null;
            CarryObjectrb.velocity = Vector2.zero;
            CarryObjectrb.bodyType = RigidbodyType2D.Static;
            CarryObjectAS.Stop();
            return;
        }
            //オブジェクトの移動       
            ObjectMove = PlayerMove * ObjectSpeed;

        if (CarryObjectrb.bodyType != RigidbodyType2D.Dynamic)
        {
            CarryObjectrb.bodyType = RigidbodyType2D.Dynamic;
        }
        CarryObjectrb.velocity = new Vector2(ObjectMove.x, ObjectMove.y);
        ObjectSound();
    }
    public void ObjectRotate()
    {
        if (FirstStage.FirststageClear) { return; }
        //オブジェクトの回転
        rightkey = PlayerAction.RotateRightChack();
        leftkey = PlayerAction.RotateLeftChack();
        ObjectrotateNo = Object_rotate.Objectrotate;
        if (rightkey)
        {
            ObjectrotateNo++;
        }
        else if (leftkey)
        {
            ObjectrotateNo--;
        }
        Object_rotate.Objectrotate = ObjectrotateNo;
        Object_rotate.Objectloop();
    }
    public void ObjectMoveStop()
    {
        //プレイヤーがホールドキーを放したときの処理
        if(CarryObjectrb.bodyType != RigidbodyType2D.Kinematic)
        {
            CarryObjectrb.velocity = Vector2.zero;
            CarryObjectrb.bodyType = RigidbodyType2D.Kinematic;
            CarryObjectAS.Stop();
        }       
    }
    private void ObjectSound()
    {
        //移動時のみサウンドを鳴らす
        if (CarryObjectrb.velocity.magnitude != 0)
        {
            if (!CarryObjectAS.isPlaying)
            {
                CarryObjectAS.PlayOneShot(Objectclip);
            }
        }
        else
        {
            if (CarryObjectAS.isPlaying)
            {
                CarryObjectAS.Stop();
            }
        }
    }

    public void GetObject(GameObject Object)
    {
        //コンポーネント取得
        CarryObjectrb = Object.GetComponent<Rigidbody2D>();
        CarryObjectAS = Object.GetComponent<AudioSource>();
        Object_rotate = Object.GetComponentInChildren<Object_rotate>();
    }
    public void OutObject()
    {
        //オブジェクト破棄
        CarryObjectrb.velocity = Vector2.zero;
        CarryObjectAS.Stop();
        CarryObjectrb = null;
        Object_rotate = null;
        CarryObjectAS = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //掴めるオブジェクトのコンポーネント取得
        if (collision.gameObject.tag == "statue" && carryObject == null)
        {
            //ファーストステージをクリアするとオブジェクトを取得しない
            if (FirstStage.FirststageClear) { return; }
            carryObject = collision.gameObject;
            GetObject(carryObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //掴めるオブジェクトのコンポーネント破棄
        if (collision.gameObject == carryObject)
        {
            OutObject();
            carryObject = null;
        }
    }
}
