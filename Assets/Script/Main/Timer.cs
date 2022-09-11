using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    //Bu obje static olabilir.

    [SerializeField]
    private GameObject countdown;
    private Text countdownText;
    [SerializeField]
    private float countdownTo = 60.0F;
    public GameObject thisplayer;

    [SerializeField]
    private TeamManager TeamRed;

    [SerializeField]
    private TeamManager TeamBlue;

    private Image TimerImage;
 

    private void Start()
    {
        countdownText = countdown.transform.Find("CountdownText").gameObject.transform.GetComponent<Text>();
        TimerImage = countdown.GetComponent<Image>();
    }

    private void Update()
    {

        TimerImage.fillAmount = countdownTo / 60f;


        countdownTo -= Time.deltaTime;

        if (countdownTo >= 10)
        {
            countdownText.text = countdownTo.ToString().Substring(0, 2);
        }
        else if (countdownTo > 0 && countdownTo < 10)
        {
            countdownText.text = countdownTo.ToString().Substring(0, 1);
        }
        else
        { 
            print("odadan çıkıldi");

            PhotonNetwork.LeaveRoom(true);

            if (PlayerProperties.OnLogin_)
            {
                WonOrLost();
                saved_score();
                StartCoroutine(UserSaved());
            }
            SceneManager.LoadScene(1);
        }
    }
    public void Onclick_LeaveGame()
    {

        PhotonNetwork.LeaveRoom(true);
        if (PlayerProperties.OnLogin_)
        {
            WonOrLost();
            saved_score();
            StartCoroutine(UserSaved());
        }
        SceneManager.LoadScene(1);

    }
    private void WonOrLost()
    {
        if (TeamBlue.TeamScore > TeamRed.TeamScore)
        {
            TeamBlue.boolWon = true;
            TeamRed.boolWon = false;
        }
        else if (TeamBlue.TeamScore == TeamRed.TeamScore)
        {
            TeamRed.boolWon = false;
            TeamBlue.boolWon = false;
        }
        else
        {
            TeamRed.boolWon = true;
            TeamBlue.boolWon = false;
        }
    }
    private void saved_score()
    {
        if (thisplayer.GetComponent<Character_Controller>().Team.boolWon)
        {

            PlayerProperties.win_ = 1;
            PlayerProperties.score_ += 1000;
        }
        else
        {
            PlayerProperties.lose_ = 1;
        }
        PlayerProperties.score_ += thisplayer.GetComponent<Character_Controller>().flagscore;

        

    }
    private void show_data()
    {
        print("score:" + PlayerProperties.score_);
        print("kill:" + PlayerProperties.kill_);
        print("death:" + PlayerProperties.death_);
        print("lose:" + PlayerProperties.lose_);
        print("win:" + PlayerProperties.win_);

    }


    IEnumerator UserSaved()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", PlayerProperties.id_);
        form.AddField("score", PlayerProperties.score_);
        form.AddField("kill", PlayerProperties.kill_);
        form.AddField("death", PlayerProperties.death_);
        form.AddField("lose", PlayerProperties.lose_);
        form.AddField("win", PlayerProperties.win_);

        UnityWebRequest www = UnityWebRequest.Post(APImanager.saved_gameScore, form);
        www.SetRequestHeader("Authorization", "Bearer " + PlayerProperties.token_);
        var operation = www.SendWebRequest();
        yield return operation;
    }

}
