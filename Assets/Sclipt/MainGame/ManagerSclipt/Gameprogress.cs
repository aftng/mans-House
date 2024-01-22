using Unity.VisualScripting;
using UnityEngine;

public class Gameprogress : MonoBehaviour
{
    //カメラ位置
    private float[] cameraposition = { 0, 25.6f, 51.2f };
    public float[] Cameraposition {get { return cameraposition; } }
    //ゲーム全体で使うのでプレイヤーではなくGameprogressで宣言
    private bool playerStop;
    public  bool PlayerStop
    {
        get { return playerStop; }
        set { playerStop = value; }
    }
    //デバッグ用
    public First_Stage_maneger First_Stage_maneger;
    public Third_Stage_Gamemaneger Third_Stage_Gamemaneger;
    public Second_Stage_Gamemaneger Second_Stage_Gamemaneger;
    private bool SecondStageClearFlag;
    private bool ThirdStageClearFlag;
    private bool FirstStageClearFlag;
    private void Update()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.N) && Input.GetKeyDown(KeyCode.M))
        {
            if (!FirstStageClearFlag)
            {
                FirstStageClearFlag = true;
                First_Stage_maneger.DebugChack();
            }
            else if (!SecondStageClearFlag)
            {
                SecondStageClearFlag = true;
                Second_Stage_Gamemaneger.DebugChack();
            }
            else if (!ThirdStageClearFlag)
            {
                ThirdStageClearFlag = true;
                Third_Stage_Gamemaneger.DebugChack();
            }
        }
    } 
}
