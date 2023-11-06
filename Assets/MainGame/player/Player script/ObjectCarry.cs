using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public PlayerAction PlayerAction;
    public First_Stage_maneger FirstStage;
    private Object_rotate Object_rotate;
   
    //プレイヤからのキー入力
    private bool leftkey;
    private bool rightkey;
    private bool HoldChack;

    private int ObjectrotateNo;
    private Vector2 PlayerMove;

    [SerializeField]
    private AudioClip Objectclip;

    private GameObject CarryObject;
    private Rigidbody2D CarryObjectrb;
    private AudioSource CarryObjectAS;
    void Update()
    {
        //他のスクリプトから変数取得
        rightkey = PlayerAction.RotateRightChack();
        leftkey = PlayerAction.RotateLeftChack();
        HoldChack = PlayerAction.HoldChack();
    }
    public void ObjectMove(Vector2 ObjectMove, float ObjectSpeed)
    {
        PlayerMove = ObjectMove * ObjectSpeed;

        //オブジェクトの移動       
        CarryObjectrb.bodyType = RigidbodyType2D.Dynamic;
        CarryObjectrb.velocity = new Vector2(PlayerMove.x, PlayerMove.y);  
        
        //オブジェクトの回転
        {
            ObjectrotateNo = Object_rotate.Objectrotate;
            if(rightkey)
            {
                ObjectrotateNo++;
            }
            else if(leftkey)
            {
                ObjectrotateNo--;
            }
            Object_rotate.Objectrotate = ObjectrotateNo;
        }
        ObjectSound();
    }
    public void ObjectMoveStop()
    {
        //プレイヤーがホールドキーを放したときの処理
        CarryObjectrb.velocity = Vector2.zero;
        CarryObjectrb.bodyType = RigidbodyType2D.Kinematic;
        CarryObjectAS.Stop();
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
        CarryObject = Object;
        CarryObjectrb = CarryObject.GetComponent<Rigidbody2D>();
        CarryObjectAS = CarryObject.GetComponent<AudioSource>();
        Object_rotate = CarryObject.GetComponentInChildren<Object_rotate>();
    }

    public void OutObject()
    {
        CarryObjectrb.velocity = Vector2.zero;
        CarryObjectAS.Stop();
        CarryObjectrb = null;
        Object_rotate = null;
        CarryObjectAS = null;
        CarryObject = null;
    }   
}
