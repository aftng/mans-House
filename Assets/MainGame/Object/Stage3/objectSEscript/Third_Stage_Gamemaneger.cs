using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Stage_Gamemaneger : MonoBehaviour
{
    //�N���A���ԃ`�F�b�N
    private int clearcount;

    //�Q�[���N���A�̂��߂̕�
    public GameObject stageClearwall;

 �@//�I�[�f�B�I
    private AudioSource audioSource;

    [SerializeField]
    AudioClip clip;

    //�N���A�I�[�f�B�I
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
        //�I�u�W�F�N�g����
        GameObject[] objs = GameObject.FindGameObjectsWithTag("animal");
        foreach (GameObject Objects in objs)
        {
            Destroy(Objects);
        }
        //�T�E���h��炵�ǂ�����
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip);
        Destroy(stageClearwall);
    }
}
