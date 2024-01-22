using UnityEngine;
using UnityEngine.UI;

public class Title_Font : MonoBehaviour
{
    public Title title;
    private Image image;
    //�F���
    private float cla;
    private float claMax = 255;
    private float Speed = 0.01f;
    //���ԃJ�E���g
    private float Timecount;
    private float Statecount = 1;
    void Start()
    {
        image = GetComponent<Image>();
    }
    void FixedUpdate()
    {
        //���Ԏ擾
        Timecount += Time.deltaTime;
       //���݂̓����x���擾
       cla = image.color.a;
 
        if (Timecount > Statecount)
        {
            if (cla <= claMax)
            {
                cla += Speed;
                image.color = new Color(image.color.r, image.color.g, image.color.b, cla);
            }
        }

        if (title.BottanChack)
        {
            Destroy(this.gameObject);
        }
    }
}
