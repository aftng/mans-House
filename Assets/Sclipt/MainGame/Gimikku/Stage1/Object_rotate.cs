using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    //�I�u�W�F�N�g��]
    private int objectrotateNo = 0;
    public int Objectrotate
    {
        get { return objectrotateNo; }
        set { objectrotateNo = value; }
    }

    //�I�u�W�F�N�g��]�G�擾
    [SerializeField]
    Sprite[] objectSprite;

    //�R���|�[�l���g�擾
    private SpriteRenderer Sr;

    //��]��
    private int Rotateminimum = -1;

    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        Sr.sprite = objectSprite[0];
    }
    public void Objectloop()
    {
        //�I�u�W�F�N�g��]���[�v
        //objectrotate�̒l��0�`3�̊ԂŃ��[�v
        
        if (objectrotateNo >= objectSprite.Length)
        {
            objectrotateNo = Rotateminimum + 1;
        }
        if (objectrotateNo <= Rotateminimum)
        {
            objectrotateNo = objectSprite.Length - 1;
        }
        Sr.sprite = objectSprite[objectrotateNo];
    }
}