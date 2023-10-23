using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameguideright : MonoBehaviour
{
    private float nowPosi = 2;

    void Start()
    {
        nowPosi = this.transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(nowPosi - Mathf.PingPong(Time.time, 0.3f), transform.position.y, transform.position.z);
    }
}
