using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
	public GameObject gameclear;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_clearTimer > 0.0f)
        {
            _clearTimer -= Time.deltaTime;
            if(_clearTimer <= 0.0f)
                Application.LoadLevel("TitleScene");
        }
    }
    
    void OnGUI()
    {
        if (_clearTimer == 0.0f && apple.Count == 0)
        {
            gameclear.SetActive (true);
            _clearTimer = 2.0f;
        }
    }
    float _clearTimer = 0.0f;
}
