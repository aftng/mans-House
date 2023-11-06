using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    //オブジェクト回転
    private int objectrotate = 0;
    public int Objectrotate
    {
        get { return objectrotate; }
        set { objectrotate = value; }
    }

    //オブジェクト回転絵取得
    [SerializeField]
    Sprite[] objectSprite;

    //コンポーネント取得
    private SpriteRenderer Sr;

    //回転回数
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
        //オブジェクト回転ループ
        //objectrotateの値の0～3の間でループ
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