using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class KantanGameBox : MonoBehaviour
{
# if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void _GameStart();

    [DllImport("__Internal")]
    private static extern void _GameEnd(int score);

    [DllImport("__Internal")]
    private static extern void _GameSave(string data);

    [DllImport("__Internal")]
    private static extern void _GameGetData();

    [DllImport("__Internal")]
    private static extern void _ShowRewardAd();

    [DllImport("__Internal")]
    private static extern void _DebugOut(string str);

    private static bool gameStartFlag = false;

    public void GameStart(){
        gameStartFlag = false;
        _GameStart();
        while(gameStartFlag == false)
        {
            Debug.Log("wait");
        }
    }

    public void GameStartResult(){
        _DebugOut("Result");
        gameStartFlag = true;
    }


    public static void GameEnd(int score){
        _GameEnd(score);
    }

    public static void GameSave(string data){
        _GameSave(data);
    }

    public static void GameGetData(){
        _GameGetData();
    }

    public static void ShowRewardAd(){
        _ShowRewardAd();
    }

#else

    public static void GameStart(){
        Debug.Log("GameStart");
    }

    public static void GameEnd(int score){
        Debug.Log("GameEnd");
    }

    public static void GameSave(string data){
        Debug.Log("GameSave");
    }

    public static void GameGetData(){
        Debug.Log("GameGetData");
    }

    public static void ShowRewardAd(){
        Debug.Log("ShowRewardAd");
    }

#endif

}
