using Unity.VisualScripting;
using UnityEngine;

public class Gameprogress : MonoBehaviour
{
    //�J�����ʒu
    private float[] cameraposition = { 0, 25.6f, 51.2f };
    public float[] Cameraposition {get { return cameraposition; } }
    //�Q�[���S�̂Ŏg���̂Ńv���C���[�ł͂Ȃ�Gameprogress�Ő錾
    private bool playerStop;
    public  bool PlayerStop
    {
        get { return playerStop; }
        set { playerStop = value; }
    }
    //�f�o�b�O�p
    public First_Stage_maneger First_Stage_maneger;
    public Third_Stage_Gamemaneger Third_Stage_Gamemaneger;
    public Second_Stage_Gamemaneger Second_Stage_Gamemaneger;
    private bool SecondStageClearFlag;
    private bool ThirdStageClearFlag;
    private bool FirstStageClearFlag;
    private void Update()
    {
        //�f�o�b�O�p
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
