using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_question : MonoBehaviour
{
    //�N�G�X�`�����I�u�W�F�N�g
    public GameObject[] QuestionObjectNo;
    //�v���C���[�X�g�b�v
    private bool playerstop;
    private Game_Manager Game_Manager;
    //�e�X�e�[�W�̃J�����ʒu
    private float[] cameraposition;
    //�N�G�X�`�����I��p�i���o�[
    private int QuestionNo;
    //�N�G�X�`�����{�[�h���o�Ă��邩�`�F�b�N
    private bool QuestionopenChack = false;
    //���݂̃J�����ʒu
    private float cameraposY;
    //�N�G�X�`�����{�[�h�ڐG����
    private bool question_openCheck;
    private Question_board_Check Question_board_Check;
    //�I�[�f�B�I
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip clip;
    void Start()
    {
        Game_Manager = FindObjectOfType<Game_Manager>();
        audioSource = GetComponent<AudioSource>();
        Question_board_Check = FindObjectOfType<Question_board_Check>();
        //�e�X�e�[�W�̃J�����ʒu�擾
        cameraposition = Game_Manager.Cameraposition;
    }
    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
        question_openCheck = Question_board_Check.Question_Open;
        //���݂̃J�����ʒu�擾
        cameraposY = this.transform.position.y;

        //���݂̃J�����̈ʒu�ɂ���ăN�G�X�`�����i���o�[�I��
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
                //�{�[�h����
                playerstop = true;
                QuestionopenChack = true;
                audioSource.PlayOneShot(clip);
                Game_Manager.PlayerStop = playerstop;
                Instantiate(QuestionObjectNo[QuestionNo], new Vector3(0, cameraposY, 0), Quaternion.identity);
            }
            else
            {
                //�{�[�h����
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
