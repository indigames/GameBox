using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pretitlemamager : MonoBehaviour
{
    void Start()
    {
        KantanGameBox.GameStart();
    }
    void Update()
    {
        if(KantanGameBox.IsGameStartFinish())
            Application.LoadLevel("TitleScene");
    }
}
