using System.Collections;
using UnityEngine;

public class Goddess_Statue_Door : MonoBehaviour
{
    private GameObject Player;
    public GameObject MapObj;
    public GameObject Clearobj;
    public Fade_Out Fade_Out;
    public Second_Stage_Gamemaneger Second_Stage_Gamemaneger;

    [SerializeField]
    private int chackorder;

    [SerializeField]
    private int chackorder_second;

    [SerializeField]
    Vector2 PlayermovePos;

    private bool ClearChack;

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
    private void Object_Destroy()
    {
        //矢印消去
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
        foreach (GameObject Obj in arrows)
        {
            Destroy(Obj);
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
        ClearChack = Second_Stage_Gamemaneger.ClearChack;
        //オブジェクト生成 
        if (!ClearChack)
        {
            Instantiate(MapObj, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(Clearobj, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤー接触判定
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject;
            Fade_Out.Fade_out();          
            Second_Stage_Gamemaneger.OrdertwiceChack(chackorder, chackorder_second);
            StartCoroutine(TestCoroutine());
        }
    }
}