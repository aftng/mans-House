using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using System.Threading;

public class Title_Font : MonoBehaviour
{
    SpriteRenderer sr;
    //�F���
    private float cla;
    private float claMax = 255;
    private float Speed = 0.001f;
    //���ԃJ�E���g
    private float Timecount;
    private float Statecount = 1;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //���Ԏ擾
        Timecount += Time.deltaTime;
       //���݂̓����x���擾
       cla = sr.color.a;
 
        if (Timecount > Statecount)
        {
            if (cla <= claMax)
            {
                cla += Speed;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, cla);
            }
        }
    }
}
