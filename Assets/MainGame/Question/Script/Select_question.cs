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
    private PlayerAction PlayerAction;
    //�I�[�f�B�I
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip clip;
    void Start()
    {
        Game_Manager = FindObjectOfType<Game_Manager>();
        audioSource = GetComponent<AudioSource>();
        PlayerAction = FindObjectOfType<PlayerAction>();
        //�e�X�e�[�W�̃J�����ʒu�擾
        cameraposition = Game_Manager.Cameraposition;
    }
    void Update()
    {
        //���̃X�N���v�g����ϐ��擾
        question_openCheck = PlayerAction.Question_OpenChack();

        if (question_openCheck)
        {
            GuestionOpen();
        }
    }
    private void GuestionOpen()
    {
        //���݂̃J�����ʒu�擾
        cameraposY = this.transform.position.y;

        //���݂̃J�����̈ʒu�ɂ���ăN�G�X�`�����i���o�[�I��
        for (int i = 0; i < cameraposition.Length; ++i)
        {
            if (cameraposition[i] == cameraposY)
            {
                QuestionNo = i;
            }
        }
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
