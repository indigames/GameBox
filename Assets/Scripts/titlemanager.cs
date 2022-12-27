using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlemanager : MonoBehaviour
{
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(state==0){
            if (Input.GetMouseButton(0)) {
                state =1;
                KantanGameBox.GameStart();
            }
        }
        else if(state == 1){
            if(KantanGameBox.IsGameStartFinish()){
                Application.LoadLevel("GameScene");
                state = 2;
            }
        }
    }
}
