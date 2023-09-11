using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    public Player_Chack Player_Chack;
    private First_Stage_maneger First_Stage;
    private Player_rotate Player_rotate;
    //�I�u�W�F�N�g��]
    public int objectrotate = 0;
    //�I�u�W�F�N�g��]�G�擾
    [SerializeField]
    Sprite[] objectSprite;

    //�R���|�[�l���g�擾
    private SpriteRenderer sr;

    //�v���C������̃L�[����
    private bool leftkey = false;
    private bool rightkey = false;

    //��]��
    private int rotateminimum = -1;
   
    //�v���C���ڐG����
    private bool isplayer = false;

    //�N���A����
    private bool Clear;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        this.First_Stage = FindObjectOfType<First_Stage_maneger>();
        this.Player_rotate = FindObjectOfType<Player_rotate>();
        sr.sprite = objectSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
        isplayer = Player_Chack.IsPlayerChack();
        Clear = First_Stage.FirststageClear;
        rightkey = Player_rotate.Rightkey;
        leftkey = Player_rotate.Leftkey;
        if (!Clear)
        {  
            if (isplayer)
            {
                //�v���C���[����̓���
                if(rightkey)
                {
                    objectrotate++;
                }
                if(leftkey)
                {
                    objectrotate--;
                }
            }
            objrotate();
        }
    }

    private void objrotate()
    {
        //�I�u�W�F�N�g��]
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
