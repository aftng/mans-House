using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using System.Threading;

public class Title_Font : MonoBehaviour
{
    SpriteRenderer sr;
    //色情報
    private float cla;
    private float claMax = 255;
    private float Speed = 0.001f;
    //時間カウント
    private float Timecount;
    private float Statecount = 1;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //時間取得
        Timecount += Time.deltaTime;
       //現在の透明度を取得
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
