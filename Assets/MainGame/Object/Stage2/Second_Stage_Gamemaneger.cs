using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Stage_Gamemaneger : MonoBehaviour
{
    //他のスクリプト取得
    private Door1 door0;
    private Door2 door1;
    private Door3 door2;
    private Door4 door3;
    private Door5 door4;
    private Door6 door5;
    private SecondStage_mirror SecondStage_mirror;

    private bool door0_flag;
    private bool door1_flag;
    private bool door2_flag;
    private bool door3_flag;
    private bool door4_flag;
    private bool door5_flag;
    private bool Stage2_mirror_flag;
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
    private bool oudiochack = false;

    //クリアカウント
    private int Clearcount;
    [SerializeField]
     int[] orderdoor;
  
    public int[] Orderdoor
    {
        get { return orderdoor;}
    }

    // Start is called before the first frame update
    void Start()
    {
        door0 = FindObjectOfType<Door1>();
        door1 = FindObjectOfType<Door2>();
        door2 = FindObjectOfType<Door3>();
        door3 = FindObjectOfType<Door4>();
        door4 = FindObjectOfType<Door5>();
        door5 = FindObjectOfType<Door6>();
        SecondStage_mirror = FindObjectOfType<SecondStage_mirror>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        door0_flag = door0.StageChange;
        door1_flag = door1.StageChange;
        door2_flag = door2.StageChange;
        door3_flag = door3.StageChange;
        door4_flag = door4.StageChange;
        door5_flag = door5.StageChange;
        Stage2_mirror_flag = SecondStage_mirror.ChangeCheck;
     
            if (door0_flag)
            {
                if (Clearcount == orderdoor[6])
                {
                    clearChack = true;
                }
                else
                {
                    Clearcount = 1;
                }
            }
            if (door1_flag)
            {
                if (Clearcount == orderdoor[1])
                {
                    Clearcount++;
                }
                else
                {
                    Clearcount = 0;
                }
            }
            if (door2_flag)
            {
                if (Clearcount == orderdoor[2])
                {
                    Clearcount++;
                }
                else
                {
                    Clearcount = 0;
                }
            }
            if (door3_flag)
            {
                if (Clearcount == orderdoor[3])
                {
                    Clearcount++;
                }
                else
                {
                    Clearcount = 0;
                }
            }
            if (door4_flag)
            {
                if (Clearcount == orderdoor[4])
                {
                    Clearcount++;
                }
                else
                {
                    Clearcount = 0;
                }
            }
            if (door5_flag)
            {
                if (Clearcount == orderdoor[5])
                {
                    Clearcount++;
                }
                else
                {
                    Clearcount = 0;
                }
            }
　　　　//ステージを出たらカウントリセット
        if (Stage2_mirror_flag)
        {
            Clearcount = 0;
        }

        //サウンドとオブジェクト生成
        if(ClearChack && oudiochack == false)
        {
            oudiochack = true;
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
