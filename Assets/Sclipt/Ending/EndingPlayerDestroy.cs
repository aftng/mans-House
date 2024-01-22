using UnityEngine;

public class EndingPlayerDestroy : MonoBehaviour
{
    private float PlayerPosY;
    private float PlayerDestroy = -7.0f;

    void Update()
    {
        PlayerPosY = this.transform.position.y;
        if(PlayerPosY <= PlayerDestroy)
        {
            Destroy(gameObject);
        }  
    }
}
