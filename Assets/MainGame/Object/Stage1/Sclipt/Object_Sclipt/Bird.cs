using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Object_rotate Object_rotate;
    public Object Tile;

    //�I�u�W�F�N�g��]
    private int Objectrotatecorrect = 0;
    private int Objectrotate;

    private bool touchChack = false;
    private bool clearChack = false;

    public bool ObjectClearChack()
    {
        //���̃X�N���v�g����ϐ��擾
        Objectrotate = Object_rotate.Objectrotate;
        //�I�u�W�F�N�g������
        if (Objectrotate == Objectrotatecorrect && touchChack)
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
            touchChack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Tile)
        {
            touchChack = false;
        }
    }
}