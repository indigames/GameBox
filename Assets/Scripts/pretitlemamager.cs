using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pretitlemamager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        KantanGameBox.GameStart();
        Application.LoadLevel("TitleScene");
    }
}
