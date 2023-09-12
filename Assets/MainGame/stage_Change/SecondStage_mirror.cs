using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStage_mirror : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraMan;
    //�t�F�[�h�A�E�g
    public Fade_Out Fade;
    //�v���C���[�ړ��ʒu
    private float Playerposition = 29.4f;
    //�X�e�[�W�`�F���W�`�F�b�N
    private bool changeCheck = false;
    public bool ChangeCheck
    {
        get { return changeCheck; }
    }
    //�J�����ړ��ʒu

    private Game_Manager Game_Manager;
    private float cameraposition;
    void Start()
    {
        this.Game_Manager = FindObjectOfType<Game_Manager>();
        cameraposition = Game_Manager.Cameraposition[1];
    }
    void Update()
    { 
        if (changeCheck)
        {
            changeCheck = false;
            Fade.Fade_out();
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
            changeCheck = true;
        }
    }
}