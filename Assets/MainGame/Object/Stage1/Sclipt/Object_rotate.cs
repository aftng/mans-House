using UnityEngine;

public class Object_rotate : MonoBehaviour
{
    //オブジェクト回転
    private int objectrotateNo = 0;
    public int Objectrotate
    {
        get { return objectrotateNo; }
        set { objectrotateNo = value; }
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
    public void Objectloop()
    {
        //オブジェクト回転ループ
        //objectrotateの値の0～3の間でループ
        
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