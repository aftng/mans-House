using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Stage_maneger : MonoBehaviour
{
    public BirdClear_Chack Bird;
    public dogClear_Chack Dog;
    public ghostClear_Chack Ghost;
    public HorseClear_Chack Horse;
    public TurtleClear_Chack Turtle;
    public masked_ManClear_Chack masked_Man;
    public GameObject wall;
    private bool stageClear = false;
    private bool BirdClear;
    private bool DogClear;
    private bool GhostClear;
    private bool HorseClear;
    private bool masked_ManClear;
    private bool TurtleClear;
    //クリアオーディオ
    private AudioSource audioSource;
    [SerializeField]
    AudioClip clip;
    private bool oudiochack = false;
    public bool FirststageClear
    {
        get { return stageClear; }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        BirdClear = Bird.BirdCrear;
        DogClear = Dog.DogClearChack;
        GhostClear = Ghost.GhostClearChack;
        HorseClear = Horse.HorseClearChack;
        masked_ManClear = masked_Man.masked_ManClearChack;
        TurtleClear = Turtle.TurtleClearChack;

        if (BirdClear && DogClear && GhostClear && HorseClear
           && masked_ManClear && TurtleClear)
        {
            StartCoroutine(ChackClear());
        }

        if (stageClear && oudiochack == false)
        {
            oudiochack = true;
            StartCoroutine(ClearOudio());
        }
    }
    IEnumerator ChackClear()
    {
        //数秒待ってからクリアチェック
        yield return new WaitForSeconds(2);
        if (BirdClear && DogClear && GhostClear && HorseClear
          && masked_ManClear && TurtleClear)
        {
            stageClear = true;
        }
    }
    IEnumerator ClearOudio()
    {
        //サウンドを鳴らし壁を消す
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip);
        Destroy(wall);
    }
}
