using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPlayerDestroy : MonoBehaviour
{
    private float PlayerPosY;
    private float PlayerDestroy = -7.0f;

    // Update is called once per frame
    void Update()
    {
        PlayerPosY = this.transform.position.y;
        if(PlayerPosY <= PlayerDestroy)
        {
            Destroy(gameObject);
        }  
    }
}
