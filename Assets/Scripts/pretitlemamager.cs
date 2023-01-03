using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//We start with this scene
public class pretitlemamager : MonoBehaviour
{
    void Start()
    {
        //Request KantanGameBox to acquire saved data
        KantanGameBox.GameGetData();
    }

    void Update()
    {
        //Wait until save data acquisition is complete
        if(KantanGameBox.IsGameGetDataFinish()){
            //Read save data
            PlayerInfo.FromJSON(KantanGameBox.ReadGameData()); 
            SceneManager.LoadScene("TitleScene");
        }
    }
}
