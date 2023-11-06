using System.Collections;
using UnityEngine;

public class Stage_Move : MonoBehaviour
{
    private GameObject player;
    public GameObject cameraMan;

    public Fade_Out Fade_Out;
    public Game_Manager Game_Manager;

    //�v���C���[�ړ��ʒu
    [SerializeField]
    private float Playerposition;
    //�J�����̔z��ԍ�
    [SerializeField]
    private int CameraMoveNo;
    //�J�����ړ��ʒu
    private float cameraposition;
    void Start()
    {
        cameraposition = Game_Manager.Cameraposition[CameraMoveNo];
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
