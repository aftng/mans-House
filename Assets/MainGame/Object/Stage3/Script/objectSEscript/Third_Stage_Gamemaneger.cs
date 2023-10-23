using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Stage_Gamemaneger : MonoBehaviour
{
    //ゲームクリアのための壁
    public GameObject stageClearwall;

 　//オーディオ
    private AudioSource audioSource;

    [SerializeField]
    AudioClip clip;

    private bool clearChack = false;
    //  順番カウント
    private int ordercount = 1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OrderChack(int OrderNo)
    {
        if (clearChack) { return; }

        if (ordercount == OrderNo)
        {
            ordercount++;
        }
        else
        {
            ordercount = 1;
        }
    }

    public void TwoOrdertChack(int OrderNo, int OrderNo_second)
    {
        if (clearChack) { return; }

        if (ordercount == OrderNo || ordercount == OrderNo_second)
        {
            ordercount++;
        }
        else
        {
            ordercount = 1;
        }
        ClearChacks();
    }
    public void ClearChacks()
    {
        //クリアカウント
        int Clearcount = 8;
        if (ordercount == Clearcount)
        {
            clearChack = true;
            StartCoroutine(ClearOudio());
        }
    }
    IEnumerator ClearOudio()
    {
        //オブジェクト消去
        GameObject[] objs = GameObject.FindGameObjectsWithTag("animal");
        foreach (GameObject Objects in objs)
        {
            Destroy(Objects);
        }
        //サウンドを鳴らし壁を消す
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip);
        Destroy(stageClearwall);
    }
}
