using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    //mevcut oda
 
    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {

        //Sahne Canvas   
             print("current room first initialize");
     
        _roomsCanvases = canvases;
        _playerListingsMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);

        
    }

    public void Show()
    {  
        this.gameObject.SetActive(true);  

    }
    public void Hide()
    { 
        this.gameObject.SetActive(false);

    }
}
