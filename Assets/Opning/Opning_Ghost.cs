using UnityEngine;

public class Opning_Ghost : MonoBehaviour
{
    private float Ghost_speed = 5;
    private float Ghostmove = 1;
    private float GhostPosY;
    private float GhostsStopPos = -1.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        //�ړ�
        GhostPosY = this.transform.position.y;
        if (GhostPosY >= GhostsStopPos)
        {
            Ghost_speed = 0.0f;
        }
       rb.velocity = new Vector2(0, Ghostmove).normalized * Ghost_speed;
    }
}
