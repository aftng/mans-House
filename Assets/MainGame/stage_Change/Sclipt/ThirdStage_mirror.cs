using System.Collections;
using UnityEngine;

public class ThirdStage_mirror : MonoBehaviour
{
    public GameObject cameraMan;
    public GameObject Stageobj;
    public GameObject arrow;
    public Fade_Out Fade_Out;
    public Gameprogress Gameprogress;
    private GameObject player;
    //�v���C���[�ړ��ʒu
    private float Playerposition = 47.3f;

    //���߂ċ���ʂ������t���O
    private bool firstpass�@= false;
    //�J�����ړ��ʒu
    private float cameraposition;
    void Start()
    {
        cameraposition = Gameprogress.Cameraposition[2];
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
            player = null;
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
            Instantiate(Stageobj, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            Fade_Out.Fade_out();
            StartCoroutine(StageChange());
        }
    }
}
