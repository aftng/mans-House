using System.Collections;
using UnityEngine;

public class DoorpassChack : MonoBehaviour
{
    private GameObject Player;
    public GameObject MapObj;
    public Fade_Out Fade_Out;
    public Second_Stage_Gamemaneger Second_Stage_Gamemaneger;

    [SerializeField]
    private int correctorder;

    [SerializeField]
    Vector2 PlayermovePos;

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);
        //�v���C���[���W�ύX
        {
            Player.transform.position = PlayermovePos;
            Player = null;
        }
        Object_Destroy();
        Object_Instantiate();
    }

    private void Object_Destroy()
    {
        //������
        GameObject[] arrow = GameObject.FindGameObjectsWithTag("arrow");
        foreach (GameObject arrows in arrow)
        {
            Destroy(arrows);
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
        //�I�u�W�F�N�g����
        Instantiate(MapObj, new Vector3(0, 0, 0), Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject;
            Fade_Out.Fade_out();
            StartCoroutine(TestCoroutine());
            Second_Stage_Gamemaneger.OrderChack(correctorder);
        }
    }
}
