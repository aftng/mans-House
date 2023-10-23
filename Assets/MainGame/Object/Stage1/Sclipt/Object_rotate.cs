using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    public Player_Chack PlayerChack;
    private First_Stage_maneger FirstStage;
    private PlayerAction PlayerAction;
    //�I�u�W�F�N�g��]
    private int objectrotate = 0;
    public int Objectrotate
    {
        get { return objectrotate; }
    }
    //�I�u�W�F�N�g��]�G�擾
    [SerializeField]
    Sprite[] objectSprite;

    //�R���|�[�l���g�擾
    private SpriteRenderer sr;

    //�v���C������̃L�[����
    private bool leftkey;
    private bool rightkey;

    //��]��
    private int rotateminimum = -1;
   
    //�v���C���ڐG����
    private bool isplayer;

    //�N���A����
    private bool StageClear;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        FirstStage = FindObjectOfType<First_Stage_maneger>();
        PlayerAction = FindObjectOfType<PlayerAction>();
        sr.sprite = objectSprite[0];
    }

    void Update()
    {     
        StageClear = FirstStage.FirststageClear;

        //�X�e�[�W���N���A������@�\��~
        if (StageClear) { return; }

        //���̃X�N���v�g����ϐ��擾
        isplayer = PlayerChack.IsPlayerChack();
        rightkey = PlayerAction.RotateRightChack();
        leftkey = PlayerAction.RotateLeftChack();
        PLayerkeyChack();
    }
    private void PLayerkeyChack()
    {
        if (isplayer)
        {
            //�v���C���[����̓���
            if (rightkey == true)
            {
                objectrotate++;
            }
            if (leftkey)
            {
                objectrotate--;
            }
            Objrotate();
        }
    }
    private void Objrotate()
    {
        //�I�u�W�F�N�g��]���[�v
        if (objectrotate >= objectSprite.Length)
        {
            //objectrotate��3�ȏ�ɂȂ�����0�ɂ���
            objectrotate = rotateminimum + 1;
        }
        if (objectrotate <= rotateminimum)
        {
            //objectrotate��-1�ȉ��ɂȂ�����3�ɂ���
            objectrotate = objectSprite.Length - 1;
        }
        sr.sprite = objectSprite[objectrotate];
    }
}
