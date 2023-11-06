using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public PlayerAction PlayerAction;
    public First_Stage_maneger FirstStage;
    private Object_rotate Object_rotate;
   
    //�v���C������̃L�[����
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
        //���̃X�N���v�g����ϐ��擾
        rightkey = PlayerAction.RotateRightChack();
        leftkey = PlayerAction.RotateLeftChack();
        HoldChack = PlayerAction.HoldChack();
    }
    public void ObjectMove(Vector2 ObjectMove, float ObjectSpeed)
    {
        PlayerMove = ObjectMove * ObjectSpeed;

        //�I�u�W�F�N�g�̈ړ�       
        CarryObjectrb.bodyType = RigidbodyType2D.Dynamic;
        CarryObjectrb.velocity = new Vector2(PlayerMove.x, PlayerMove.y);  
        
        //�I�u�W�F�N�g�̉�]
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
        //�v���C���[���z�[���h�L�[��������Ƃ��̏���
        CarryObjectrb.velocity = Vector2.zero;
        CarryObjectrb.bodyType = RigidbodyType2D.Kinematic;
        CarryObjectAS.Stop();
    }
    private void ObjectSound()
    {
        //�ړ����̂݃T�E���h��炷
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
