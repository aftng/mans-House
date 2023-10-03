using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_question : MonoBehaviour
{
    public GameObject[] QuestionObjectNo;
    private bool playerstop;
    private Game_Manager Game_Manager;
    private float[] cameraposition;
    private int QuestionNo;
    private bool QuestionopenChack = false;
    private float cameraposY;
    private bool question_openCheck;
    private Question_board_Check Question_board_Check;
    //オーディオ
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip clip;
    void Start()
    {
        Game_Manager = FindObjectOfType<Game_Manager>();
        audioSource = GetComponent<AudioSource>();
        Question_board_Check = FindObjectOfType<Question_board_Check>();
        //各ステージのカメラ位置取得
        cameraposition = Game_Manager.Cameraposition;
    }
    void Update()
    {
        //他のスクリプトから変数取得
        question_openCheck = Question_board_Check.Question_Open;
        //現在のカメラ位置取得
        cameraposY = this.transform.position.y;

        //現在のカメラの位置によってクエスチョンナンバー選択
        for(int i = 0; i < cameraposition.Length; ++i)
        {
            if (cameraposition[i]  == cameraposY)
            {
                QuestionNo = i;
            }
        }       
        if (question_openCheck)
        { 
            if (!QuestionopenChack)
            {
                //ボード生成
                playerstop = true;
                QuestionopenChack = true;
                audioSource.PlayOneShot(clip);
                Game_Manager.PlayerStop = playerstop;
                Instantiate(QuestionObjectNo[QuestionNo], new Vector3(0, cameraposY, 0), Quaternion.identity);
            }
            else
            {
                //ボード消去
                GameObject[] objs = GameObject.FindGameObjectsWithTag("Question");
                foreach (GameObject Objects in objs)
                {
                    Destroy(Objects);
                }
                audioSource.PlayOneShot(clip);
                playerstop = false;
                QuestionopenChack = false;
                Game_Manager.PlayerStop = playerstop;
            }
        }
    }
}
