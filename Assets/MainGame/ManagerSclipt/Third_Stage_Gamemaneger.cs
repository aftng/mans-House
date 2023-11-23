using System.Collections;
using UnityEngine;

public class Third_Stage_Gamemaneger : MonoBehaviour
{
    //ゲームクリアのための壁
    public GameObject stageClearwall;
    private bool clearChack = false;
    //オーディオ
    private AudioSource audioSource;

    [SerializeField]
    AudioClip clip;

    private int ordercount = 1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OrderChack(int OrderNo)
    {
        //カウントチェック
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
        //カウントチェック
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
        if (ordercount >= Clearcount)
        {
            clearChack = true;
            StartCoroutine(ClearOudio());
        }
    }
    IEnumerator ClearOudio()
    {
        //動物オブジェクトを探して消去
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

    //デバッグ用
    public void DebugChack()
    {
        clearChack = true;
        StartCoroutine(ClearOudio());
    }
}
