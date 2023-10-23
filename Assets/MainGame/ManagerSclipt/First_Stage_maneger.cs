using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Stage_maneger : MonoBehaviour
{
    private Bird Bird;
    private Dog Dog;
    private Ghost Ghost;
    private Horse Horse;
    private Turtle Turtle;
    private Masked_Man Masked_Man;

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
    public bool FirststageClear
    {
        get { return stageClear; }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Bird = FindObjectOfType<Bird>();
        Dog = FindObjectOfType<Dog>();
        Ghost = FindObjectOfType<Ghost>();
        Horse = FindObjectOfType<Horse>();
        Turtle = FindObjectOfType<Turtle>();
        Masked_Man = FindObjectOfType<Masked_Man>();
    }
    void Update()
    {
        if (stageClear) { return; }
        BirdClear = Bird.ObjectClearChack();
        DogClear = Dog.ObjectClearChack();
        GhostClear = Ghost.ObjectClearChack();
        HorseClear = Horse.ObjectClearChack();
        masked_ManClear = Masked_Man.ObjectClearChack();
        TurtleClear = Turtle.ObjectClearChack();
        StageClearChack();
    }

    private void StageClearChack()
    {
        if (BirdClear && DogClear && GhostClear && HorseClear
           && masked_ManClear && TurtleClear)
        {
            StartCoroutine(ChackClear());
        }
    }
    IEnumerator ChackClear()
    {
        //数秒待ってからクリアチェック
        yield return new WaitForSeconds(2);
        if (BirdClear && DogClear && GhostClear && HorseClear
          && masked_ManClear && TurtleClear && !stageClear)
        {          
                stageClear = true;
                StartCoroutine(ClearOudio());            
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
