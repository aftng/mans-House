using System.Collections;
using UnityEngine;

public class Third_Stage_Gamemaneger : MonoBehaviour
{
    //�Q�[���N���A�̂��߂̕�
    public GameObject stageClearwall;
    private bool clearChack = false;
    //�I�[�f�B�I
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
        //�J�E���g�`�F�b�N
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
        //�J�E���g�`�F�b�N
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
        if (ordercount >= Clearcount)
        {
            clearChack = true;
            StartCoroutine(ClearOudio());
        }
    }
    IEnumerator ClearOudio()
    {
        //�����I�u�W�F�N�g��T���ď���
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

    //�f�o�b�O�p
    public void DebugChack()
    {
        clearChack = true;
        StartCoroutine(ClearOudio());
    }
}
