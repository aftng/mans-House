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
    //クリアオーディオ
    private AudioSource audioSource;
    [SerializeField]
    AudioClip clip;
    private bool stageClear = false;
    public bool FirststageClear { get { return stageClear; } }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //配列オブジェクトのコンポーネント取得
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
        //すべてのオブジェクトのクリアチェック
        for (int i = 0; i < statue.Length; ++i)
        {
            ObjectChack[i] = ClearChacks[i].ObjectClearChack();
        }

        //配列の中身がすべて同じでObjectClearChack[0]がTrueならクリア
        if (ObjectChack.Distinct().Count() == 1　&& ObjectChack[0] == true)
        {           
            StartCoroutine(ChackClear());
        }      
    }
    IEnumerator ChackClear()
    {
        //数秒待ってからクリアチェック
        yield return new WaitForSeconds(2);
        if (ObjectChack.Distinct().Count() == 1 && ObjectChack[0] == true && stageClear== false)
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
    //デバッグ用
    public void DebugChack()
    {
        stageClear = true;
        StartCoroutine(ClearOudio());
    }
}
