using UnityEngine;

public class GameguideLeft : MonoBehaviour
{
    private float nowPosi = 1;

    void Start()
    {
        nowPosi = this.transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(nowPosi + Mathf.PingPong(Time.time, 0.3f) , transform.position.y, transform.position.z);
    }
}
