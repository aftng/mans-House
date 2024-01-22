using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public First_Stage_maneger FirstStage;
    private Object_rotate Object_rotate = null;

    //オブジェクト回転絵番号
    private int ObjectrotateNo;

    [SerializeField]
    private AudioClip Objectclip;

    //コンポーネント取得
    private Rigidbody2D CarryObjectrb;
    private AudioSource CarryObjectAS;
    public Rigidbody2D CarryObject { get { return CarryObjectrb; } }
    private void Update()
    {
        ObjectRotate();
    }
    public void Objectoperation(Vector2 PlayerMove, float ObjectSpeed)
    {
        //ファーストステージをクリアするとオブジェクトを操作出来ない
        if (FirstStage.FirststageClear)
        {
            //機能停止
            CarryObjectStop();
            return;
        }

        if (CarryObjectrb.bodyType != RigidbodyType2D.Dynamic)
        {
            CarryObjectrb.bodyType = RigidbodyType2D.Dynamic;
        }
        CarryObjectrb.velocity = new Vector2(PlayerMove.x, PlayerMove.y).normalized * ObjectSpeed;
        ObjectSound();
    }
    private void ObjectRotate()
    {
        //オブジェクトの回転
        if (Object_rotate == null) { return; }
        ObjectrotateNo = Object_rotate.Objectrotate;
        if (Input.GetButtonDown("Right"))
        {
            ObjectrotateNo++;
        }
        else if (Input.GetButtonDown("Left"))
        {
            ObjectrotateNo--;
        }
        Object_rotate.Objectrotate = ObjectrotateNo;
        Object_rotate.Objectloop();
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
    public void HitChack(Vector2 Anim)
    {
        //石像を掴む
        if (CarryObjectrb == null)
        {
            //レイヤー発射
            Rayfly(Anim);
        }
        else
        {
            //プレイヤーがホールドキーを放したときの処理
            if (Input.GetButtonUp("Objectcatch"))
            {
                CarryObjectStop();
            }
        }
    }

    private void Rayfly(Vector2 dir)
    {
        //レイヤー長さ
        float distance = 0.4f;

        //レイヤーを飛ばして接触判定
        var hits = Physics2D.RaycastAll(transform.position, dir, distance);

        //ヒットしたすべてのオブジェクトを検索
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("statue") && CarryObjectrb == null)
            {
                if (Input.GetButton("Objectcatch") && CarryObjectrb == null)
                {
                    CarryObjectrb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    CarryObjectAS = hit.collider.gameObject.GetComponent<AudioSource>();
                }
                 
                if(Object_rotate == null)
                {
                    Object_rotate = hit.collider.gameObject.GetComponentInChildren<Object_rotate>();
                }
            }
            else
            {
                Object_rotate = null;
            }
        }
    }

    private void CarryObjectStop()
    {
        CarryObjectrb.velocity = Vector2.zero;
        CarryObjectrb.bodyType = RigidbodyType2D.Kinematic;
        CarryObjectAS.Stop();
        CarryObjectrb = null;
        CarryObjectAS = null;
        Object_rotate = null;
    }
}