using UnityEngine;

public class ClarChack : MonoBehaviour
{
    public Object_rotate Object_rotate;
    public Object Tile;

    //正解のオブジェクト回転番号
    [SerializeField]
    private int Objectrotatecorrect;

    private int Objectrotate;
    private bool TileHitChack = false;
    private bool clearChack = false;

    public bool ObjectClearChack()
    {
        //他のスクリプトから変数取得
        Objectrotate = Object_rotate.Objectrotate;
        //オブジェクト正判定
        if (Objectrotate == Objectrotatecorrect && TileHitChack)
        {
            clearChack = true;
        }
        else
        {
            clearChack = false;
        }
        return clearChack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Tile)
        {
            TileHitChack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Tile)
        {
            TileHitChack = false;
        }
    }
}