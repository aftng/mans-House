using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Stage_maneger : MonoBehaviour
{
    private BirdClear_Chack Bird;
    private DogClear_Chack Dog;
    private GhostClear_Chack Ghost;
    private HorseClear_Chack Horse;
    private TurtleClear_Chack Turtle;
    private Masked_ManClear_Chack Masked_Man;
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
        Bird = FindObjectOfType<BirdClear_Chack>();
        Dog = FindObjectOfType<DogClear_Chack>();
        Ghost = FindObjectOfType<GhostClear_Chack>();
        Horse = FindObjectOfType<HorseClear_Chack>();
        Turtle = FindObjectOfType<TurtleClear_Chack>();
        Masked_Man = FindObjectOfType<Masked_ManClear_Chack>();
    }
    void Update()
    {
        BirdClear = Bird.BirdClearChack;
        DogClear = Dog.DogClearChack;
        GhostClear = Ghost.GhostClearChack;
        HorseClear = Horse.HorseClearChack;
        masked_ManClear = Masked_Man.Masked_ManClearChack;
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
