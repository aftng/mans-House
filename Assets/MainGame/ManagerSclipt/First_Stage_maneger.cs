using System.Collections;
using System.Linq;
using UnityEngine;

public class First_Stage_maneger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] statue;
    private ClarChack[] ClearChacks = new ClarChack[6];
    private bool[] ObjectChack = new bool[6];
    public GameObject wall;
    //�N���A�I�[�f�B�I
    private AudioSource audioSource;
    [SerializeField]
    AudioClip clip;
    private bool stageClear = false;
    public bool FirststageClear { get { return stageClear; } }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //�z��I�u�W�F�N�g�̃R���|�[�l���g�擾
        for (int i = 0; i < statue.Length; ++i)
        {
            ClearChacks[i] = statue[i].GetComponent<ClarChack>();
        }
    }
    void Update()
    {
        if (stageClear) { return; }
        StageClearChack();
    }

    private void StageClearChack()
    {
        //���ׂẴI�u�W�F�N�g�̃N���A�`�F�b�N
        for (int i = 0; i < statue.Length; ++i)
        {
            ObjectChack[i] = ClearChacks[i].ObjectClearChack();
        }

        //�z��̒��g�����ׂē�����ObjectClearChack[0]��True�Ȃ�N���A
        if (ObjectChack.Distinct().Count() == 1�@&& ObjectChack[0] == true)
        {           
            StartCoroutine(ChackClear());
        }      
    }
    IEnumerator ChackClear()
    {
        //���b�҂��Ă���N���A�`�F�b�N
        yield return new WaitForSeconds(2);
        if (ObjectChack.Distinct().Count() == 1 && ObjectChack[0] == true && stageClear== false)
        {
            stageClear = true;
            StartCoroutine(ClearOudio());
        }
    }
    IEnumerator ClearOudio()
    {
        //�T�E���h��炵�ǂ�����
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip);
        Destroy(wall);
    }
    //�f�o�b�O�p
    public void DebugChack()
    {
        stageClear = true;
        StartCoroutine(ClearOudio());
    }
}
