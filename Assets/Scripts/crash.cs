using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class crash : MonoBehaviour
{


    void Start()
    {
        Renderer.material.color = new Color32(255, 255, 255, _alpha);
        _scale = new Vector3(0,0,0);
    }

    void Update()
    {
        Renderer.material.color = new Color32(255, 255, 255, _alpha);
        transform.localScale = _scale;
        _scale.x += 10.0f * Time.deltaTime;
        _scale.y += 10.0f * Time.deltaTime;
        _scale = Vector3.Min(_scale,  Vector3.one);
        _alpha -= 8;
        if(_alpha < 8){
            Destroy(gameObject);
        }
    }

    Renderer _renderer = null;
    public Renderer Renderer {
        get { return _renderer ?? (_renderer = gameObject.GetComponent<Renderer> ()); }
    }

    Vector3 _scale;
    byte _alpha = 255;

}
