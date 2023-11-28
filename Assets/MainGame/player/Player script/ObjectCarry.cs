using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public First_Stage_maneger FirstStage;
    private Object_rotate Object_rotate = null;
    private GameObject carryObject = null;
    public GameObject CarryObject { get { return carryObject; } }
    //�I�u�W�F�N�g��]�G�ԍ�
    private int ObjectrotateNo;

    [SerializeField]
    private AudioClip Objectclip;

    //�R���|�[�l���g�擾
    private Rigidbody2D CarryObjectrb;
    private AudioSource CarryObjectAS;
    private void Update()
    {
        if (FirstStage.FirststageClear) { return; }
        ObjectRotate();
    }
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
        if (carryObject == null)
        {
            if (FirstStage.FirststageClear) { return; }
            if (Input.GetButton("Objectcatch"))
            {
                //���C���[����
                Rayfly(Anim);
            }
        }
        else
        {
            //�v���C���[���z�[���h�L�[��������Ƃ��̏���
            if (Input.GetButtonUp("Objectcatch"))
            {
                CarryObjectrb.velocity = Vector2.zero;
                CarryObjectrb.bodyType = RigidbodyType2D.Kinematic;
                CarryObjectAS.Stop();
                CarryObjectrb = null;
                CarryObjectAS = null;
                carryObject = null;
            }
        }
    }

    private void Rayfly(Vector2 dir)
    {
        //���C���[����
        float distance = 0.4f;
        var hits = Physics2D.RaycastAll(transform.position, dir, distance);
        Debug.DrawRay(transform.position, (dir * 0.064f), Color.blue);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("statue"))
            {
                carryObject = hit.collider.gameObject;
                CarryObjectrb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                CarryObjectAS = hit.collider.gameObject.GetComponent<AudioSource>();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //��]�p�̐ڐG����
        if (FirstStage.FirststageClear) { return; }
        if (collision.gameObject.tag == "statue" && Object_rotate == null)
        {
            Object_rotate = collision.gameObject.GetComponentInChildren<Object_rotate>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Object_rotate�̐e�I�u�W�F�N�g�����ꂽ��Object_rotate��null�ɂ���
        if (Object_rotate != null && collision.gameObject == Object_rotate.gameObject.transform.parent.gameObject)
        {
            Object_rotate = null;
        }
    }
}