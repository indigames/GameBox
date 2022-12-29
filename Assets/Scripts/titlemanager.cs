using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlemanager : MonoBehaviour
{
    enum State{
        WaitStartButton,
        WaitGameStart,
        EndTitle
    }
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.WaitStartButton;
    }

    // Update is called once per frame
    void Update()
    {
        if(state==State.WaitStartButton){
            if (Input.GetMouseButton(0)) {
                state =State.WaitGameStart;
                KantanGameBox.GameStart();
            }
        }
        else if(state == State.WaitGameStart){
            if(KantanGameBox.IsGameStartFinish()){
                SceneManager.LoadScene("GameScene");
                state = State.EndTitle;
            }
        }
    }
}
