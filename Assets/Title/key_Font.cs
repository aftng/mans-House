using UnityEngine;
using UnityEngine.UI;

public class key_Font : MonoBehaviour
{
    public Title title;
    //フォント点滅時間
    [SerializeField] 
    private float _cycle = 1;

    private float _time;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {       
        //点滅
        _time += Time.deltaTime;
        var repeatValue = Mathf.Repeat(_time, _cycle);
        image.enabled = repeatValue >= _cycle * 0.5f;
        if (title.BottanChack)
        {
            Destroy(this.gameObject);
        }
    }
}