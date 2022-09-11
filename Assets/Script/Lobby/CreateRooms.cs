using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRooms : MonoBehaviour
{

    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
 
    [SerializeField]
    private RoomListingMenu _roomListingsMenu;

    private RoomsCanvases _roomsCanvases; 
 
    public void FirstInitialize(RoomsCanvases canvases){

     //Sahne Canvas 
     print("create room first initialize");
    _roomsCanvases=canvases;
    _createRoomMenu.FirstInitialize(canvases);
     _roomListingsMenu.FirstInitialize(canvases);
    }

}
