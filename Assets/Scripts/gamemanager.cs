using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manager : MonoBehaviour
{
	public GameObject gameclear;
    public TextMeshProUGUI score;

    enum State{
        PlayGame,
        SaveData,
        GameClear,
        EndCheck,
        EndGame
    }
    enum AdMode{
        NoAd,
        ShowAd,
        EndAd
    }
    private State state;
    private AdMode adMode;
    private float _clearTimer;

    // Start is called before the first frame update
    void Start()
    {
        state = State.PlayGame;
        adMode = AdMode.NoAd;
        PlayerInfo.SetScore(0);
    }

    public void UpdateScore(){
        if(PlayerInfo.NeedUpdate()){
            //score.text = string.Format("SCORE:{0}  TOTAL:{1}", PlayerInfo.GetScore(), PlayerInfo.GetTotalScore());
            score.SetText("SCORE:{0}  TOTAL:{1}", PlayerInfo.GetScore(), PlayerInfo.GetTotalScore());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.PlayGame){
            UpdateScore();

            if(adMode==AdMode.NoAd){
                if(PlayerInfo.GetScore()==2){
                    KantanGameBox.ShowRewardAd();
                    adMode = AdMode.ShowAd;
                }                
            }
            else if(adMode==AdMode.ShowAd){
                if(KantanGameBox.IsShowRewardAdFinish()){
                    if(KantanGameBox.IsRewardAdSuccess()){
                        //Reward Success
                    }
                    else{
                        //Reward Fail
                    }
                    adMode = AdMode.EndAd;
                }
            }
        }
        else if(state == State.SaveData){
            if(KantanGameBox.IsGameSaveFinish()){
                _clearTimer = 2.0f;
                state = State.GameClear;
            }
        }
        else if(state == State.GameClear){
            if(_clearTimer > 0.0f)
            {
                _clearTimer -= Time.deltaTime;
                if(_clearTimer <= 0.0f){
                    KantanGameBox.GameEnd(PlayerInfo.GetTotalScore());
                    state = State.EndCheck;
                }
            }
        }
        else if(state == State.EndCheck){
           if(KantanGameBox.IsGameEndFinish()){
                Application.LoadLevel("TitleScene");
                state =  State.EndGame;
            }
        }
   }
    
    void OnGUI()
    {
        if(apple.Count == 0 && state ==State.PlayGame && adMode != AdMode.ShowAd){
            gameclear.SetActive (true);
            PlayerInfo.SetHighScore(PlayerInfo.GetScore());
            PlayerInfo.SetTotalScore(PlayerInfo.GetTotalScore()+PlayerInfo.GetScore());
            KantanGameBox.GameSave(PlayerInfo.ToJSON());
            state = State.SaveData;
        }
    }

}
