using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class KantanGameBox : MonoBehaviour
{
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

    enum Mode{
        ModeIdle,
        ModeGameStart,
        ModeGameStartWait,
        ModeGameStartFinish,

        ModeGameEnd,
        ModeGameEndWait,
        ModeGameEndFinish,

        ModeGameSave,
        ModeGameSaveWait,
        ModeGameSaveFinish,

        ModeGameGetData,
        ModeGameGetDataWait,
        ModeGameGetDataFinish,

        ModeShowRewardAd,
        ModeShowRewardAdWait,
        ModeShowRewardAdFinish,

    }

    private static Mode mode = Mode.ModeIdle;
    private static bool ready = false;
    private static int _score = 0;
    private static string _data = "";
    private static bool _success = false;

    public void Ready(){
        ready = true;
        # if !UNITY_EDITOR && UNITY_WEBGL
        _DebugOut("Ready-Unity");
        #endif
    }

    void Update()
    {
        if(ready){
            if(mode == Mode.ModeGameStart){
                # if !UNITY_EDITOR && UNITY_WEBGL
                _GameStart();
                _DebugOut("GameStart-Unity");
                #endif
                mode = Mode.ModeGameStartWait;
            }
            else if(mode == Mode.ModeGameEnd){
                # if !UNITY_EDITOR && UNITY_WEBGL
                _GameEnd(_score);
                _DebugOut("GameEnd-Unity");
                #endif
                mode = Mode.ModeGameEndWait;
            }
            else if(mode == Mode.ModeGameSave){
                # if !UNITY_EDITOR && UNITY_WEBGL
                _GameSave(_data);
                _DebugOut("GameSave-Unity");
                #endif
                mode = Mode.ModeGameSaveWait;
            }
            else if(mode == Mode.ModeGameGetData){
                # if !UNITY_EDITOR && UNITY_WEBGL
                _GameGetData();
                _DebugOut("GameGetData-Unity");
                #endif
                mode = Mode.ModeGameGetDataWait;
            }
            else if(mode == Mode.ModeShowRewardAd){
                # if !UNITY_EDITOR && UNITY_WEBGL
                _ShowRewardAd();
                _DebugOut("ShowRewardAd-Unity");
                #endif
                mode = Mode.ModeShowRewardAdWait;
            }
        }
    }

    ///////////////////////////////////////////
    public void GameStartFinish(){
        # if !UNITY_EDITOR && UNITY_WEBGL
        _DebugOut("GameStartFinish");
        #endif
        if(mode == Mode.ModeGameStartWait){
            mode = Mode.ModeGameStartFinish;
        }
    }

    public static void GameStart(){
        mode = Mode.ModeGameStart;
    }

    public static bool IsGameStartFinish(){
        return (mode == Mode.ModeGameStartFinish);
    }

    ///////////////////////////////////////////
    public void GameEndFinish(){
        # if !UNITY_EDITOR && UNITY_WEBGL
        _DebugOut("GameEndFinish");
        #endif
        if(mode == Mode.ModeGameEndWait){
            mode = Mode.ModeGameEndFinish;
        }
    }

    public static void GameEnd(int score){
        _score = score;
        mode = Mode.ModeGameEnd;
    }

    public static bool IsGameEndFinish(){
        return (mode == Mode.ModeGameEndFinish);
    }

    ///////////////////////////////////////////
    public void GameSaveFinish(){
        # if !UNITY_EDITOR && UNITY_WEBGL
        _DebugOut("GameSaveFinish");
        #endif
        if(mode == Mode.ModeGameSaveWait){
            mode = Mode.ModeGameSaveFinish;
        }
    }

    public static void GameSave(int data){
        _data = data;
        mode = Mode.ModeGameSave;
    }

    public static bool IsGameSaveFinish(){
        return (mode == Mode.ModeGameSaveFinish);
    }

    ///////////////////////////////////////////
    public void GameGetDataFinish(string data){
        # if !UNITY_EDITOR && UNITY_WEBGL
        _DebugOut("GameGetDataFinish");
        #endif
        if(mode == Mode.ModeGameGetDataWait){
            mode = Mode.ModeGameGetDataFinish;
            _data = data;
        }
    }

    public static void GameGetData(){
        mode = Mode.ModeGameGetData;
    }

    public static bool IsGameGetDataFinish(){
        return (mode == Mode.ModeGameGetDataFinish);
    }

    public static string ReadGameData(){
        return _data;
    }

    ///////////////////////////////////////////
    public void ShowRewardAdFinish(bool success){
        # if !UNITY_EDITOR && UNITY_WEBGL
        _DebugOut("ShowRewardAdFinish");
        #endif
        if(mode == Mode.ModeShowRewardAdWait){
            mode = Mode.ModeShowRewardAdFinish;
            _success = success;
        }
    }

    public static void ShowRewardAd(){
        mode = Mode.ModeShowRewardAd;
    }

    public static bool IsShowRewardAdFinish(){
        return (mode == Mode.ModeShowRewardAdFinish);
    }



}
