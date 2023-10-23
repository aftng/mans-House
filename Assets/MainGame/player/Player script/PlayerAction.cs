using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{    
    [SerializeField]
    private KeyCode decisionkey;

    [SerializeField]
    private KeyCode RotateRightkey;

    [SerializeField]
    private KeyCode RotateLeftkey;

    [SerializeField]
    private KeyCode Holdkey;

    [SerializeField]
    private KeyCode Question_Open;
   
    public bool  RotateLeftChack()
    {
        bool RotateLeft_;
        if (Input.GetKeyDown(RotateLeftkey))
        {
            RotateLeft_ = true;
        }
        else
        {
            RotateLeft_ = false;
        }
        return RotateLeft_;
    }
    public bool RotateRightChack()
    {
        bool RotateRight_;
        if (Input.GetKeyDown(RotateRightkey))
        {
            RotateRight_ = true;
        }
        else
        {
            RotateRight_ = false;
        }
        return RotateRight_;
    }

    public bool DecisionChack()
    {
         bool decision_;
        if (Input.GetKeyDown(decisionkey))
        {
            decision_ = true;
        }
        else
        {
            decision_ = false;
        }
        return decision_;
    }
    public bool Question_OpenChack()
    {
        bool Question_Open_;
        if (Input.GetKeyDown(Question_Open))
        {
            Question_Open_ = true;
        }
        else
        {
            Question_Open_ = false;
        }
            return Question_Open_;
    }
    public bool HoldChack()
    {
        bool Hold_;
        if (Input.GetKey(Holdkey))
        {          
            Hold_ = true;
        }
        else
        {
            Hold_ = false;
        }
        return Hold_;
    }
}

