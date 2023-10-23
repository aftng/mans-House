using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Stage_Gamemaneger : MonoBehaviour
{
    //�Q�[���N���A�̂��߂̕�
    public GameObject stageClearwall;

 �@//�I�[�f�B�I
    private AudioSource audioSource;

    [SerializeField]
    AudioClip clip;

    private bool clearChack = false;
    //  ���ԃJ�E���g
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
        //�N���A�J�E���g
        int Clearcount = 8;
        if (ordercount == Clearcount)
        {
            clearChack = true;
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
