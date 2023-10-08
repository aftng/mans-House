using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public GameObject player;
    public GameObject obj;
    public GameObject Clearobj;
    public Fade_Out Fade_Out;
    private Second_Stage_Gamemaneger Second_Stage_Gamemaneger;
    private bool stageChange = false;
    public bool StageChange
    {
        get { return stageChange; }
    }
    private bool ClearChack = false;
    void Start()
    {
        Second_Stage_Gamemaneger = FindObjectOfType<Second_Stage_Gamemaneger>();       
        Fade_Out = FindAnyObjectByType<Fade_Out>();
    }

    void Update()
    {
        ClearChack = Second_Stage_Gamemaneger.ClearChack;
        if (stageChange)
        {
            stageChange = false;
            Fade_Out.Fade_out();
            StartCoroutine(TestCoroutine());
        }
    }
    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);
        //プレイヤー座標変更
        {
            Vector3 PlayerPos = player.transform.position;
            player.transform.position = new Vector3(
                7.8f, 51.2f, PlayerPos.z);
        }
        Object_Destroy();
        Object_Instantiate();
    }
    private void Object_Destroy()
    {
        //オブジェクト消去
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Obj");
        foreach (GameObject Objects in objs)
        {
            Destroy(Objects);
        }
    }
    private void Object_Instantiate()
    {
        //オブジェクト生成 
        if (!ClearChack)
        {
            Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(Clearobj, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤー接触判定
        if (player)
        {
            stageChange = true;
        }
    }

}