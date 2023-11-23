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
    //�R���|�[�l���g
    private AudioSource audioSource;
    private Image image;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        //�e�X�e�[�W�̃J�����ʒu�擾
        cameraposition = Gameprogress.Cameraposition;
        image.enabled = false;
    }

    public void GuestionOpen()
    {
        PlayerStop = Gameprogress.PlayerStop;
        if (!PlayerStop)
        {
            //���݂̃J�����ʒu�擾
            cameraposY = Camera.main.transform.position.y;

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
                audioSource.PlayOneShot(clip);
                QuestionopenChack = true;
                image.sprite = QuestionSprite[QuestionNo];
                image.enabled = true;
                Gameprogress.PlayerStop = true;
            }
            
        }
        else if(PlayerStop && QuestionopenChack)
        {
            //�{�[�h����
            QuestionopenChack = false;
            image.enabled = false;
            Gameprogress.PlayerStop = false;
        }

    }
}