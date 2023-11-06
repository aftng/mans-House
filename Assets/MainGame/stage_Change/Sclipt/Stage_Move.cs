using System.Collections;
using UnityEngine;

public class Stage_Move : MonoBehaviour
{
    private GameObject player;
    public GameObject cameraMan;

    public Fade_Out Fade_Out;
    public Game_Manager Game_Manager;

    //プレイヤー移動位置
    [SerializeField]
    private float Playerposition;
    //カメラの配列番号
    [SerializeField]
    private int CameraMoveNo;
    //カメラ移動位置
    private float cameraposition;
    void Start()
    {
        cameraposition = Game_Manager.Cameraposition[CameraMoveNo];
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
