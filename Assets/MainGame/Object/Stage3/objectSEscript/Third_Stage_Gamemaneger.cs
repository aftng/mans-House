using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Stage_Gamemaneger : MonoBehaviour
{
    //クリア順番チェック
    private int clearcount;

    //ゲームクリアのための壁
    public GameObject stageClearwall;

 　//オーディオ
    private AudioSource audioSource;

    [SerializeField]
    AudioClip clip;

    //クリアオーディオ
    private bool oudiochack = false;
    public int Clearcount
    {
        get { return clearcount; }
        set { clearcount = value; }
    }

    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(clearcount == 7 && oudiochack == false)
        {
            oudiochack = true;
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
