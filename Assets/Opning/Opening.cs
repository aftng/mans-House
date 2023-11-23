using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    private float PlayerPosY;
    private float PlayerSceneChangePos = 10.0f;
    void Update()
    {
        PlayerPosY = this.transform.position.y;
        if (PlayerPosY >= PlayerSceneChangePos)
        {
            SceneManager.LoadScene("Game_scene");
        }  
    }
}