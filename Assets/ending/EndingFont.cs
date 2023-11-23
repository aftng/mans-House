using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFont : MonoBehaviour
{
    //Font�X�s�[�h
    private float FontSpeed = 5f;
    private RectTransform RectTransform;

    private void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }
    //�t�H���g�̌��݈ʒu�Ǝ~�܂�ꏊ
    private float FontPosY;
    private float FontstopPos = 0.0f;
    void FixedUpdate()
    {
        FontPosY = RectTransform.anchoredPosition.y;
        if ( FontPosY >= FontstopPos)
        {           
           transform.position -= new Vector3(0, 1, 0) * FontSpeed;
        }
        else
        {
            StartCoroutine(SceneChange());
        }
    }
    IEnumerator SceneChange()
    {
        //�V�[���ϊ�����܂�3�b�҂�
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title");
    }
}
