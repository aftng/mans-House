using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Stage_Gamemaneger : MonoBehaviour
{   
    public GameObject ThirdStage_Object;

    private bool clearChack = false;
    public bool ClearChack
    {
        get { return clearChack; }
    }
    //クリアオーディオ
    private AudioSource audioSource;

    [SerializeField]
    AudioClip clip;

    //  順番カウント
    private int ordercount = 1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OrderChack(int OrderNo)
    {
        if (clearChack) { return;}
     
        if (ordercount == OrderNo)
        {
            ordercount++;
        }
        else
        {
            ordercount = 1;
        }
    }

    public void OrdertwiceChack(int OrderNo,int OrderNo_second)
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
            StartCoroutine(CurearOudio());
        }
    }
    IEnumerator CurearOudio()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip);
        Instantiate(ThirdStage_Object, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
