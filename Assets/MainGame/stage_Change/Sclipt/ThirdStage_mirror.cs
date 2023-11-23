using System.Collections;
using UnityEngine;

public class ThirdStage_mirror : MonoBehaviour
{
    public GameObject cameraMan;
    public GameObject Stageobj;
    public GameObject arrow;
    public Fade_Out Fade_Out;
    public Gameprogress Gameprogress;
    private GameObject player;
    //プレイヤー移動位置
    private float Playerposition = 47.3f;

    //初めて鏡を通ったかフラグ
    private bool firstpass　= false;
    //カメラ移動位置
    private float cameraposition;
    void Start()
    {
        cameraposition = Gameprogress.Cameraposition[2];
    }

    IEnumerator StageChange()
    {
        //フェードアウトするまで1秒待つ
        yield return new WaitForSeconds(1);
        //プレイヤー座標変更
        {
            Vector3 PlayerPos = player.transform.position;
            player.transform.position = new Vector3(
                PlayerPos.x, Playerposition, PlayerPos.z);
            player = null;
        }
        //カメラ座標変更
        {
            Vector3 CamerarPos = cameraMan.transform.position;
            cameraMan.transform.position = new Vector3(
               CamerarPos.x, cameraposition, CamerarPos.z);
        }
        Object_Destroy();
        Object_Instantiate();
    }

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
        //初めて鏡を通ったときのみ矢印生成
        if (!firstpass)
        {
            firstpass = true;
            Instantiate(arrow, new Vector3(0, 51, 0), Quaternion.identity);
        }

        //オブジェクト生成
        {
            Instantiate(Stageobj, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            Fade_Out.Fade_out();
            StartCoroutine(StageChange());
        }
    }
}
