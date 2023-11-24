using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private bool bottanChack = false;
    public bool BottanChack{get { return bottanChack; }}
    //scene�ړ�����
    [SerializeField]
    private float ScenesChangeTime;

    private AudioSource audioSource;
    private Image image;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        image.enabled = false;
        Cursor.visible = false;
    }
    void Update()
    {
        //�{�^�����P�x���������ꂽ���`�F�b�N
        if (Input.GetKeyDown("c") && bottanChack == false)
        {
            bottanChack = true;
            image.enabled = true;
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
