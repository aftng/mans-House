using UnityEngine;

public class ClarChack : MonoBehaviour
{
    public Object_rotate Object_rotate;
    public Object Tile;

    //�����̃I�u�W�F�N�g��]�ԍ�
    [SerializeField]
    private int Objectrotatecorrect;

    private int Objectrotate;
    private bool TileHitChack = false;
    private bool clearChack = false;

    public bool ObjectClearChack()
    {
        //���̃X�N���v�g����ϐ��擾
        Objectrotate = Object_rotate.Objectrotate;
        //�I�u�W�F�N�g������
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