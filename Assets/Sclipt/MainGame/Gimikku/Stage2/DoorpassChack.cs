using System.Collections;
using UnityEngine;

public class DoorpassChack : MonoBehaviour
{
    private GameObject Player;
    public GameObject MapObj;
    public Fade_Out Fade_Out;
    public Second_Stage_Gamemaneger Second_Stage_Gamemaneger;

    [SerializeField]
    private int correctorder;

    [SerializeField]
    Vector2 PlayermovePos;


    private void Object_Destroy()
    {
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

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);
        //プレイヤー座標変更
        {
            Player.transform.position = PlayermovePos;
            Player = null;
        }
        Object_Destroy();
        Object_Instantiate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤー接触判定
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject;
            Fade_Out.Fade_out();
            StartCoroutine(TestCoroutine());
            Second_Stage_Gamemaneger.OrderChack(correctorder);
        }
    }
}
