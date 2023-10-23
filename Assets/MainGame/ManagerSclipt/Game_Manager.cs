using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Game_Manager : MonoBehaviour
{
    //カメラ位置
    //Stateで初期化すると他のスクリプトのStateで変数を受け渡せない
    private float[] cameraposition = {0, 25.6f, 51.2f};
    public float[] Cameraposition
    {
        get { return cameraposition; }
    }
    //プレイヤーストップ
    private bool playerStop;
    public bool PlayerStop
    {
        get { return playerStop; }
        set { playerStop = value; }
    }
}
