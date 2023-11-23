using UnityEngine;
using UnityEngine.UI;

public class Select_question : MonoBehaviour
{
    public Gameprogress Gameprogress;
    private float[] cameraposition;
    private int QuestionNo;
    private bool QuestionopenChack = false;
    private bool PlayerStop;
    private float cameraposY;   
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    Sprite[] QuestionSprite;
    //コンポーネント
    private AudioSource audioSource;
    private Image image;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        //各ステージのカメラ位置取得
        cameraposition = Gameprogress.Cameraposition;
        image.enabled = false;
    }

    public void GuestionOpen()
    {
        PlayerStop = Gameprogress.PlayerStop;
        if (!PlayerStop)
        {
            //現在のカメラ位置取得
            cameraposY = Camera.main.transform.position.y;

            //現在のカメラの位置によってクエスチョンナンバー選択
            for (int i = 0; i < cameraposition.Length; ++i)
            {
                if (cameraposition[i] == cameraposY)
                {
                    QuestionNo = i;
                }
            }

            if (!QuestionopenChack)
            {
                //ボード生成
                audioSource.PlayOneShot(clip);
                QuestionopenChack = true;
                image.sprite = QuestionSprite[QuestionNo];
                image.enabled = true;
                Gameprogress.PlayerStop = true;
            }
            
        }
        else if(PlayerStop && QuestionopenChack)
        {
            //ボード消去
            QuestionopenChack = false;
            image.enabled = false;
            Gameprogress.PlayerStop = false;
        }

    }
}