using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorpassChack : MonoBehaviour
{
    public GameObject Player;
    public GameObject MapObj;
    private Fade_Out Fade_Out;
    private Second_Stage_Gamemaneger Second_Stage_Gamemaneger;

    [SerializeField]
    private int correctorder;

    [SerializeField]
    Vector2 PlayermovePos;

    void Start()
    {
        Fade_Out = FindObjectOfType<Fade_Out>();
        Second_Stage_Gamemaneger = FindObjectOfType<Second_Stage_Gamemaneger>();
    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);
        //プレイヤー座標変更
        {
            Player.transform.position = PlayermovePos;
        }
        Object_Destroy();
        Object_Instantiate();
    }

    private void Object_Destroy()
    {
        //矢印消去
        GameObject[] arrow = GameObject.FindGameObjectsWithTag("arrow");
        foreach (GameObject arrows in arrow)
        {
            Destroy(arrows);
        }

        //オブジェクト消去
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ChangeMap");
        foreach (GameObject Objects in objs)
        {
            Destroy(Objects);
        }
    }
    private void Object_Instantiate()
    {
        //オブジェクト生成
        Instantiate(MapObj, new Vector3(0, 0, 0), Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            Fade_Out.Fade_out();
            StartCoroutine(TestCoroutine());
            Second_Stage_Gamemaneger.OrderChack(correctorder);
        }
    }
}
