using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Object_rotate Object_rotate;
    //�I�u�W�F�N�g��]
    public bool direction = false;
    private int Objectrotate;
    private int Objectrotatecorrect = 0;
   
    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
         Objectrotate = Object_rotate.objectrotate;

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
