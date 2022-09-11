using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update


    private void Start()
    {
        
        print("connecting to server");
        
        if (PlayerProperties.nickname_ == "")
        {
            PhotonNetwork.NickName = MasterManager.GameSettings.NicName;
        }
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 10;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();

    }



    public override void OnConnectedToMaster()
    {
        print("Connected to server2");
        //PlayerProperties.nickname_
        // MasterManager.DebugConsole.AddText("deneme",this);
        if (!PhotonNetwork.InLobby)
        {
            PlayerProperties.resetdataGame();
            PhotonNetwork.JoinLobby();
            print("joined lobby  ");
            if (PlayerProperties.OnLogin_)
            {
                PhotonNetwork.LocalPlayer.NickName = PlayerProperties.nickname_;
            }
 
        }
      

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server for reason" + cause.ToString());

    }
}
