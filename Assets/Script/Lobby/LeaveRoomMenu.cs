using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{


    private RoomsCanvases _roomsCanvases;

    [SerializeField]
    private Transform _content;

    [SerializeField]
    private PlayerListingsMenu  _playerlistingMenu;
    public void FirstInitialize(RoomsCanvases canvases)
    {

        _roomsCanvases = canvases;
    }

    public void Onclick_LeaveRoom()
    {
        PlayerProperties.resetdataGame();
        _content.DestroyChildren();
        PhotonNetwork.LeaveRoom(true);
        _roomsCanvases.CurrentRoomsCanvas.Hide();
        _playerlistingMenu._listings.Clear(); 
        _playerlistingMenu._listingsLast.Clear();

    }
 


}

