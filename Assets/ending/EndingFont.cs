using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFont : MonoBehaviour
{
    //Fontスピード
    private float FontSpeed = 5f;
    private RectTransform RectTransform;

    private void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }
    //フォントの現在位置と止まる場所
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
        //シーン変換するまで3秒待つ
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title");
    }
}
