using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pretitlemamager : MonoBehaviour
{
    void Start()
    {
        KantanGameBox.GameGetData();
    }

    void Update()
    {
        if(KantanGameBox.IsGameGetDataFinish()){
            PlayerInfo.FromJSON(KantanGameBox.ReadGameData()); 
            SceneManager.LoadScene("TitleScene");
        }
    }
}
