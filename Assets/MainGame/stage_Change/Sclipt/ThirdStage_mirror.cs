using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStage_mirror : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraMan;
    public GameObject obj;
    public GameObject arrow;
    //�t�F�[�h�A�E�g
    private Fade_Out Fade_Out;
    //�v���C���[�ړ��ʒu
    private float Playerposition = 47.3f;

    //���߂ċ���ʂ������t���O
    private bool firstpass�@= false;
    //�J�����ړ��ʒu
    private Game_Manager Game_Manager;
    private float cameraposition;
    void Start()
    {
        Fade_Out = FindObjectOfType<Fade_Out>();
        Game_Manager = FindObjectOfType<Game_Manager>();
        cameraposition = Game_Manager.Cameraposition[2];
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
        Object_Destroy();
        Object_Instantiate();
    }

    private void Object_Destroy()
    {
        //������       
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
        foreach (GameObject Object in arrows)
        {
            Destroy(Object);
        }

        //�I�u�W�F�N�g����
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ChangeMap");
        foreach (GameObject Objects in objs)
        {
            Destroy(Objects);
        }
    }
    private void Object_Instantiate()
    {
        //���߂ċ���ʂ����Ƃ��̂ݖ�󐶐�
        if (!firstpass)
        {
            firstpass = true;
            Instantiate(arrow, new Vector3(0, 51, 0), Quaternion.identity);
        }

        //�I�u�W�F�N�g����
        {
            Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Fade_Out.Fade_out();
            StartCoroutine(StageChange());
        }
    }
}
