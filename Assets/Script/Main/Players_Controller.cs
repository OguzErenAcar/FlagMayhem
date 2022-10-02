using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class Players_Controller : MonoBehaviourPun
{
    public TeamManager TeamRed;
    public TeamManager TeamBlue;
    private Boolean youTurn = false;
    private int nextPlayerViewİd;
    private int next_playerCount = -1;
    private int roomPLayer_count;
    private int return_countinfo = 0;
    private int self_viewİd;
    private bool SetTeam = true;
    private CameraManager Camera;
    public List<PhotonView> photonviewlist;
    private int PlayerCountInScene = 0;
    private bool isChangePlayerCount = true;
    private int sira = 0;

    void Awake()
    {
        Camera = GameObject.Find("Camera").gameObject.GetComponent<CameraManager>();

        sira = PlayerProperties.sira_;
        print("benim sira " + sira);

    }

    public void AddPlayerCountInScene()
    {
        PlayerCountInScene++;
        isChangePlayerCount = true;


    }
    [PunRPC]
    private void CreatePlayer()
    {

        print("create player  player count "+PlayerCountInScene);
        if (PlayerCountInScene < PhotonNetwork.CurrentRoom.PlayerCount)
        {
            print("create player if1 ");
            if (sira == PlayerCountInScene)
            {
                print("create player if2");
                GameObject self_Soldier = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0, null); 
                self_Soldier.GetComponent<PhotonView>().RPC("SetTeam", RpcTarget.All, null);

                Camera.Ordinary = self_Soldier;
            }

        }
    }

    void Update()
    {
        if (isChangePlayerCount)
        {

            print("update  de ");
            isChangePlayerCount = false;
            CreatePlayer();
        };



    }

    public TeamManager getCurrentTeam()
    {
        if (TeamBlue.team_players.Count == TeamRed.team_players.Count)
        {
            return TeamBlue;
        }
        else if (TeamBlue.team_players.Count > TeamRed.team_players.Count)
        {
            return TeamRed;
        }
        else
        {
            return TeamBlue;
        }
    }

public void setbasePlayers(){
    TeamBlue.setbaseTeam();
    TeamRed.setbaseTeam();
}




    private void get_next_player()
    {
        //     foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players )
        //     {
        //         print(playerInfo.Value);
        //     }
        next_playerCount++;
        if (next_playerCount < PhotonNetwork.CurrentRoom.PlayerCount)
        {
            int j = 0;
            foreach (PhotonView view in photonviewlist)
            {

                if (next_playerCount == j)
                {
                    nextPlayerViewİd = view.ViewID;
                    break;
                }
                j++;
            }
        }
        else
        {
            SetTeam = false;
        }
        foreach (PhotonView item in photonviewlist)
        {
            print("photon view id " + item.ViewID);
        }


    }




    void Start()
    {
        print("startta");
        PhotonNetwork.AutomaticallySyncScene = false;
        // object[] PlayerData = { PlayerProperties.roomid_ };

        // self_Ordinary = PhotonNetwork.Instantiate("Player_Soldier", Vector3.zero, Quaternion.identity, 0, PlayerData);
        // Camera.Ordinary = self_Ordinary;
        // self_viewİd = self_Ordinary.GetComponent<PhotonView>().ViewID;

        // get_next_player();
        // foreach (PhotonView item in photonviewlist)
        // {
        //     print(item.ViewID);
        // }
    }




    // Update is called once per frame


    // if (SetTeam)
    // {
    //     if (nextPlayerViewİd == self_viewİd)
    //     {
    //         print("youTurn");
    //         youTurn = true;//sıradaki oyncu beniyim
    //     }
    //     else if (null != PhotonNetwork.GetPhotonView(nextPlayerViewİd).gameObject)// o oyuncu yu bul sahne de viewi
    //     {
    //         //değilsem bekle 
    //         print("next player");
    //         get_next_player();
    //     }




    //     if (youTurn)
    //     {
    //         youTurn = false;
    //         self_Ordinary.GetComponent<PhotonView>().RPC("SetTeam", RpcTarget.All, null);

    //         get_next_player();
    //     }


    // }
}
