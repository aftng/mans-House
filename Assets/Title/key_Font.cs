using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_Font : MonoBehaviour
{  
    //フォント点滅時間
    [SerializeField] 
    private float _cycle = 1;

    private Renderer Rd;
    private float _time;
    void Start()
    {
        Rd = GetComponent<Renderer>();
    }
    void Update()
    {        
        _time += Time.deltaTime;
        var repeatValue = Mathf.Repeat(_time, _cycle);
        Rd.enabled = repeatValue >= _cycle * 0.5f;
    }
}