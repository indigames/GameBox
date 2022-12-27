using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
	public GameObject gameclear;
    public TextMeshProUGUI score;

    private int state = 0;
    private int adMode = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        adMode = 0;
        score.text = String.Format("SCORE:{0}  TOTAL:{1}", PlayerInfo.GetScore(), PlayerInfo.GetTotalScore());
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0){
            if(adMode==0){
                if(PlayerInfo.GetScore()==2){
                    KantanGameBox.ShowRewardAd();
                    adMode = 1;
                }                
            }
            else if(adMode==1){
                if(KantanGameBox.IsShowRewardAdFinish()){
                    if(KantanGameBox.IsRewardAdSuccess()){
                        //Reward Success
                    }
                    else{
                        //Reward Fail
                    }
                    adMode = 2;
                }
            }
        }

        else if(state == 1){
            if(KantanGameBox.IsGameSaveFinish()){
                _clearTimer = 2.0f;
                state = 2;
            }
        }
        else if(state == 2){
            if(_clearTimer > 0.0f)
            {
                _clearTimer -= Time.deltaTime;
                if(_clearTimer <= 0.0f){
                    KantanGameBox.GameEnd(PlayerInfo.GetTotalScore());
                    state = 3;
                }
            }
        }
        else if(state == 3){
           if(KantanGameBox.IsGameEndFinish()){
                Application.LoadLevel("TitleScene");
                state = 4;
            }
        }
   }
    
    void OnGUI()
    {
        if(state ==0 && adMode != 1){
            if (_clearTimer == 0.0f && apple.Count == 0)
            {
                gameclear.SetActive (true);
                PlayerInfo.SetHighScore(PlayerInfo.GetScore());
                PlayerInfo.SetTotalScore(PlayerInfo.GetTotalScore()+PlayerInfo.GetScore());
                KantanGameBox.GameSave(PlayerInfo.ToJSON());
                state = 1;
            }
        }
    }
    float _clearTimer = 0.0f;
}
