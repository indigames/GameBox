using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            score.SetText("SCORE:{0}  TOTAL:{1}", PlayerInfo.GetScore(), PlayerInfo.GetTotalScore());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.PlayGame){
            UpdateScore();

            //Request Rewards AD from KantanGameBox
            if(adMode==AdMode.NoAd){
                if(PlayerInfo.GetScore()==2){
                    KantanGameBox.ShowRewardAd();
                    adMode = AdMode.ShowAd;
                }                
            }

            //After the reward AD is completed, insert the process in case of success or failure.
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

        //When the game is finished, save the data in the KantanGameBox.
        else if(state == State.SaveData){
            if(KantanGameBox.IsGameSaveFinish()){
                _clearTimer = 2.0f;
                state = State.GameClear;
            }
        }

        //Exit the game when SaveData is complete.
        //Request GameEnd in KantanGameBox before game ends
        //
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

        //After GameEnd is completed, return to the title scene.
        else if(state == State.EndCheck){
           if(KantanGameBox.IsGameEndFinish()){
                SceneManager.LoadScene("TitleScene");
                state =  State.EndGame;
            }
        }
   }
    
    void OnGUI()
    {
        //When the game is finished, save the data in the KantanGameBox.
        //SaveData should only be called once per play.
        if(apple.Count == 0 && state ==State.PlayGame && adMode != AdMode.ShowAd){
            gameclear.SetActive (true);
            PlayerInfo.SetHighScore(PlayerInfo.GetScore());
            PlayerInfo.SetTotalScore(PlayerInfo.GetTotalScore()+PlayerInfo.GetScore());
            KantanGameBox.GameSave(PlayerInfo.ToJSON());
            state = State.SaveData;
        }
    }

}
