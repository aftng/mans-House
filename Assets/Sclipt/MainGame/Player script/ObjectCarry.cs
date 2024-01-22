using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public First_Stage_maneger FirstStage;
    private Object_rotate Object_rotate = null;

    //�I�u�W�F�N�g��]�G�ԍ�
    private int ObjectrotateNo;

    [SerializeField]
    private AudioClip Objectclip;

    //�R���|�[�l���g�擾
    private Rigidbody2D CarryObjectrb;
    private AudioSource CarryObjectAS;
    public Rigidbody2D CarryObject { get { return CarryObjectrb; } }
    private void Update()
    {
        ObjectRotate();
    }
    public void Objectoperation(Vector2 PlayerMove, float ObjectSpeed)
    {
        //�t�@�[�X�g�X�e�[�W���N���A����ƃI�u�W�F�N�g�𑀍�o���Ȃ�
        if (FirstStage.FirststageClear)
        {
            //�@�\��~
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
        //�I�u�W�F�N�g�̉�]
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
    public void HitChack(Vector2 Anim)
    {
        //�Α���͂�
        if (CarryObjectrb == null)
        {
            //���C���[����
            Rayfly(Anim);
        }
        else
        {
            //�v���C���[���z�[���h�L�[��������Ƃ��̏���
            if (Input.GetButtonUp("Objectcatch"))
            {
                CarryObjectStop();
            }
        }
    }

    private void Rayfly(Vector2 dir)
    {
        //���C���[����
        float distance = 0.4f;

        //���C���[���΂��ĐڐG����
        var hits = Physics2D.RaycastAll(transform.position, dir, distance);

        //�q�b�g�������ׂẴI�u�W�F�N�g������
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