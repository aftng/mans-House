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
    //�v���C������̃L�[����
    private bool leftkey;
    private bool rightkey;

    //�I�u�W�F�N�g��]�G�ԍ�
    private int ObjectrotateNo;
    private Vector2 ObjectMove;

    [SerializeField]
    private AudioClip Objectclip;

    //�R���|�[�l���g�擾
    private Rigidbody2D CarryObjectrb;
    private AudioSource CarryObjectAS;
    public void Objectoperation(Vector2 PlayerMove, float ObjectSpeed)
    {
        //�t�@�[�X�g�X�e�[�W���N���A����ƃI�u�W�F�N�g�𑀍�o���Ȃ�
        if (FirstStage.FirststageClear)
        {
            //�@�\��~
            carryObject = null;
            CarryObjectrb.velocity = Vector2.zero;
            CarryObjectrb.bodyType = RigidbodyType2D.Static;
            CarryObjectAS.Stop();
            return;
        }
            //�I�u�W�F�N�g�̈ړ�       
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
        //�I�u�W�F�N�g�̉�]
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
        //�v���C���[���z�[���h�L�[��������Ƃ��̏���
        if(CarryObjectrb.bodyType != RigidbodyType2D.Kinematic)
        {
            CarryObjectrb.velocity = Vector2.zero;
            CarryObjectrb.bodyType = RigidbodyType2D.Kinematic;
            CarryObjectAS.Stop();
        }       
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
        //�R���|�[�l���g�擾
        CarryObjectrb = Object.GetComponent<Rigidbody2D>();
        CarryObjectAS = Object.GetComponent<AudioSource>();
        Object_rotate = Object.GetComponentInChildren<Object_rotate>();
    }
    public void OutObject()
    {
        //�I�u�W�F�N�g�j��
        CarryObjectrb.velocity = Vector2.zero;
        CarryObjectAS.Stop();
        CarryObjectrb = null;
        Object_rotate = null;
        CarryObjectAS = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�͂߂�I�u�W�F�N�g�̃R���|�[�l���g�擾
        if (collision.gameObject.tag == "statue" && carryObject == null)
        {
            //�t�@�[�X�g�X�e�[�W���N���A����ƃI�u�W�F�N�g���擾���Ȃ�
            if (FirstStage.FirststageClear) { return; }
            carryObject = collision.gameObject;
            GetObject(carryObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�͂߂�I�u�W�F�N�g�̃R���|�[�l���g�j��
        if (collision.gameObject == carryObject)
        {
            OutObject();
            carryObject = null;
        }
    }
}
