using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    //�I�u�W�F�N�g��]
    private int objectrotate = 0;
    public int Objectrotate
    {
        get { return objectrotate; }
        set { objectrotate = value; }
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
    void Update()
    {
        Objectloop();
    }
    private void Objectloop()
    {
        //�I�u�W�F�N�g��]���[�v
        //objectrotate�̒l��0�`3�̊ԂŃ��[�v
        if (objectrotate >= objectSprite.Length)
        {
            objectrotate = Rotateminimum + 1;
        }
        if (objectrotate <= Rotateminimum)
        {
            objectrotate = objectSprite.Length - 1;
        }
        Sr.sprite = objectSprite[objectrotate];
    }
}