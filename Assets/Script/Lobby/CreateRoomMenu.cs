using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;
    private RoomsCanvases _roomsCanvases; 
 
    public void FirstInitialize(RoomsCanvases canvases){

    _roomsCanvases=canvases;
    } 


    public void onClick_CreateRoom(){

        if(!PhotonNetwork.IsConnected)
            return;
         RoomOptions options= new RoomOptions(); 
         options.MaxPlayers=4;
         options.PublishUserId=true; 

          PhotonNetwork.JoinOrCreateRoom(_roomName.text,options,TypedLobby.Default );


    }
     


    public override void OnCreatedRoom()
    {  
        //SceneManager.LoadScene(2);
        //_roomsCanvases.CurrentRoomsCanvas.Show();//Büyük canvalsın leave roomunu göster


    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("CreateRoon failed ");
    }
}
