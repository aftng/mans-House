using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door4 : MonoBehaviour
{
    public GameObject player;
    public Fade_Out Fade;
    public GameObject obj;
    private bool stageChange = false;
    public bool StageChange
    {
        get { return stageChange; }
    }
    private void Update()
    {
        if (stageChange)
        {
            stageChange = false;
            Fade.Fade_out();
            StartCoroutine(TestCoroutine());
        }
    }
    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1);
        //�v���C���[���W�ύX
        {
            Vector3 PlayerPos = player.transform.position;
            player.transform.position = new Vector3(
                -7.8f, 51.2f, PlayerPos.z);
        }
        Object_Destroy();
        Object_Instantiate();
    }
    private void Object_Destroy()
    {
        //�I�u�W�F�N�g����
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Obj");
        foreach (GameObject Objects in objs)
        {
            Destroy(Objects);
        }
    }
    private void Object_Instantiate()
    {
        //�I�u�W�F�N�g����
        {
            Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
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
