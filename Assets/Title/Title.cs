using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject obj;
    private bool BottanChack = false;
    //scene移動時間
    [SerializeField]
    private float ScenesChangeTime;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //ボタンが１度だけ押されたかチェック
        if (Input.GetKeyDown("c") && BottanChack == false)
        {
            BottanChack = true;
            Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            StartCoroutine(StageState());
            audioSource.Stop();
        }
    }

    IEnumerator StageState()
    {
        yield return new WaitForSeconds(ScenesChangeTime);
        SceneManager.LoadScene("opening");
    }
}
