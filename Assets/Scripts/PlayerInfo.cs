using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInfo : MonoBehaviour
{
    [Serializable]
    public class User
    {
        public int totalScore = 0;
        public int highScore = 0;
        public int score = 0;
    }
    private static User user;

    public static void FromJSON(string json){
        user = JsonUtility.FromJson<User>(json);
    }

    public static string ToJSON(){
        return JsonUtility.ToJson(user);
    }

    public static int GetScore(){return user.score;}
    public static void SetScore(int value){user.score = value;}
    public static int GetHighScore(){return user.highScore;}
    public static void SetHighScore(int value){user.highScore = value;}
    public static int GetTotalScore(){return user.totalScore;}
    public static void SetTotalScore(int value){user.totalScore = value;}
}
