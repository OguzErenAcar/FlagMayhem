using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Roomlisting : MonoBehaviour
{ 
    [SerializeField]
    private Text _text;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        
        _text.text =  roomInfo.Name+"   "+roomInfo.PlayerCount+"/"+roomInfo.MaxPlayers ;
 
    }
    public void OnClick_Button(){
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
