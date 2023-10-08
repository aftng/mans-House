using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstStage_door : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraMan;
    //�t�F�[�h�A�E�g
    private Fade_Out Fade_Out;

    //�v���C���[�ړ��ʒu
    private float Playerposition = 21.5f;
    //�X�e�[�W�`�F���W�`�F�b�N
    private bool stageChange = false;
   //�X�e�[�W�N���A����
    private First_Stage_maneger First_Stage;
    private bool Clear;
    //�J�����ړ��ʒu
    private Game_Manager Game_Manager;
    private float cameraposition;
    private void Start()
    {
        Fade_Out = FindAnyObjectByType<Fade_Out>();
        First_Stage = FindObjectOfType<First_Stage_maneger>();
        Game_Manager = FindObjectOfType<Game_Manager>();
        cameraposition = Game_Manager.Cameraposition[1];
    }
    void Update()
    {
        //�t�@�[�X�g�X�e�[�W���N���A���Ă��邩
        Clear = First_Stage.FirststageClear;
        if (stageChange && Clear)
        {        
            stageChange = false;
            Fade_Out.Fade_out();
            StartCoroutine(StageChange());
        }
    }
    IEnumerator StageChange()
    {
        //�t�F�[�h�A�E�g����܂�1�b�҂�
        yield return new WaitForSeconds(1);
        //�v���C���[���W�ύX
        {
            Vector3 PlayerPos = player.transform.position;
            player.transform.position = new Vector3(
                PlayerPos.x, Playerposition, PlayerPos.z);
        }
        //�J�������W�ύX
        {    
            Vector3 CamerarPos = cameraMan.transform.position;
            cameraMan.transform.position = new Vector3(
               CamerarPos.x, cameraposition, CamerarPos.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player)
        {
            stageChange = true;
        }
    }
}

