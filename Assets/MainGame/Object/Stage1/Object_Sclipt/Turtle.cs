using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public Object_rotate Object_rotate;
    //�I�u�W�F�N�g��]
    private int Objectrotatecorrect = 3;
    private int Objectrotate;
    private bool direction = false;
    public bool Direction
    {
        get { return direction; }
    }
    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
        Objectrotate = Object_rotate.Objectrotate;

        //�I�u�W�F�N�g������
        if (Objectrotate == Objectrotatecorrect)
        {
            direction = true;
        }
        else
        {
            direction = false;
        }
    }
}
