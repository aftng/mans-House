using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question_board_Check : MonoBehaviour
{
    private bool isPlayer = false;
    private string Playerchacktag = "Question_board";

    //�v���C���[�͂ݔ���
    private bool PushChack;
    private Player_grasp Player_grasp;

    private bool question_open = false;
    public bool Question_Open
    {
        get { return question_open; }
    }
    void Start()
    {
        this.Player_grasp = FindObjectOfType<Player_grasp>();
    }
    void Update()
    {
        PushChack = Player_grasp.Push;
        //�v���C���[�ڐG����  
        if (isPlayer)
        {
            // �͂ݔ���
            if (PushChack)
            {
                question_open = true;
            }
            else
            {
                question_open = false;
            }
        }
    }
    //�ڐG����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Playerchacktag)
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Playerchacktag)
        {
            isPlayer = false;
        }
    }
}