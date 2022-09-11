using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{ 
    [SerializeField]
    private Flagbase flagbase;

     [SerializeField]
    private Text text;

    private int team_score;

    public Transform base_transform;


    void Start(){
        base_transform=this.gameObject.transform;
    }


    private void OnTriggerEnter2D(Collider2D collision){

        Flag flag = collision.gameObject.transform.GetComponent<Flag>();
        TeamManager Team = gameObject.transform.parent.GetComponent<TeamManager>();

        if(flag!=null &&  flag.player.Team==Team){ 
            //takım arkadası ise ,bu localclient değilse ??
            Character_Controller player =flag.player;
            player.Team.TeamScore++;
            player.flagscore+=50;
            Destroy(flag.gameObject);   
            flagbase.CreateFlag();
            team_score++;
            text.text=Team.TeamName+"\n"+ team_score.ToString();

        }
    }


}
