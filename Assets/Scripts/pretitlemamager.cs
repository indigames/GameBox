using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Application.LoadLevel("TitleScene");
        }
    }
}
